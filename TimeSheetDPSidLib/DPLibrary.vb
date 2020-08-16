Imports System.Windows.Forms
Imports System.Windows.Forms.Control
Imports System.Drawing
Imports System.Delegate
Imports DPFP.ID
Imports DigitalPersona.Standards
Imports DPFP
Imports DPFPCtlXTypeLibNET
Imports DPFPShrXTypeLibNET
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Web
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO
Imports DigitalPersona

Delegate Sub FunctionCall(ByVal param)

Public Class DPLibrary
    Implements DPFP.Capture.EventHandler, IDisposable

    Private Capturer As DPFP.Capture.Capture
    Private StatusLine As Label
    Private StatusText, prompt As TextBox
    Private Picture As PictureBox
    Private Enroller As DPFP.Processing.Enrollment
    Private Verificator As DPFP.Verification.Verification
    Private EnrollMode As Boolean
    Private _SearchDuplicate As Boolean = False
    Private frm As Form
    Private Template As DPFP.Template
    Public Event OnTemplate(ByVal template)
    Dim _DontEnrollNow As Boolean = False
    Private RecordID As String, Recognize As Boolean = False
    Private Message As String = ""
    Private ConnectionString, FingerTable As String
    Dim TrueBitmap As Bitmap
    Private _FingerID As String
    Dim UseIdentityProcessing As Boolean
    Dim Dpi As Integer = 700
    Private _ScannerConnected As Boolean = False
    'Protected Overridable Sub Init()
    '    Try
    '        Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.

    '        If (Not Capturer Is Nothing) Then
    '            Capturer.EventHandler = Me                              ' Subscribe for capturing events.
    '        Else
    '            SetPrompt("Can't initiate capture operation!")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Public ReadOnly Property ScannerConnected()
        Get
            Return _ScannerConnected
        End Get
    End Property
    Public Property DpiVal() As Int16
        Get
            Return Dpi
        End Get
        Set(ByVal value As Int16)
            Dpi = value
        End Set
    End Property
    Public ReadOnly Property VisibleBitmap() As Bitmap
        Get
            Return TrueBitmap
        End Get
    End Property

    Public WriteOnly Property SetPicDerivedPic() As Bitmap
        Set(ByVal value As Bitmap)
            TrueBitmap = value
        End Set
    End Property
    Public Property DontEnrollNow() As Boolean
        Get
            Return _DontEnrollNow
        End Get
        Set(ByVal value As Boolean)

            _DontEnrollNow = value

        End Set
    End Property
    Public Property SearchDuplicate() As Boolean
        Get
            Return _SearchDuplicate
        End Get
        Set(ByVal value As Boolean)
            _SearchDuplicate = value
        End Set
    End Property

    Public Property TTemplate() As DPFP.Template
        Get
            Return Template
        End Get
        Set(ByVal value As DPFP.Template)
            Template = value
        End Set
    End Property

    Public WriteOnly Property FingerID() As String
        Set(ByVal value As String)
            _FingerID = value
        End Set
    End Property

    Public Property TransmittedMessage() As String
        Get
            Return Message
        End Get
        Set(ByVal value As String)
            Message = value
        End Set
    End Property

    Public ReadOnly Property GetRecordID() As String
        Get
            Return RecordID
        End Get
    End Property

    Public ReadOnly Property IsRecognize() As Boolean
        Get
            Return Recognize
        End Get
    End Property

    Public Sub New(ByVal SecKey As String, ByVal _frm As Form, _
                      ByRef _Capturer As DPFP.Capture.Capture, _
                      ByVal _StatusLine As Label, _
                      ByVal _Prompt As TextBox, _
                      ByVal _StatusText As TextBox, _
                      ByVal _Picture As PictureBox, _
                      ByVal _ConnectionString As String, _
                      ByVal _FingerTable As String, _
                        Optional ByVal _EnrollmentMode As Boolean = True, _
                      Optional ByVal _UseIdentityProcessing As Boolean = False, _
                      Optional ByVal _AutoLoadData As Boolean = True, _
                      Optional ByVal _LoadSQL As String = "")
        Try
            If SecKey <> "Sid89456_LicReg_Main" Then
                Throw New Exception("Invalid License in Module")
            End If
            _Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
            Capturer = _Capturer
            StatusLine = _StatusLine
            StatusText = _StatusText
            prompt = _Prompt
            ConnectionString = _ConnectionString
            FingerTable = _FingerTable
            Picture = _Picture
            frm = _frm
            UseIdentityProcessing = _UseIdentityProcessing

            Try
                If (Not Capturer Is Nothing) Then
                    Capturer.EventHandler = Me                             ' Subscribe for capturing events.
                Else
                    SetPrompt("Can't initiate capture operation!")
                End If
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            EnrollMode = _EnrollmentMode

            If EnrollmentMode Then
                Enroller = New DPFP.Processing.Enrollment()         ' Create an enrollment.
            ElseIf Not UseIdentityProcessing Then
                Verificator = New DPFP.Verification.Verification
            End If

            If UseIdentityProcessing And EnrollmentMode = True Then
                Throw New Exception("Invalid Operation, Required for Identifcation Only")
            End If

            DPData.Database = New Database(_ConnectionString, FingerTable, _UseIdentityProcessing, _AutoLoadData, _LoadSQL)

        Catch ex As Exception:Try:logger.WriteLog(ex) : Catch exx As Exception : End Try
            TMsgBox(ex.Message)
        End Try
    End Sub
    Public Sub New(ByVal SecKey As String, ByVal _frm As Form,
                      ByRef _Capturer As DPFP.Capture.Capture,
                      ByVal _StatusLine As Label,
                      ByVal _Prompt As TextBox,
                      ByVal _StatusText As TextBox,
                      ByVal _Picture As PictureBox,
                                           ByVal dtFingers As DataTable,
                        Optional ByVal _EnrollmentMode As Boolean = True,
                      Optional ByVal _UseIdentityProcessing As Boolean = False,
                      Optional ByVal _AutoLoadData As Boolean = True,
                      Optional ByVal _LoadSQL As String = "")
        Try
            If SecKey <> "Sid89456_LicReg_Main" Then
                Throw New Exception("Invalid License in Module")
            End If
            _Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
            Capturer = _Capturer
            StatusLine = _StatusLine
            StatusText = _StatusText
            prompt = _Prompt
            'ConnectionString = _ConnectionString
            Picture = _Picture
            frm = _frm
            UseIdentityProcessing = _UseIdentityProcessing

            Try
                If (Not Capturer Is Nothing) Then
                    Capturer.EventHandler = Me                             ' Subscribe for capturing events.
                Else
                    SetPrompt("Can't initiate capture operation!")
                End If
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            EnrollMode = _EnrollmentMode

            If EnrollmentMode Then
                Enroller = New DPFP.Processing.Enrollment()         ' Create an enrollment.
            ElseIf Not UseIdentityProcessing Then
                Verificator = New DPFP.Verification.Verification
            End If

            If UseIdentityProcessing And EnrollmentMode = True Then
                Throw New Exception("Invalid Operation, Required for Identifcation Only")
            End If

            DPData.Database = New Database(dtFingers, _UseIdentityProcessing)

        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            TMsgBox(ex.Message)
        End Try
    End Sub
    Public Property EnrollmentMode() As Boolean
        Get
            Return EnrollMode
        End Get
        Set(ByVal value As Boolean)
            EnrollMode = value
            If EnrollmentMode Then
                Enroller = New DPFP.Processing.Enrollment()         ' Create an enrollment.
            ElseIf Not UseIdentityProcessing Then
                Verificator = New DPFP.Verification.Verification() ' Create a verification.
            End If
        End Set
    End Property

    Public Sub TMsgBox(ByVal Prompt As String, Optional ByVal MsgBoxStyles As Microsoft.VisualBasic.MsgBoxStyle = MsgBoxStyle.OkOnly)
        MsgBox(Prompt, MsgBoxStyles, My.Application.Info.Title)
    End Sub

    Private Function ConvertToByteArray(ByVal value As Bitmap) As Byte()
        Dim bitmapBytes As Byte()
        Using stream As New System.IO.MemoryStream
            value.Save(stream, value.RawFormat.Bmp)
            bitmapBytes = stream.ToArray
        End Using
        Return bitmapBytes
    End Function

    Protected Overridable Sub Process(ByVal Sample As DPFP.Sample)
        Try
            TrueBitmap = ConvertSampleToBitmap(Sample)
            DrawPicture(TrueBitmap)
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try

        End Try
    End Sub

    Protected Function ConvertSampleToBitmap(ByVal Sample As DPFP.Sample) As Bitmap

        Dim convertor As New DPFP.Capture.SampleConversion()    ' Create a sample convertor.
        Dim bitmap As Bitmap = Nothing                          ' TODO: the size doesn't matter
        convertor.ConvertToPicture(Sample, bitmap)              ' TODO: return bitmap as a result
        Return bitmap
    End Function

    Protected Function ExtractFeatures(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
        Try
            Dim extractor As New DPFP.Processing.FeatureExtraction()        ' Create a feature extractor
            Dim feedback As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
            Dim features As New DPFP.FeatureSet()
            extractor.CreateFeatureSet(Sample, Purpose, feedback, features) ' TODO: return features as a result?
            If (feedback = DPFP.Capture.CaptureFeedback.Good) Then
                Return features
            Else
                Return Nothing
            End If
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Throw New Exception("Error Extracting Features")
        End Try

    End Function

    Sub OnComplete(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
        MakeReport("The fingerprint sample was captured.")
        If DontEnrollNow Then
            SetPrompt("Continue Fingerprint Scan..")
        Else
            SetPrompt("Scan the same fingerprint again.")
        End If

        Recognize = False
        RecordID = Nothing
        Message = Nothing

        If DontEnrollNow Then
            'process fingerprints and return the bitmap
            ProcessEnrollmentAsBitmap(Sample)

        ElseIf EnrollmentMode Then
            'direct finger enrollment
            ProcessEnrollment(Sample)

        ElseIf Not UseIdentityProcessing Then
            'use verification method
            ProcessVerification(Sample)

        ElseIf UseIdentityProcessing Then
            'use the ID identification method
            ProcessIdentification(Sample)

        End If
    End Sub

    Sub OnFingerGone(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone
        MakeReport("The finger was removed from the fingerprint reader.")
    End Sub

    Sub OnFingerTouch(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
        MakeReport("The fingerprint reader was touched.")
    End Sub

    Sub OnReaderConnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
        MakeReport("The fingerprint reader was connected and started.")
        _ScannerConnected = True
    End Sub

    Sub OnReaderDisconnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
        MakeReport("The fingerprint reader was disconnected.")
        _ScannerConnected = False
    End Sub

    Sub OnSampleQuality(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality
        If CaptureFeedback = DPFP.Capture.CaptureFeedback.Good Then
            MakeReport("The quality of the fingerprint sample is good.")
        Else
            MakeReport("The quality of the fingerprint sample is poor.")
        End If
    End Sub

    Private Sub _SetStatus(ByVal status)
        If StatusLine IsNot Nothing Then
            StatusLine.Text = status
        End If
    End Sub

    Protected Sub SetPrompt(ByVal text)
        frm.Invoke(New FunctionCall(AddressOf _SetPrompt), text)
    End Sub

    Private Sub _SetPrompt(ByVal text)
        If prompt IsNot Nothing Then
            prompt.Text = text
        End If
    End Sub

    Protected Sub MakeReport(ByVal status)
        frm.Invoke(New FunctionCall(AddressOf _MakeReport), status)
    End Sub

    Private Sub _MakeReport(ByVal status)
        If Not StatusText Is Nothing Then
            StatusText.AppendText(status + Chr(13) + Chr(10))
        End If
    End Sub

    Protected Sub DrawPicture(ByVal bmp)
        frm.Invoke(New FunctionCall(AddressOf _DrawPicture), bmp)
    End Sub

    Private Sub _DrawPicture(ByVal bmp)
        Picture.Image = New Bitmap(bmp, Picture.Size)
    End Sub

    Protected Sub SetStatus(ByVal status)
        frm.Invoke(New FunctionCall(AddressOf _SetStatus), status)
    End Sub

    Public Sub StartCapture()
        If (Not Capturer Is Nothing) Then
            Try
                Capturer.StartCapture()
                SetPrompt("Using the fingerprint reader, scan your fingerprint.")
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
                SetPrompt("Can't initiate capture!")
            End Try
        End If
    End Sub

    Public Sub StopCapture()
        If (Not Capturer Is Nothing) Then
            Try
                Capturer.StopCapture()
                MakeReport("The fingerprint reader was stopped")
            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
                SetPrompt("Can't terminate capture!")
            End Try
        End If
    End Sub

#Region "Enrollment"

    Sub ProcessEnrollment(ByVal Sample As DPFP.Sample)
        Try
            Process(Sample)

            ' Process the sample and create a feature set for the enrollment purpose.
            Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment)

            ' Check quality of the sample and add to enroller if it's good
            If (Not features Is Nothing) Then
                Try
                    If Enroller.FeaturesNeeded > 1 Then
                        MakeReport("Feature set was created, remaining: " & Enroller.FeaturesNeeded - 1)
                    Else
                        MakeReport("Feature set was created")
                    End If

                    Enroller.AddFeatures(features)              ' Add feature set to template.

                    '////////////////
                    UpdateStatus()

                    ' Check if template has been created.
                    Select Case Enroller.TemplateStatus
                        Case DPFP.Processing.Enrollment.Status.Ready        ' Report success and stop capturing
                            'RaiseEvent OnTemplate(Enroller.Template)
                            'store to database <===check duplicate if required
                            Try
                                If SearchDuplicate Then
                                    If UseIdentityProcessing Then
                                        ProcessIdentification(Sample, False)
                                    Else
                                        ProcessVerification(Sample, False)
                                    End If
                                    If IsRecognize Then
                                        TransmittedMessage = "Duplicate Found With ID=" & RecordID
                                        Exit Sub
                                    End If
                                End If
                                Template = Enroller.Template
                                DPData.Database.Records.Add(_FingerID, Template, _
                                                              ConvertToByteArray(TrueBitmap), _
                                                              FingerTable, Dpi)
                                SetPrompt("Click Close, and then click Fingerprint Verification.")
                                StopCapture()

                                TransmittedMessage = "Enrollment Succeeded"

                            Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
                            Finally
                                Enroller = Nothing
                                Enroller = New DPFP.Processing.Enrollment()         ' Create an enrollment.
                                MakeReport(vbNewLine & "New Enrollment")
                            End Try

                        Case DPFP.Processing.Enrollment.Status.Failed       ' Report failure and restart capturing
                            Enroller.Clear()
                            StopCapture()
                            TransmittedMessage = "Enrollment Failed"
                            ' RaiseEvent OnTemplate(Nothing)
                            StartCapture()
                            Enroller = Nothing
                            Enroller = New DPFP.Processing.Enrollment          ' Create an enrollment.

                    End Select
                Finally
                End Try
            Else

            End If
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            TMsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Sub ProcessEnrollmentAsBitmap(ByVal Sample As DPFP.Sample)
        Try
            ' Process the sample and create a feature set for the enrollment purpose.
            Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment)

            ' Check quality of the sample before sending the bitmap
            If (Not features Is Nothing) Then
                TrueBitmap = ConvertSampleToBitmap(Sample)
                ' Template = ConvertSampleAsTemplate(Sample)
                TransmittedMessage = "New Finger"
                'Return ConvertToByteArray(TrueBitmap)
            Else
                TransmittedMessage = "Low Fingerprints Quality Encountered, Please Retry"
            End If
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            TMsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Sub ProcessFingerPrintsForEnrollmentFromBitmap(Optional ByVal VertDpi As Long = 700,
                                    Optional ByVal HorDpi As Long = 700)
        Dim BmpOperate As New Bitmap(TrueBitmap, TrueBitmap.Width, TrueBitmap.Height)
        Try
            'convert bitmap to template and save to database having known it is unique------------------ 
            If SearchDuplicate Then
                'convert bmp to sample and verify uniqueness
                DPsample = ConvertRawBmpAsSample(BmpOperate, VertDpi, HorDpi)
                'check for duplicate
                If UseIdentityProcessing Then
                    ProcessIdentification(DPsample, False)
                Else
                    ProcessVerification(DPsample, False)
                End If
                If IsRecognize Then
                    TransmittedMessage = "Duplicate Found With ID=" & RecordID
                    Exit Sub
                End If
                'convert and save directly
                Template = ConvertSampleAsTemplate(DPsample)
                If Template IsNot Nothing Then
                    'add to db
                    DPData.Database.Records.Add(_FingerID, Template,
                                                               ConvertToByteArray(BmpOperate),
                                                               FingerTable, Dpi)
                    TransmittedMessage = "Enrollment Succeeded"
                Else
                    TransmittedMessage = "Valid Fingerprints Quality Not Found"
                    Throw New Exception("Error Reading Valid Fingerprints")
                End If
            Else
                'convert and save directly
                Template = ConvertRawBmpAsTemplate(TrueBitmap, VertDpi, HorDpi)
                If Template IsNot Nothing Then
                    'add to db
                    DPData.Database.Records.Add(_FingerID, Template,
                                                               ConvertToByteArray(BmpOperate),
                                                               FingerTable, Dpi)
                    TransmittedMessage = "Enrollment Succeeded"
                Else
                    TransmittedMessage = "Valid Fingerprints Quality Not Found"
                    Throw New Exception("Error Reading Valid Fingerprints")
                End If
            End If
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Throw ex
        End Try
    End Sub

    Public Class ReturnedFinger
        Public FingerID As String
        Public Features As Byte()
        Public Picture As Byte()
        Public ANSIFeatures As Byte()
        Public ISOFeatures As Byte()
    End Class

    Public Function ProcessFingerPrintsForEnrollmentFromBitmapData(Optional ByVal VertDpi As Long = 700,
                                    Optional ByVal HorDpi As Long = 700) As ReturnedFinger
        Dim BmpOperate As New Bitmap(TrueBitmap, TrueBitmap.Width, TrueBitmap.Height)
        Try
            'convert bitmap to template and save to database having known it is unique------------------ 
            If SearchDuplicate Then
                'convert bmp to sample and verify uniqueness
                DPsample = ConvertRawBmpAsSample(BmpOperate, VertDpi, HorDpi)
                'check for duplicate
                If UseIdentityProcessing Then
                    ProcessIdentification(DPsample, False)
                Else
                    ProcessVerification(DPsample, False)
                End If
                If IsRecognize Then
                    TransmittedMessage = "Duplicate Found With ID=" & RecordID
                    Return Nothing
                End If
                'convert and save directly
                Template = ConvertSampleAsTemplate(DPsample)

                If Template IsNot Nothing Then
                    ''add to db
                    'DPData.Database.Records.Add(_FingerID, Template,
                    '                                           ConvertToByteArray(BmpOperate),
                    '                                           FingerTable, Dpi)

                    TransmittedMessage = "Enrollment Succeeded"

                    Return New ReturnedFinger() With {.FingerID = _FingerID,
                        .Features = Template.Bytes,
                        .Picture = ConvertToByteArray(BmpOperate),
                        .ANSIFeatures = ConvertRawBmpAsANSITemplate(BmpOperate),
                        .ISOFeatures = ConvertRawBmpAsISOTemplate(BmpOperate)}
                Else
                    TransmittedMessage = "Valid Fingerprints Quality Not Found"
                    Throw New Exception("Error Reading Valid Fingerprints")
                End If
            Else
                'convert and save directly
                Template = ConvertRawBmpAsTemplate(TrueBitmap, VertDpi, HorDpi)
                If Template IsNot Nothing Then
                    'add to db
                    'DPData.Database.Records.Add(_FingerID, Template,
                    '                                           ConvertToByteArray(BmpOperate),
                    '                                           FingerTable, Dpi)
                    TransmittedMessage = "Enrollment Succeeded"

                    Return New ReturnedFinger() With {.FingerID = _FingerID,
                        .Features = Template.Bytes,
                        .Picture = ConvertToByteArray(BmpOperate),
                        .ANSIFeatures = ConvertRawBmpAsANSITemplate(BmpOperate),
                        .ISOFeatures = ConvertRawBmpAsISOTemplate(BmpOperate)}
                Else
                    TransmittedMessage = "Valid Fingerprints Quality Not Found"
                    Throw New Exception("Error Reading Valid Fingerprints")
                End If
            End If
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Throw ex
        End Try
    End Function
    Public Sub AddUserToCollection(ByVal Usr As DPFP.ID.User)
        Try
            If UseIdentityProcessing Then
                Dim FingerPosition As Int16 = 0
                If Usr Is Nothing Or Not Usr.TemplateExists(FingerPosition) Then
                    Throw New Exception("Valid User Biometrics Collection Required")
                End If

                DPData.Database.Records.UserCollections.AddUser(Usr)
            Else
                Throw New Exception("Valid for Identification Mode Only")
            End If
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Throw ex
        End Try
    End Sub
#End Region

#Region "Verification"

    Sub ProcessVerification(ByVal Sample As DPFP.Sample, _
                            Optional ByVal ShowReport As Boolean = True)
        Try
            Process(Sample)

            ' Process the sample and create a feature set for the enrollment purpose.
            Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification)

            Dim sw As New Stopwatch()
            ' Check quality of the sample and start verification if it's good
            If Not features Is Nothing Then
                'loads the collection
                Dim recordEnumerable As IEnumerable(Of Record)
                recordEnumerable = DPData.Database.Records

                Dim result As DPFP.Verification.Verification.Result = New DPFP.Verification.Verification.Result()
                'If Verificator Is Nothing Then
                'Verificator = New DPFP.Verification.Verification()
                'End If

                'timer for current comparison 
                sw.Start()

                For Each record As Record In recordEnumerable
                    ' Compare the feature set with our template' former method  Verificator.Verify(features, record.Template, result)

                    result = DPFP.Verification.Verification.Verify(features, record.Template, &H7FFFFFFF / 100000)
                    '  UpdateStatus(result.FARAchieved)

                    If result.Verified Then
                        Recognize = True
                        'set recordid after detection
                        RecordID = record.ID
                        Exit For
                    Else
                        Recognize = False
                    End If
                Next
                sw.[Stop]()

                If ShowReport Then
                    If result.Verified Then
                        TransmittedMessage = "Record Was Identified"
                        MakeReport("The fingerprint was IDENTIFIED in " & TimeToString(sw.Elapsed))
                    Else
                        TransmittedMessage = "Record Was Not Identified"
                        MakeReport("The fingerprint was NOT RECOGNIZED. Process took: " & TimeToString(sw.Elapsed))
                    End If
                End If
                sw.[Stop]()
            Else
                Throw New Exception("Fingerprint is of low quality")
            End If
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            TransmittedMessage = ex.Message
        End Try

    End Sub
    Sub ProcessIdentification(ByVal Sample As DPFP.Sample, _
                            Optional ByVal ShowReport As Boolean = True)
        Try
            Process(Sample)
            Dim sw As New Stopwatch()
            ' Process the sample and create a feature set for the enrollment purpose.
            Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification)
            '-----------------------------------------processing -------------------------------
            ' Check quality of the sample and start verification if it's good
            If Not features Is Nothing Then
                sw.Start() 'stsrt timer

                ''identification on user collection
                Dim One As Integer = &H7FFFFFFF
                Dim IDentify As New DPFP.ID.Identification(DPData.Database.RecordsWithIdentity, One / 2000)
                Dim CandidateIDList As DPFP.ID.CandidateIDList = IDentify.Identify(features)
                If CandidateIDList.Count > 0 Then
                    Recognize = True
                    'set recordid after detection
                    RecordID = CandidateIDList.Item(0).ToString()
                Else
                    Recognize = False
                End If

                sw.Stop()
                If ShowReport Then
                    If Recognize Then
                        TransmittedMessage = "Record Was Identified"
                        MakeReport("The fingerprint was IDENTIFIED in " & TimeToString(sw.Elapsed))
                    Else
                        TransmittedMessage = "Record Was Not Identified"
                        MakeReport("The fingerprint was NOT RECOGNIZED. Process took: " & TimeToString(sw.Elapsed))
                    End If
                End If
            Else
                Throw New Exception("Fingerprint is of low quality")
            End If
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            TransmittedMessage = ex.Message
        End Try

    End Sub
#End Region

#Region "Function Extension"
    Public Shared Function TimeToString(ByVal time As TimeSpan) As String
        Dim t As Long = time.Ticks / 10
        Dim value As String
        Dim remm As Long
        t = Math.DivRem(t, 1000, remm)
        value = remm.ToString() + " mks"
        If t <> 0 Then
            t = Math.DivRem(t, 1000, remm)
            value = remm.ToString() + " ms " + value
            If t <> 0 Then
                t = Math.DivRem(t, 60, remm)
                value = remm.ToString() + " s " + value
                If t <> 0 Then
                    t = Math.DivRem(t, 60, remm)
                    value = remm.ToString() + " m " + value
                    If t <> 0 Then
                        t = Math.DivRem(t, 24, remm)
                        value = remm.ToString() + " h " + value
                        If t <> 0 Then
                            value = t + " d " + value
                        End If
                    End If
                End If
            End If
        End If
        Return value
    End Function

    Public Sub UpdateStatus(Optional ByVal FAR As Integer = 0)
        ' Show number of samples needed.
        If EnrollmentMode Then
            SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded))
        Else
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR))
        End If
    End Sub
    Public Function DeleteFingerByID(ByVal ID As String) As Boolean
        Try
            Dim sqlcon As New SqlClient.SqlConnection(ConnectionString)
            DPData.Database.Records.ClearByID(ID, FingerTable, sqlcon)
            Return True
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Throw ex
        End Try
    End Function

    Public Function GetFingerprintsByID(ByVal ID As String) As DataTable
        Try

            Dim sqlcon As New SqlClient.SqlConnection
            sqlcon.ConnectionString = ConnectionString

            Return DPData.Database.Records.GetFingerByID(ID, sqlcon, FingerTable)
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Throw ex
        End Try
    End Function

    Public Function HasFinger(ByVal ID As String) As Boolean
        Try
            Dim sqlcon As New SqlClient.SqlConnection
            sqlcon.ConnectionString = ConnectionString

            Return DPData.Database.Records.HasFinger(ID, sqlcon, FingerTable)
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Return False
        End Try
    End Function

    'enrollfrompicture and verifyfrompicture

    'loadrecordsbyID , deleterecordbyid

