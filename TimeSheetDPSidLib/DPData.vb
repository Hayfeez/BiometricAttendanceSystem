Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Collections.ObjectModel
Imports DPFP.ID

NotInheritable Class DPData

    Sub New()
    End Sub

    Public Shared Database As Database

End Class

Public Class Record
    'private fields
    Private m_ID As String
    Private m_Template As DPFP.Template

    Sub New(ByVal id As String, ByVal template As DPFP.Template)
        If id IsNot Nothing And template IsNot Nothing Then
            m_ID = id
            m_Template = template
        Else
            Throw New ArgumentException("Valid Record")
        End If
    End Sub

    Public ReadOnly Property Template() As DPFP.Template
        Get
            Return m_Template
        End Get
    End Property

    Public ReadOnly Property ID() As String
        Get
            Return m_ID
        End Get
    End Property

End Class

Public Class Database
    Implements IDisposable

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        Try
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                    If Connection IsNot Nothing Then
                        If Connection.State <> ConnectionState.Closed Then
                            Connection.Close()
                        End If
                        Connection.Dispose()
                        Connection = Nothing
                    End If
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try

        End Try

    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    'variables---------------------------------
    Private m_records As RecordCollection
    Private Connection As SqlConnection
    '-------------------------------------------

    Public ReadOnly Property Records() As RecordCollection
        Get
            Return m_records
        End Get
    End Property

    Public ReadOnly Property RecordsWithIdentity() As DPFP.ID.UserCollection
        Get
            Return m_records.UserCollections
        End Get
    End Property
    Dim _ConnectionString As String
    Public ReadOnly Property ConnectionString() As String
        Get
            Return _ConnectionString
        End Get
    End Property
    Friend Sub New(ByVal ConnectionString As String, _
            ByVal FingerTable As String, Optional ByVal UseIdentityProcess As Boolean = False, _
            Optional ByVal AutoLoadData As Boolean = True, Optional ByVal LoadSQL As String = "")
        Try
            _ConnectionString = ConnectionString
            Connection = New SqlConnection(ConnectionString)
            Connection.Open()
            m_records = New RecordCollection(Me, FingerTable, UseIdentityProcess, AutoLoadData, LoadSQL)

        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Throw New Exception("Error Reaching Database")
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
    End Sub

    Friend Sub New(ByVal dt As DataTable, Optional ByVal UseIdentityProcess As Boolean = False)
        Try

            m_records = New RecordCollection(Me, dt, UseIdentityProcess)

        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Throw New Exception("Error Reaching Database")
        Finally

        End Try
    End Sub


    Public Class RecordCollection
        Inherits ReadOnlyCollection(Of Record)

        Private itmG As List(Of Record)
        Private owner As Database
        Dim UserCollection As New DPFP.ID.UserCollection(500000)
        Dim FTable As String
        Dim UseIdentityProcess As Boolean
        Public ReadOnly Property UserCollections() As UserCollection
            Get
                Return UserCollection
            End Get
        End Property

        Sub New(ByVal Owner As Database, ByVal dt As DataTable,
                Optional ByVal _UseIdentityProcess As Boolean = False)
            MyBase.New(New List(Of Record)())
            UseIdentityProcess = _UseIdentityProcess
            Try

                If Not UseIdentityProcess Then
                    itmG = New List(Of Record)(255)
                    Dim id As String
                    Dim record As Record
                    For Each reader As DataRow In dt.Rows
                        id = reader("FingerID").ToString
                        Dim memStreamTemplate As New MemoryStream(CType(reader("Features"), Byte()))
                        Dim template As New DPFP.Template()
                        template.DeSerialize(memStreamTemplate)

                        record = New Record(id, template)
                        Items.Add(record)
                    Next

                Else

                    Dim CurrentID As String = ""
                    Dim PreviousID As String = ""
                    Dim Usr As DPFP.ID.User
                    Dim Fingerposition As Int16 = 0
                    Dim template As New DPFP.Template()
                    Dim id As String

                    For Each reader As DataRow In dt.Rows
                        id = reader("FingerID").ToString
                        If String.IsNullOrEmpty(id.Trim) Then Continue For
                        CurrentID = id

                        Dim memStreamTemplate As New MemoryStream(CType(reader("Features"), Byte()))
                        template.DeSerialize(memStreamTemplate)

                        If PreviousID <> CurrentID And PreviousID <> "" Then
                            UserCollection.AddUser(Usr)
                            Fingerposition = 0
                        End If

                        If PreviousID <> CurrentID Then Usr = New DPFP.ID.User(id)

                        Usr.AddTemplate(template, Fingerposition)

                        PreviousID = id
                        Fingerposition += 1
                    Next

                    If Usr IsNot Nothing Then UserCollection.AddUser(Usr)
                End If
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try

            Finally

            End Try
        End Sub


        Sub New(ByVal Owner As Database, ByVal FingerTable As String, _
                Optional ByVal _UseIdentityProcess As Boolean = False, _
                Optional ByVal AutoLoadData As Boolean = True, Optional ByVal LoadSql As String = "")
            MyBase.New(New List(Of Record)())
            Dim cmd As SqlCommand
            Dim reader As SqlDataReader
            UseIdentityProcess = _UseIdentityProcess
            Try
                FTable = FingerTable
                If AutoLoadData Then 'performs data cache in memory

                    If Not UseIdentityProcess Then
                        itmG = New List(Of Record)(255)
                        Me.owner = Owner
                        If LoadSql = "" Then
                            LoadSql = "select  Features, FingerID  from " & FingerTable & _
                                    "  order by fingerID"
                        End If
                        cmd = New SqlCommand(LoadSql, Owner.Connection)
                        cmd.CommandTimeout = 0
                        reader = cmd.ExecuteReader(CommandBehavior.Default)
                        Dim id As String
                        Dim record As Record
                        While reader.Read
                            id = reader("FingerID").ToString
                            Dim memStreamTemplate As New MemoryStream(CType(reader("Features"), Byte()))
                            Dim template As New DPFP.Template()
                            template.DeSerialize(memStreamTemplate)

                            record = New Record(id, template)
                            Items.Add(record)

                        End While
                    Else
                        '-----------------------------------------------'----------------------------------------------- 
                        If LoadSql = "" Then
                            LoadSql = "select  Features, FingerID  from " & FingerTable & _
                        "  order by fingerID"
                        End If

                        If Not LoadSql.ToLower.Contains(" order ") Then
                            LoadSql &= " order by fingerID"
                        End If

                        cmd = New SqlCommand(LoadSql, Owner.Connection)

                        cmd.CommandTimeout = 0
                        Dim CurrentID As String = ""
                        Dim PreviousID As String = ""
                        reader = cmd.ExecuteReader(CommandBehavior.Default)
                        Dim Usr As DPFP.ID.User
                        Dim Fingerposition As Int16 = 0
                        Dim template As New DPFP.Template()
                        Dim id As String

                        While reader.Read
                            id = reader("FingerID").ToString
                            If String.IsNullOrEmpty(id.Trim) Then Continue While
                            CurrentID = id

                            Dim memStreamTemplate As New MemoryStream(CType(reader("Features"), Byte()))
                            template.DeSerialize(memStreamTemplate)

                            If PreviousID <> CurrentID And PreviousID <> "" Then
                                UserCollection.AddUser(Usr)
                                Fingerposition = 0
                            End If

                            If PreviousID <> CurrentID Then Usr = New DPFP.ID.User(id)

                            Usr.AddTemplate(template, Fingerposition)

                            PreviousID = id
                            Fingerposition += 1
                        End While
                        If Usr IsNot Nothing Then UserCollection.AddUser(Usr)
                    End If
                End If
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try

            Finally
                If cmd IsNot Nothing Then cmd.Dispose()
            End Try
        End Sub

        Sub GetAllFingerprintsAgain(ByVal FingerTable As String)
            Items.Clear()
            Dim sqlcon As New SqlConnection(DPData.Database.ConnectionString)
            Dim cmd As SqlCommand
            Dim reader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.Default)
            sqlcon.Open()
            Try
                If Not UseIdentityProcess Then
                    cmd = New SqlCommand("Select Features, FingerID from " & _
                                        FingerTable & " " & " ", sqlcon)

                    cmd.CommandTimeout = 0
                    While reader.Read

                        Dim id As String = reader("FingerID").ToString
                        Dim template As New DPFP.Template()
                        Dim memStreamTemplate As New MemoryStream(CType(reader("Features"), Byte()))
                        template.DeSerialize(memStreamTemplate)

                        Dim record As New Record(id, template)
                        Items.Add(record)

                    End While
                Else
                    '-----------------------------------------------'----------------------------------------------- 
                    cmd = New SqlCommand("select  Features, FingerID  from fingerprints " & _
                    "  order by fingerID", sqlcon)

                    cmd.CommandTimeout = 0
                    Dim CurrentID As String = ""
                    Dim PreviousID As String = ""
                    reader = cmd.ExecuteReader(CommandBehavior.Default)
                    Dim Usr As DPFP.ID.User
                    Dim Fingerposition As Int16 = 0
                    Dim template As New DPFP.Template()
                    Dim id As String

                    While reader.Read
                        id = reader("FingerID").ToString
                        CurrentID = id

                        Dim memStreamTemplate As New MemoryStream(CType(reader("Features"), Byte()))
                        template.DeSerialize(memStreamTemplate)

                        If PreviousID <> CurrentID And PreviousID <> "" Then
                            UserCollection.AddUser(Usr)
                            Fingerposition = 0
                        End If

                        If PreviousID <> CurrentID Then Usr = New DPFP.ID.User(id)

                        Usr.AddTemplate(template, Fingerposition)

                        PreviousID = id
                        Fingerposition += 1
                    End While
                    If Usr IsNot Nothing Then UserCollection.AddUser(Usr)
                End If
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Finally
                cmd.Dispose()
            End Try
        End Sub

        Public Function Add(ByVal ID As String, ByVal template As DPFP.Template, ByVal picture As Byte(), _
                             ByVal FIngerTable As String, Optional ByVal Dpi As Int16 = 700)
            Dim sqlcon As New SqlConnection(DPData.Database.ConnectionString)
            Try

                Dim InsertStatement As String = "Insert into " & FIngerTable & _
                " (Features, FingerID,Picture ) Values (@Features, @FingerID, @Pictures)"
                'Connection = New SqlConnection(ConnectionString)
                'Connection.Open()
                ''Dim Features As Byte() = DirectCast(template.Bytes, Byte())
                'If owner.Connection Is Nothing Then
                '    owner .Connection =
                'End If
                sqlcon.Open()
                Dim InsertCommand As New SqlCommand(InsertStatement, sqlcon)
                InsertCommand.Parameters.Add("@Features", SqlDbType.VarBinary).Value = template.Bytes
                InsertCommand.Parameters.Add("@FingerID", SqlDbType.VarChar).Value = ID
                InsertCommand.Parameters.Add("@Pictures", SqlDbType.VarBinary).Value = picture 

                Dim cnt As Integer = InsertCommand.ExecuteNonQuery
                InsertCommand.Dispose()

                If UseIdentityProcess Then 'identification ID method used

                    'Dim FingerPosition As Int16 = 0
                    'If Usr Is Nothing Or Not Usr.TemplateExists(FingerPosition) Then
                    '    Throw New Exception("Valid User Biometrics Collection Required")
                    'End If

                    ' UserCollection.AddUser(Usr)

                Else 'verification method used
                    Dim record As New Record(ID, template)
                    Items.Add(record)
                End If

                Return True
            Catch seex As SqlClient.SqlException
                Throw seex
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
                Throw ex
            Finally
                If sqlcon.State = ConnectionState.Open Then
                    sqlcon.Close()
                End If
            End Try
            Return True
        End Function

        Public Sub ClearByID(ByVal Id As String, ByVal FingerTable As String, ByVal con As SqlConnection)
            Try
                Dim rec As Record
                Dim dt As New DataTable

                If Not UseIdentityProcess Then 'if verification method  is used 
                    dt = GetTemplateByID(Id, con)
                End If

                'delete from DB
                Dim cmd As New SqlCommand("DELETE FROM  " & FingerTable & " where FingerID='" & Id & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()

                If cmd.ExecuteNonQuery() > 0 Then
                    'remove form the collection
                    If UseIdentityProcess Then
                        Dim UsrId As New UserID(Id)
                        UserCollections.RemoveUser(UsrId)
                    Else
                        If dt IsNot Nothing Then
                            Dim LItem = Items.ToList()
                            LItem.RemoveAll(Function(x) x.ID = Id)
                            Items.Clear()
                            For Each itm In LItem
                                Items.Add(itm)
                            Next
                            LItem.Clear()

                            'For Each rw As DataRow In dt.Rows
                            '    Dim template As New DPFP.Template()
                            '    Dim memStreamTemplate As New MemoryStream(CType(rw("Features"), Byte()))
                            '    template.DeSerialize(memStreamTemplate)
                            '    rec = New Record(Id, template)
                            '    Items.Remove(rec)
                            'Next
                        End If

                    End If
                    cmd.Dispose()
                End If

            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
                Throw ex
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try

        End Sub

        Private Function GetTemplateByID(ByVal Id As String, ByVal Con As SqlConnection) As DataTable
            Dim dd As New SqlDataAdapter("SELECT Features FROM  " & FTable & " where FingerID='" & Id & "'", Con)
            Dim ds As New DataSet
            Try
                dd.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0)
                End If
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
                Throw ex
            End Try
            Return Nothing
        End Function

        Public Function GetFingerByID(ByVal Id As String, ByVal con As SqlConnection, ByVal FingerTable As String) As DataTable
            Dim dd As New SqlDataAdapter("SELECT Picture FROM  " & FingerTable & " where FingerID='" & Id & "'", con)
            Dim ds As New DataSet
            Try
                dd.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0)
                End If
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
                Throw ex
            End Try
            Return Nothing
        End Function

        Public Function HasFinger(ByVal Id As String, ByVal con As SqlConnection, ByVal FingerTable As String) As Boolean
            Dim dd As New SqlDataAdapter("SELECT FingerID FROM  " & FingerTable & " where FingerID='" & Id & "'", con)
            Dim ds As New DataSet
            Dim status As Boolean
            Try
                dd.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    status = True
                Else
                    status = False
                End If
                Return status
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
                Throw ex
            End Try

        End Function

    End Class

End Class
