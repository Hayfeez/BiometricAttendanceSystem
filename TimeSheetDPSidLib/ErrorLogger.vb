Imports Microsoft.VisualBasic
Imports System.IO

Public Class ErrorLogger 
    Dim _DestFolder As String
    Sub New(ByVal DestFolder As String)
        _DestFolder = DestFolder
        Try
            If Not Directory.Exists(DestFolder) Then Directory.CreateDirectory(DestFolder)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub WriteClientLog(ByVal ex As String)

        Dim file As String = Path.Combine(_DestFolder, Now.Date.ToString("dd_MM_yyyy_") & "ClientErrorLog.txt")
        Dim hasInnerException As Boolean = False
        Using writer As New StreamWriter(file, True)
            writer.WriteLine(String.Format("======================================={0}=======================================", DateTime.Now.ToString()))
            writer.WriteLine(ex)
        End Using

    End Sub
    Public Sub WriteLog(ByVal ex As Exception)
        If ex.Message = "Thread was being aborted." Then
            Return
        End If

        Dim file As String = Path.Combine(_DestFolder, Now.Date.ToString("dd_MM_yyyy_") & "ErrorLog.txt")
        Dim hasInnerException As Boolean = False
        Using writer As New StreamWriter(file, True)
            writer.WriteLine(String.Format("======================================={0}=======================================", DateTime.Now.ToString()))
            writer.WriteLine(ex.Message)
            writer.WriteLine(String.Format("---------------Stack Trace---------------"))
            writer.WriteLine(ex.StackTrace)

            If ex.InnerException IsNot Nothing Then
                hasInnerException = True
                writer.WriteLine(String.Format("**********************Inner Exception**********************"))
            End If
        End Using

        If hasInnerException Then
            WriteLog(ex.InnerException)
        End If
    End Sub
    Public Sub WriteActivity(ByVal Activity As String)

        Dim file As String = Path.Combine(_DestFolder, Now.Date.ToString("dd_MM_yyyy_") & "ActivityLog.txt")
        Dim hasInnerException As Boolean = False
        Using writer As New StreamWriter(file, True)
            writer.WriteLine(String.Format("======================================={0}=======================================", DateTime.Now.ToString()))
            writer.WriteLine(Activity)
        End Using
    End Sub
End Class