#End Region

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
                StopCapture()
                DPData.Database.Dispose()
                Picture = Nothing
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#Region "Template Converter Module"

    Dim DPsample As DPFP.Sample
    Dim DPFeatures As DPFP.FeatureSet
    Dim DPTemplate As DPFP.Template
    Dim ISOFMD As Byte()
    Dim inputData As [Byte]() = Nothing
    Dim inpRaw As DigitalPersona.Standards.InputParameterForRaw = Nothing 
    Public Shared Function EncodeBitmap(ByVal Bmp As Bitmap, _
                                       Optional ByVal HorResolution As Int16 = 500, _
                                       Optional ByVal VertResolution As Int16 = 500) As Bitmap
        Try
            Dim OutputBmp As Bitmap
            If Bmp IsNot Nothing Then
                OutputBmp = Bmp
                OutputBmp.SetResolution(HorResolution, VertResolution)
                Return OutputBmp
            End If
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Throw ex
        Finally
            'If Bmp IsNot Nothing Then
            '    Bmp.Dispose()
            'End If
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' Converts raw fingerprints bitmap as DP Template
    ''' </summary>
    ''' <param name="RawBmp">Raw fingerprints bitmap</param>
    ''' <param name="VertDpi">Vertical Resolution</param>
    ''' <param name="HorDpi">Horizontal Resolution</param>
    ''' <returns>DPFP.Template</returns>
    ''' <remarks></remarks>
    Public Function ConvertRawBmpAsTemplate(ByVal RawBmp As Bitmap, Optional ByVal VertDpi As Long = 700, _
                                    Optional ByVal HorDpi As Long = 700) As DPFP.Template
        Dim VConverter As VariantConverter
        Enroller = New DPFP.Processing.Enrollment
        RawBmp = EncodeBitmap(RawBmp, VertDpi, HorDpi)
        Try
            'converts raw image to dpSample using DFC 2.0---------------------------------------
            'encode the bmp variable using the bitmap Loader
            Dim BmpLoader As New BitmapLoader(RawBmp, RawBmp.HorizontalResolution, RawBmp.VerticalResolution)
            BmpLoader.ProcessBitmap()
            'return the required result
            inputData = BmpLoader.RawData
            inpRaw = BmpLoader.DPInputParam
            'dispose the object
            BmpLoader.Dispose()

            'start the conversion process
            VConverter = New VariantConverter(VariantConverter.OutputType.dp_sample, _
                                                         DataType.RawSample, _
                                                         inpRaw, inputData, False)
            Dim DStream As New MemoryStream(VConverter.Convert())
            DPsample = New DPFP.Sample(DStream)
            'DPsample = DirectCast(VConverter.Convert(), DPFP.Sample)

            'converts dpSample to DPFeatures using the OTW'''''''''''''''''''''''''''''''''''''''
            DPFeatures = ExtractFeatures(DPsample, Processing.DataPurpose.Enrollment)
            '==========================================================================
            'convert DPfeatures to ISO FMD using the DFC 2.0'''''''''''''''''''''''''''''''''''''''  
            Dim SerializedFeatures As Byte() = Nothing
            DPFeatures.Serialize(SerializedFeatures) 'serialized features into the array of bytes
            ISOFMD = DigitalPersona.Standards.Converter.Convert(SerializedFeatures, DigitalPersona.Standards.DataType.DPFeatureSet, _
                                                                      DataType.ISOFeatureSet)

            'convert ISO FMD to DPTemplate using DFC 2.0'''''''''''''''''''''''''''''''''''''''
            Dim DPTemplateData As Byte() = DigitalPersona.Standards.Converter.Convert(ISOFMD, DigitalPersona.Standards.DataType.ISOTemplate, _
                                                                     DataType.DPTemplate)
            'deserialize data to Template
            DPTemplate = New DPFP.Template
            DPTemplate.DeSerialize(DPTemplateData) 'required for database purpose
            '============================================================================ 
            DStream.Close()
            Return DPTemplate
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Return Nothing
        End Try
    End Function

    Private Function ConvertRawBmpAsTemplateData(ByVal RawBmp As Bitmap, Optional ByVal VertDpi As Long = 700, _
                                    Optional ByVal HorDpi As Long = 700) As Byte()
        Dim VConverter As VariantConverter
        Enroller = New DPFP.Processing.Enrollment
        RawBmp = EncodeBitmap(RawBmp, VertDpi, HorDpi)
        Try
            'converts raw image to dpSample using DFC 2.0---------------------------------------
            'encode the bmp variable using the bitmap Loader
            Dim BmpLoader As New BitmapLoader(RawBmp, RawBmp.HorizontalResolution, RawBmp.VerticalResolution)
            BmpLoader.ProcessBitmap()
            'return the required result
            inputData = BmpLoader.RawData
            inpRaw = BmpLoader.DPInputParam
            'dispose the object
            BmpLoader.Dispose()

            'start the conversion process
            VConverter = New VariantConverter(VariantConverter.OutputType.dp_sample, _
                                                         DataType.RawSample, _
                                                         inpRaw, inputData, False)
            Dim DStream As New MemoryStream(VConverter.Convert())
            DPsample = New DPFP.Sample(DStream)
            'DPsample = DirectCast(VConverter.Convert(), DPFP.Sample)

            'converts dpSample to DPFeatures using the OTW'''''''''''''''''''''''''''''''''''''''
            DPFeatures = ExtractFeatures(DPsample, Processing.DataPurpose.Enrollment)
            '==========================================================================
            'convert DPfeatures to ISO FMD using the DFC 2.0'''''''''''''''''''''''''''''''''''''''  
            Dim SerializedFeatures As Byte() = Nothing
            DPFeatures.Serialize(SerializedFeatures) 'serialized features into the array of bytes
            ISOFMD = DigitalPersona.Standards.Converter.Convert(SerializedFeatures, DigitalPersona.Standards.DataType.DPFeatureSet, _
                                                                      DataType.ISOFeatureSet)

            'convert ISO FMD to DPTemplate using DFC 2.0'''''''''''''''''''''''''''''''''''''''
            Dim DPTemplateData As Byte() = DigitalPersona.Standards.Converter.Convert(ISOFMD, DigitalPersona.Standards.DataType.ISOTemplate, _
                                                                     DataType.DPTemplate)

            Return DPTemplateData
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Return Nothing
        End Try
    End Function

    Private Function ConvertRawBmpAsSample(ByVal RawBmp As Bitmap, Optional ByVal VertDpi As Long = 700, _
                                    Optional ByVal HorDpi As Long = 700) As Sample
        Dim VConverter As VariantConverter
        Enroller = New DPFP.Processing.Enrollment
        RawBmp = EncodeBitmap(RawBmp, VertDpi, HorDpi)
        Try
            'converts raw image to dpSample using DFC 2.0---------------------------------------
            'encode the bmp variable using the bitmap Loader
            Dim BmpLoader As New BitmapLoader(RawBmp, RawBmp.HorizontalResolution, RawBmp.VerticalResolution)
            BmpLoader.ProcessBitmap()
            'return the required result
            inputData = BmpLoader.RawData
            inpRaw = BmpLoader.DPInputParam
            'dispose the object
            BmpLoader.Dispose()

            'start the conversion process
            VConverter = New VariantConverter(VariantConverter.OutputType.dp_sample, _
                                                         DataType.RawSample, _
                                                         inpRaw, inputData, False)
            Dim DStream As New MemoryStream(VConverter.Convert())
            DPsample = New DPFP.Sample(DStream)
            Return DPsample
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Converts  DP Sample to DP Template
    ''' </summary>
    ''' <param name="Sample">DP Sample object</param>
    ''' <returns>DP Template</returns>
    ''' <remarks></remarks>
    Public Function ConvertSampleAsTemplate(ByVal Sample As Sample) As Template
        Enroller = New DPFP.Processing.Enrollment
        Try
            'converts dpSample to DPFeatures using the OTW'''''''''''''''''''''''''''''''''''''''
            DPFeatures = ExtractFeatures(Sample, Processing.DataPurpose.Enrollment)
            '==========================================================================
            'convert DPfeatures to ISO FMD using the DFC 2.0'''''''''''''''''''''''''''''''''''''''  
            Dim SerializedFeatures As Byte() = Nothing
            DPFeatures.Serialize(SerializedFeatures) 'serialized features into the array of bytes
            ISOFMD = DigitalPersona.Standards.Converter.Convert(SerializedFeatures, DigitalPersona.Standards.DataType.DPFeatureSet, _
                                                                      DataType.ISOFeatureSet)

            'convert ISO FMD to DPTemplate using DFC 2.0'''''''''''''''''''''''''''''''''''''''
            Dim DPTemplateData As Byte() = DigitalPersona.Standards.Converter.Convert(ISOFMD, DigitalPersona.Standards.DataType.ISOTemplate, _
                                                                     DataType.DPTemplate)
            'deserialize data to Template
            DPTemplate = New DPFP.Template
            DPTemplate.DeSerialize(DPTemplateData) 'required for database purpose
            '============================================================================ 

            Return DPTemplate
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Converts ISO Template Binary to DP Template
    ''' </summary>
    ''' <param name="ISOTemplate">ISO Template Binary</param>
    ''' <returns>DP Template</returns>
    ''' <remarks></remarks>
    Public Function ConvertISOTemplateAsDPTemplate(ISOTemplate As Byte()) As Template
        Try 
            ' Dim OutputParamANSIandISO As New OutputParameterForConvertSample  With {.rotation = 128}

            Dim DPTemplateData As Byte() = DigitalPersona.Standards.Converter.Convert(ISOTemplate, DigitalPersona.Standards.DataType.ISOTemplate, _
                                                                     DataType.DPTemplate)
            'deserialize data to Template
            DPTemplate = New DPFP.Template
            DPTemplate.DeSerialize(DPTemplateData) 'required for database purpose
            Return DPTemplate
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Converts ANSI Template Binary to DP Template
    ''' </summary>
    ''' <param name="ANSITemplate">ANSI Template Binary</param>
    ''' <returns>DP Template</returns>
    ''' <remarks></remarks>
    Public Function ConvertANSITemplateAsDPTemplate(ANSITemplate As Byte()) As Template
        Try
            ' Dim OutputParamANSIandISO As New OutputParameterForConvertSample  With {.rotation = 128}

            Dim DPTemplateData As Byte() = DigitalPersona.Standards.Converter.Convert(ANSITemplate, DigitalPersona.Standards.DataType.ANSITemplate, _
                                                                     DataType.DPTemplate)
            'deserialize data to Template
            DPTemplate = New DPFP.Template
            DPTemplate.DeSerialize(DPTemplateData) 'required for database purpose
            Return DPTemplate
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Returns binary of ISO Template
    ''' </summary>
    ''' <param name="RawBmp">Raw fingerprints bitmap</param>
    ''' <param name="VertDpi">Vertical Resolution</param>
    ''' <param name="HorDpi">Horizontal Resolution</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConvertRawBmpAsISOTemplate(ByVal RawBmp As Bitmap, Optional ByVal VertDpi As Long = 700, _
                                    Optional ByVal HorDpi As Long = 700) As Byte()
        Try
            Dim DPTemplate As Template = ConvertRawBmpAsTemplate(RawBmp, VertDpi, HorDpi)
            Dim OutputParamANSIandISO As New OutputParameterForIsoAndAnsi With {.rotation = 128}

            Dim ISOTemplate As Byte() = DigitalPersona.Standards.Converter.Convert(DPTemplate.Bytes, DigitalPersona.Standards.DataType.DPTemplate, _
                                                                     DataType.ISOTemplate, OutputParamANSIandISO)
            Return ISOTemplate
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Returns binary of ANSI Template
    ''' </summary>
    ''' <param name="RawBmp">Raw fingerprints bitmap</param>
    ''' <param name="VertDpi">Vertical Resolution</param>
    ''' <param name="HorDpi">Horizontal Resolution</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConvertRawBmpAsANSITemplate(ByVal RawBmp As Bitmap, Optional ByVal VertDpi As Long = 700, _
                                    Optional ByVal HorDpi As Long = 700) As Byte()
        Try
            Dim DPTemplate As Template = ConvertRawBmpAsTemplate(RawBmp, VertDpi, HorDpi)
            Dim OutputParamANSIandISO As New OutputParameterForIsoAndAnsi With {.rotation = 128}

            Dim ANSITemplate As Byte() = DigitalPersona.Standards.Converter.Convert(DPTemplate.Bytes, DigitalPersona.Standards.DataType.DPTemplate, _
                                                                     DataType.ANSITemplate, OutputParamANSIandISO)
            Return ANSITemplate
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Return Nothing
        End Try
    End Function

#End Region

End Class

Public Class VariantConverter
    Dim dpSensorCollection As DPFP.Capture.ReadersCollection = Nothing
    Dim dpSensorCapturer As DPFP.Capture.Capture = Nothing
    Dim dpImageConverter As DPFP.Capture.SampleConversion = Nothing
    Dim dpFtrExtractor As DPFP.Processing.FeatureExtraction = Nothing
    Dim dpFtrEnroller As DPFP.Processing.Enrollment = Nothing
    Dim dpTemplate As DPFP.Template = Nothing
    Dim dpFeatureSet As DPFP.FeatureSet = Nothing
    Dim inputData As [Byte]() = Nothing
    Dim inpRaw As DigitalPersona.Standards.InputParameterForRaw = Nothing
    Dim dataType As DigitalPersona.Standards.DataType = DigitalPersona.Standards.DataType.DPTemplate
    Private cbOutputType As OutputType
    Private WriteOutputToFile As Boolean
    Enum OutputType
        dp_sample
        dp_tmpl
        dp_ftr
        ansi_sample
        ansi_ftr
        ansi_tmplX
        iso_sample
        iso_ftr
        iso_tmpl
        iso_tmplX
    End Enum

    Sub New(ByVal Output As OutputType, _
            ByVal _dataType As DigitalPersona.Standards.DataType, _
            ByVal _inpRaw As DigitalPersona.Standards.InputParameterForRaw, _
            ByVal _inputData As Byte(), _
            Optional ByVal _WriteOutputToFile As Boolean = False)
        Try
            cbOutputType = Output
            dataType = _dataType
            inpRaw = _inpRaw
            inputData = _inputData
            WriteOutputToFile = _WriteOutputToFile
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try

        End Try
    End Sub

    Public Function Convert() As Byte()

        Dim ext As String = Nothing
        'holds the file extension
        Dim outputType As DigitalPersona.Standards.DataType = DigitalPersona.Standards.DataType.DPTemplate
        Select Case cbOutputType
            Case VariantConverter.OutputType.dp_sample
                'DP Sample
                ext = "dp_sample"
                outputType = DigitalPersona.Standards.DataType.DpSample
                Exit Select
            Case VariantConverter.OutputType.dp_tmpl
                'DP Template
                ext = "dp_tmpl"
                outputType = DigitalPersona.Standards.DataType.DPTemplate
                Exit Select
            Case VariantConverter.OutputType.dp_ftr
                'DP Feature Set
                ext = "dp_ftr"
                outputType = DigitalPersona.Standards.DataType.DPFeatureSet
                Exit Select
            Case VariantConverter.OutputType.ansi_sample
                'ANSI Sample
                ext = "ansi_sample"
                outputType = DigitalPersona.Standards.DataType.ANSISample
                Exit Select
            Case VariantConverter.OutputType.ansi_ftr
                'ANSI Feature Set
                ext = "ansi_ftr"
                outputType = DigitalPersona.Standards.DataType.ANSIFeatureSet
                Exit Select
            Case VariantConverter.OutputType.ansi_sample
                'ANSI Template
                ext = "ansi_tmpl"
                outputType = DigitalPersona.Standards.DataType.ANSITemplate
                Exit Select
            Case VariantConverter.OutputType.ansi_tmplX
                'ANSI Template Extended
                ext = "ansi_tmplX"
                outputType = DigitalPersona.Standards.DataType.ANSITemplateWithExtendedData
                Exit Select
            Case VariantConverter.OutputType.iso_sample
                'ISO Sample
                ext = "iso_sample"
                outputType = DigitalPersona.Standards.DataType.ISOSample
                Exit Select
            Case VariantConverter.OutputType.iso_ftr
                'ISO Feature Set
                ext = "iso_ftr"
                outputType = DigitalPersona.Standards.DataType.ISOFeatureSet
                Exit Select
            Case VariantConverter.OutputType.iso_tmpl
                'ISO Template
                ext = "iso_tmpl"
                outputType = DigitalPersona.Standards.DataType.ISOTemplate
                Exit Select
            Case VariantConverter.OutputType.iso_tmplX
                'ISO Template Extended
                ext = "iso_tmplX"
                outputType = DigitalPersona.Standards.DataType.ISOTemplateWithExtendedData
                Exit Select
        End Select

        Dim dataToFile As Byte() = Nothing

        Try

            If dataType = DigitalPersona.Standards.DataType.RawSample Then
                If outputType <> DigitalPersona.Standards.DataType.ISOSample AndAlso outputType <> DigitalPersona.Standards.DataType.ANSISample AndAlso outputType <> DigitalPersona.Standards.DataType.DpSample Then
                    MessageBox.Show("You can only convert a raw sample to another sample format.  Please select an appropriate output type.")
                    Return Nothing
                End If
                Dim outParameter As [Object] = Nothing

                dataToFile = DigitalPersona.Standards.Converter.Convert(inputData, dataType, inpRaw, outputType, outParameter)
            Else

                dataToFile = DigitalPersona.Standards.Converter.Convert(inputData, dataType, outputType)
            End If
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            MessageBox.Show(ex.Message + " inner: " + ex.InnerException.Message)
            Return Nothing
        End Try

        If WriteOutputToFile Then
            Dim dlgSave As New SaveFileDialog

            dlgSave.Filter = "Biometric File| *." & ext
            dlgSave.Title = "Save Biometric Data"

            If dlgSave.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                Return Nothing
            End If

            Dim fileName As [String] = dlgSave.FileName

            Dim fsOut As New FileStream(fileName, FileMode.Create, FileAccess.Write)
            Dim writer As New BinaryWriter(fsOut)
            writer.Write(dataToFile)
            writer.Close()
            fsOut.Close()
            MessageBox.Show("Successfully Saved File" & vbLf + dlgSave.FileName)
        End If

        Return dataToFile
    End Function

End Class

Public Class BitmapLoader
    Inherits Form
    Private inpRaw As DigitalPersona.Standards.InputParameterForRaw
    Private m_rawData As Byte()
    Private filename As [String]
    Private bmp As Bitmap = Nothing
    Private pbBitmap As New PictureBox
    Private tbXdpi, tbYdpi As Integer
    Public Sub New()

    End Sub

    Public Sub New(ByVal Rawbmp As Bitmap, ByVal _tbXdpi As Integer, ByVal _tbYdpi As Integer)
        Try
            bmp = Rawbmp
            pbBitmap = New PictureBox()
            pbBitmap.Size = New Size(152, 200)
            tbXdpi = _tbXdpi
            tbYdpi = _tbYdpi
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            MessageBox.Show("Error opening bitmap file: " & ex.Message)
            Return
        End Try
        Try
            Dim resizedBMP As New Bitmap(pbBitmap.Width, pbBitmap.Height)
            Dim g As Graphics = Graphics.FromImage(DirectCast(resizedBMP, Image))
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic
            g.DrawImage(bmp, 0, 0, resizedBMP.Width, resizedBMP.Height)
            pbBitmap.Image = resizedBMP
            g.Dispose()
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            Throw ex
        End Try
    End Sub

    Public ReadOnly Property RawData() As Byte()
        Get
            Return m_rawData
        End Get
    End Property

    Public ReadOnly Property DPInputParam() As DigitalPersona.Standards.InputParameterForRaw
        Get
            Return inpRaw
        End Get
    End Property

    Public Sub ProcessBitmap()

        Dim width As Integer = 0
        Dim height As Integer = 0
        Dim dpiX As Integer = 0
        Dim dpiY As Integer = 0
        Dim bpp As Integer = 0


        Try
            dpiX = Convert.ToInt32(tbXdpi)
            dpiY = Convert.ToInt32(tbYdpi)

            width = bmp.Width
            height = bmp.Height
            Dim bmpData As System.Drawing.Imaging.BitmapData

            Dim rect As New Rectangle(0, 0, width, height)

            Select Case bmp.PixelFormat
                'Check for 8bit grayscale
                Case System.Drawing.Imaging.PixelFormat.Format8bppIndexed
                    m_rawData = New Byte(width * height - 1) {}
                    ' what about padding?
                    bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.[ReadOnly], bmp.PixelFormat)
                    Marshal.Copy(bmpData.Scan0, m_rawData, 0, width * height)
                    bmp.UnlockBits(bmpData)
                    inpRaw = New DigitalPersona.Standards.InputParameterForRaw(width, height, dpiX, dpiY, 8)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Exit Select

                    'Check for 24bpp RGB 888
                Case System.Drawing.Imaging.PixelFormat.Format24bppRgb
                    m_rawData = New Byte(width * height - 1) {}
                    bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.[ReadOnly], bmp.PixelFormat)
                    For y As Integer = 0 To height - 1
                        For x As Integer = 0 To width - 1
                            'Calculate greyscale based on average RGB intensity
                            Dim i As Integer = x * 3 + y * bmpData.Stride
                            Dim Dividend As Integer = Marshal.ReadByte(bmpData.Scan0, i)
                            Dim Dividend2 As Integer = Marshal.ReadByte(bmpData.Scan0, i + 1)
                            Dim Dividend3 As Integer = Marshal.ReadByte(bmpData.Scan0, i + 2)

                            Dim avg_val As Integer = (Dividend + Dividend2 + Dividend3) / 3
                            'Convert to byte and save gray scale data
                            m_rawData(x + y * width) = CByte(avg_val)
                        Next
                    Next
                    '----------------------------
                    bmp.UnlockBits(bmpData)
                    inpRaw = New DigitalPersona.Standards.InputParameterForRaw(width, height, dpiX, dpiY, 8)
                    Exit Select

                    '32bits bitmpa conversion to grayscale
                Case System.Drawing.Imaging.PixelFormat.Format32bppArgb, System.Drawing.Imaging.PixelFormat.Format32bppRgb
                    m_rawData = New Byte(width * height - 1) {}
                    bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.[ReadOnly], bmp.PixelFormat)
                    For y As Integer = 0 To height - 1
                        For x As Integer = 0 To width - 1
                            'Calculate greyscale based on average RGB intensity
                            Dim i As Integer = x * 4 + y * bmpData.Stride
                            Dim Dividend As Integer = Marshal.ReadByte(bmpData.Scan0, i)
                            Dim Dividend2 As Integer = Marshal.ReadByte(bmpData.Scan0, i + 1)
                            Dim Dividend3 As Integer = Marshal.ReadByte(bmpData.Scan0, i + 2)

                            Dim avg_val As Integer = (Dividend + Dividend2 + Dividend3) / 3
                            m_rawData(x + y * width) = CByte(avg_val)
                        Next
                    Next
                    '----------------------------
                    bmp.UnlockBits(bmpData)
                    inpRaw = New DigitalPersona.Standards.InputParameterForRaw(width, height, dpiX, dpiY, 8)
                    Exit Select
                Case Else
                    MessageBox.Show("Bitmap format not supported.  Please convert to either 8bpp indexed or 24 bpp non-indexed")
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Exit Select
            End Select
            Me.Close()
        Catch ex As Exception : Try : logger.WriteLog(ex) : Catch exx As Exception : End Try
            MessageBox.Show(ex.Message)
            Return
        End Try
    End Sub

    Private Sub BitmapLoader_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        bmp.Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
End Class
