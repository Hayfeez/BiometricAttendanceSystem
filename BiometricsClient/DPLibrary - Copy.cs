using DigitalPersona.Standards;
using DPFP;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BiometricsClient.ErrorLogBase;

namespace BiometricsClient.Copy
{
         delegate void FunctionCall(dynamic param);

        public class DPLibrary : DPFP.Capture.EventHandler, IDisposable
        {
            private DPFP.Capture.Capture Capturer;
            private Label StatusLine;
            private TextBox StatusText, prompt;
            private PictureBox Picture;
            private DPFP.Processing.Enrollment Enroller;
            private DPFP.Verification.Verification Verificator;
            private bool EnrollMode;
            private bool _SearchDuplicate = false;
            private Form frm;
            private DPFP.Template Template;
            public event OnTemplateEventHandler OnTemplate;

            public delegate void OnTemplateEventHandler(object template);

            private bool _DontEnrollNow = false;
            private string RecordID;
            private bool Recognize = false;
            private string Message = "";
            private string ConnectionString, FingerTable;
            private Bitmap TrueBitmap;
            private string _FingerID;
            private bool UseIdentityProcessing;
            private short Dpi = 700;
            private bool _ScannerConnected = false;
 
            public bool ScannerConnected
            {
                get
                {
                    return _ScannerConnected;
                }
            }
            public short DpiVal
            {
                get
                {
                    return Dpi;
                }
                set
                {
                    Dpi = value;
                }
            }
            public Bitmap VisibleBitmap
            {
                get
                {
                    return TrueBitmap;
                }
            }

            public Bitmap SetPicDerivedPic
            {
                set
                {
                    TrueBitmap = value;
                }
            }
            public bool DontEnrollNow
            {
                get
                {
                    return _DontEnrollNow;
                }
                set
                {
                    _DontEnrollNow = value;
                }
            }
            public bool SearchDuplicate
            {
                get
                {
                    return _SearchDuplicate;
                }
                set
                {
                    _SearchDuplicate = value;
                }
            }

            public DPFP.Template TTemplate
            {
                get
                {
                    return Template;
                }
                set
                {
                    Template = value;
                }
            }

            public string FingerID
            {
                set
                {
                    _FingerID = value;
                }
            }

            public string TransmittedMessage
            {
                get
                {
                    return Message;
                }
                set
                {
                    Message = value;
                }
            }

            public string GetRecordID
            {
                get
                {
                    return RecordID;
                }
            }

            public bool IsRecognize
            {
                get
                {
                    return Recognize;
                }
            }

            public DPLibrary(Form _frm, ref DPFP.Capture.Capture _Capturer, Label _StatusLine, TextBox _Prompt, TextBox _StatusText, PictureBox _Picture, string _ConnectionString, string _FingerTable, bool _EnrollmentMode = true, bool _UseIdentityProcessing = false, bool _AutoLoadData = true, string _LoadSQL = "")
            {
                try
                {
                    _Capturer = new DPFP.Capture.Capture();                   // Create a capture operation.
                    Capturer = _Capturer;
                    StatusLine = _StatusLine;
                    StatusText = _StatusText;
                    prompt = _Prompt;
                    ConnectionString = _ConnectionString;
                    FingerTable = _FingerTable;
                    Picture = _Picture;
                    frm = _frm;
                    UseIdentityProcessing = _UseIdentityProcessing;

                    try
                    {
                        if (Capturer != null)
                            Capturer.EventHandler = this;                             // Subscribe for capturing events.
                        else
                            SetPrompt("Can't initiate capture operation!");
                    }
                    catch (Exception ex)
                    {
                         logger.WriteLog(ex);
                       
                        MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    EnrollMode = _EnrollmentMode;

                    if (EnrollmentMode)
                        Enroller = new DPFP.Processing.Enrollment();         // Create an enrollment.
                    else if (!UseIdentityProcessing)
                        Verificator = new DPFP.Verification.Verification();

                    if (UseIdentityProcessing & EnrollmentMode == true)
                        throw new Exception("Invalid Operation, Required for Identifcation Only");

                    DPData.Database = new Database(_ConnectionString, FingerTable, _UseIdentityProcessing, _AutoLoadData, _LoadSQL);
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    TMsgBox(ex.Message);
                }
            }
          
        public bool EnrollmentMode
            {
                get
                {
                    return EnrollMode;
                }
                set
                {
                    EnrollMode = value;
                    if (EnrollmentMode)
                        Enroller = new DPFP.Processing.Enrollment();         // Create an enrollment.
                    else if (!UseIdentityProcessing)
                        Verificator = new DPFP.Verification.Verification();// Create a verification.
                }
            }

            public void TMsgBox(string Prompt, Microsoft.VisualBasic.MsgBoxStyle MsgBoxStyles = MsgBoxStyle.OkOnly)
            {
               MessageBox.Show(Prompt, "");
            }

            private byte[] ConvertToByteArray(Bitmap value)
            {
                byte[] bitmapBytes;
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    value.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    bitmapBytes = stream.ToArray();
                }
                return bitmapBytes;
            }

            protected virtual void Process(DPFP.Sample Sample)
            {
                try
                {
                    TrueBitmap = ConvertSampleToBitmap(Sample);
                    DrawPicture(TrueBitmap);
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                }
            }

            protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
            {
                DPFP.Capture.SampleConversion convertor = new DPFP.Capture.SampleConversion();    // Create a sample convertor.
                Bitmap bitmap = null/* TODO Change to default(_) if this is not a reference type */;                          // TODO: the size doesn't matter
                convertor.ConvertToPicture(Sample, ref bitmap);              // TODO: return bitmap as a result
                return bitmap;
            }

            protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
            {
                try
                {
                    DPFP.Processing.FeatureExtraction extractor = new DPFP.Processing.FeatureExtraction();        // Create a feature extractor
                    DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
                    DPFP.FeatureSet features = new DPFP.FeatureSet();
                    extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features); // TODO: return features as a result?
                    if ((feedback == DPFP.Capture.CaptureFeedback.Good))
                        return features;
                    else
                        return null/* TODO Change to default(_) if this is not a reference type */;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw new Exception("Error Extracting Features");
                }
            }

            public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
            {
                MakeReport("The fingerprint sample was captured.");
                if (DontEnrollNow)
                    SetPrompt("Continue Fingerprint Scan..");
                else
                    SetPrompt("Scan the same fingerprint again.");

                Recognize = false;
                RecordID = null;
                Message = null;

                if (DontEnrollNow)
                    // process fingerprints and return the bitmap
                    ProcessEnrollmentAsBitmap(Sample);
                else if (EnrollmentMode)
                    // direct finger enrollment
                    ProcessEnrollment(Sample);
                else if (!UseIdentityProcessing)
                    // use verification method
                    ProcessVerification(Sample);
                else if (UseIdentityProcessing)
                    // use the ID identification method
                    ProcessIdentification(Sample);
            }

            public void OnFingerGone(object Capture, string ReaderSerialNumber)
            {
                MakeReport("The finger was removed from the fingerprint reader.");
            }

            public void OnFingerTouch(object Capture, string ReaderSerialNumber)
            {
                MakeReport("The fingerprint reader was touched.");
            }

            public void OnReaderConnect(object Capture, string ReaderSerialNumber)
            {
                MakeReport("The fingerprint reader was connected and started.");
                _ScannerConnected = true;
            }

            public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
            {
                MakeReport("The fingerprint reader was disconnected.");
                _ScannerConnected = false;
            }

            public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
            {
                if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                    MakeReport("The quality of the fingerprint sample is good.");
                else
                    MakeReport("The quality of the fingerprint sample is poor.");
            }

            private void _SetStatus(dynamic status)
            {
                if (StatusLine != null)
                    StatusLine.Text = status;
            }

            protected void SetPrompt(string text)
            {
                frm.Invoke(new FunctionCall(_SetPrompt), text);
            }

            private void _SetPrompt(dynamic text)
            {
                if (prompt != null)
                    prompt.Text = text;
            }

            protected void MakeReport(string status)
            {
                frm.Invoke(new FunctionCall(_MakeReport), status);
            }

            private void _MakeReport(dynamic status)
            {
                if (StatusText != null)
                    StatusText.AppendText(status.ToString() + Strings.Chr(13) + Strings.Chr(10));
            }

            protected void DrawPicture(object bmp)
            {
                frm.Invoke(new FunctionCall(_DrawPicture), bmp);
            }

            private void _DrawPicture(dynamic bmp)
            {
                Picture.Image = new Bitmap(bmp, Picture.Size);
            }

            protected void SetStatus(string status)
            {
                frm.Invoke(new FunctionCall(_SetStatus), status);
            }

            public void StartCapture()
            {
                if ((Capturer != null))
                {
                    try
                    {
                        Capturer.StartCapture();
                        SetPrompt("Using the fingerprint reader, scan your fingerprint.");
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            logger.WriteLog(ex);
                        }
                        catch (Exception exx)
                        {
                        }
                        SetPrompt("Can't initiate capture!");
                    }
                }
            }

            public void StopCapture()
            {
                if (Capturer != null)
                {
                    try
                    {
                        Capturer.StopCapture();
                        MakeReport("The fingerprint reader was stopped");
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            logger.WriteLog(ex);
                        }
                        catch (Exception exx)
                        {
                        }
                        SetPrompt("Can't terminate capture!");
                    }
                }
            }


            public void ProcessEnrollment(DPFP.Sample Sample)
            {
                try
                {
                    Process(Sample);

                    // Process the sample and create a feature set for the enrollment purpose.
                    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

                    // Check quality of the sample and add to enroller if it's good
                    if (features != null)
                    {
                        try
                        {
                            if (Enroller.FeaturesNeeded > 1)
                                MakeReport($"Feature set was created, remaining: {Enroller.FeaturesNeeded - 1}");
                            else
                                MakeReport("Feature set was created");

                            Enroller.AddFeatures(features);              // Add feature set to template.

                            // ////////////////
                            UpdateStatus();

                            // Check if template has been created.
                            switch (Enroller.TemplateStatus)
                            {
                            case DPFP.Processing.Enrollment.Status.Ready:        // Report success and stop capturing
                               {
                                        // RaiseEvent OnTemplate(Enroller.Template)
                                        // store to database <===check duplicate if required
                                        try
                                        {
                                            if (SearchDuplicate)
                                            {
                                                if (UseIdentityProcessing)
                                                    ProcessIdentification(Sample, false);
                                                else
                                                    ProcessVerification(Sample, false);
                                                if (IsRecognize)
                                                {
                                                    TransmittedMessage = "Duplicate Found With ID=" + RecordID;
                                                    return;
                                                }
                                            }
                                            Template = Enroller.Template;
                                            DPData.Database.Records.Add(_FingerID, Template, ConvertToByteArray(TrueBitmap), FingerTable, Dpi);
                                            SetPrompt("Click Close, and then click Fingerprint Verification.");
                                            StopCapture();

                                            TransmittedMessage = "Enrollment Succeeded";
                                        }
                                        catch (Exception ex)
                                        {
                                            try
                                            {
                                                logger.WriteLog(ex);
                                            }
                                            catch (Exception exx)
                                            {
                                            }
                                        }
                                        finally
                                        {
                                            Enroller = null;
                                            Enroller = new DPFP.Processing.Enrollment();         // Create an enrollment.
                                            MakeReport(Constants.vbNewLine + "New Enrollment");
                                        }

                                        break;
                                    }

                            case DPFP.Processing.Enrollment.Status.Failed:     // Report failure and restart capturing
                            {
                                        Enroller.Clear();
                                        StopCapture();
                                        TransmittedMessage = "Enrollment Failed";
                                        // RaiseEvent OnTemplate(Nothing)
                                        StartCapture();
                                        Enroller = null;
                                        Enroller = new DPFP.Processing.Enrollment();          // Create an enrollment.
                                        break;
                                    }
                            }
                        }
                        finally
                        {
                        }
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    TMsgBox(ex.Message, MsgBoxStyle.Exclamation);
                }
            }

            public void ProcessEnrollmentAsBitmap(DPFP.Sample Sample)
            {
                try
                {
                    // Process the sample and create a feature set for the enrollment purpose.
                    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

                    // Check quality of the sample before sending the bitmap
                    if (features != null)
                    {
                        TrueBitmap = ConvertSampleToBitmap(Sample);
                        // Template = ConvertSampleAsTemplate(Sample)
                        TransmittedMessage = "New Finger";
                    }
                    else
                        TransmittedMessage = "Low Fingerprints Quality Encountered, Please Retry";
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    TMsgBox(ex.Message, MsgBoxStyle.Exclamation);
                }
            }

            public void ProcessFingerPrintsForEnrollmentFromBitmap(short VertDpi = 700, short HorDpi = 700)
            {
                Bitmap BmpOperate = new Bitmap(TrueBitmap, TrueBitmap.Width, TrueBitmap.Height);
                try
                {
                    // convert bitmap to template and save to database having known it is unique------------------ 
                    if (SearchDuplicate)
                    {
                        // convert bmp to sample and verify uniqueness
                        DPsample = ConvertRawBmpAsSample(BmpOperate, VertDpi, HorDpi);
                        // check for duplicate
                        if (UseIdentityProcessing)
                            ProcessIdentification(DPsample, false);
                        else
                            ProcessVerification(DPsample, false);
                        if (IsRecognize)
                        {
                            TransmittedMessage = "Duplicate Found With ID=" + RecordID;
                            return;
                        }
                        // convert and save directly
                        Template = ConvertSampleAsTemplate(DPsample);
                        if (Template != null)
                        {
                            // add to db
                            DPData.Database.Records.Add(_FingerID, Template, ConvertToByteArray(BmpOperate), FingerTable, Dpi);
                            TransmittedMessage = "Enrollment Succeeded";
                        }
                        else
                        {
                            TransmittedMessage = "Valid Fingerprints Quality Not Found";
                            throw new Exception("Error Reading Valid Fingerprints");
                        }
                    }
                    else
                    {
                        // convert and save directly
                        Template = ConvertRawBmpAsTemplate(TrueBitmap, VertDpi, HorDpi);
                        if (Template != null)
                        {
                            // add to db
                            DPData.Database.Records.Add(_FingerID, Template, ConvertToByteArray(BmpOperate), FingerTable, Dpi);
                            TransmittedMessage = "Enrollment Succeeded";
                        }
                        else
                        {
                            TransmittedMessage = "Valid Fingerprints Quality Not Found";
                            throw new Exception("Error Reading Valid Fingerprints");
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
            }

            public class ReturnedFinger
            {
                public string FingerID;
                public byte[] Features;
                public byte[] Picture;
                public byte[] ANSIFeatures;
                public byte[] ISOFeatures;
            }

            public ReturnedFinger ProcessFingerPrintsForEnrollmentFromBitmapData(short VertDpi = 700, short HorDpi = 700)
            {
                Bitmap BmpOperate = new Bitmap(TrueBitmap, TrueBitmap.Width, TrueBitmap.Height);
                try
                {
                    // convert bitmap to template and save to database having known it is unique------------------ 
                    if (SearchDuplicate)
                    {
                        // convert bmp to sample and verify uniqueness
                        DPsample = ConvertRawBmpAsSample(BmpOperate, VertDpi, HorDpi);
                        // check for duplicate
                        if (UseIdentityProcessing)
                            ProcessIdentification(DPsample, false);
                        else
                            ProcessVerification(DPsample, false);
                        if (IsRecognize)
                        {
                            TransmittedMessage = "Duplicate Found With ID=" + RecordID;
                            return null;
                        }
                        // convert and save directly
                        Template = ConvertSampleAsTemplate(DPsample);

                        if (Template != null)
                        {
                            // 'add to db
                            // DPData.Database.Records.Add(_FingerID, Template,
                            // ConvertToByteArray(BmpOperate),
                            // FingerTable, Dpi)

                            TransmittedMessage = "Enrollment Succeeded";

                            return new ReturnedFinger() { FingerID = _FingerID, Features = Template.Bytes, Picture = ConvertToByteArray(BmpOperate), ANSIFeatures = ConvertRawBmpAsANSITemplate(BmpOperate), ISOFeatures = ConvertRawBmpAsISOTemplate(BmpOperate) };
                        }
                        else
                        {
                            TransmittedMessage = "Valid Fingerprints Quality Not Found";
                            throw new Exception("Error Reading Valid Fingerprints");
                        }
                    }
                    else
                    {
                        // convert and save directly
                        Template = ConvertRawBmpAsTemplate(TrueBitmap, VertDpi, HorDpi);
                        if (Template != null)
                        {
                            // add to db
                            // DPData.Database.Records.Add(_FingerID, Template,
                            // ConvertToByteArray(BmpOperate),
                            // FingerTable, Dpi)
                            TransmittedMessage = "Enrollment Succeeded";

                            return new ReturnedFinger() { FingerID = _FingerID, Features = Template.Bytes, Picture = ConvertToByteArray(BmpOperate), ANSIFeatures = ConvertRawBmpAsANSITemplate(BmpOperate), ISOFeatures = ConvertRawBmpAsISOTemplate(BmpOperate) };
                        }
                        else
                        {
                            TransmittedMessage = "Valid Fingerprints Quality Not Found";
                            throw new Exception("Error Reading Valid Fingerprints");
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
            }
            public void AddUserToCollection(DPFP.ID.User Usr)
            {
                try
                {
                    if (UseIdentityProcessing)
                    {
                        Int16 FingerPosition = 0;
                        if (Usr == null | !Usr.TemplateExists((DPFP.ID.FingerPosition)FingerPosition))
                            throw new Exception("Valid User Biometrics Collection Required");

                        DPData.Database.Records.UserCollections.AddUser(ref Usr);
                    }
                    else
                        throw new Exception("Valid for Identification Mode Only");
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
            }


            public void ProcessVerification(DPFP.Sample Sample, bool ShowReport = true)
            {
                try
                {
                    Process(Sample);

                    // Process the sample and create a feature set for the enrollment purpose.
                    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                    Stopwatch sw = new Stopwatch();
                    // Check quality of the sample and start verification if it's good
                    if (features != null)
                    {
                        // loads the collection
                        IEnumerable<Record> recordEnumerable;
                        recordEnumerable = DPData.Database.Records;

                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        // If Verificator Is Nothing Then
                        // Verificator = New DPFP.Verification.Verification()
                        // End If

                        // timer for current comparison 
                        sw.Start();

                        foreach (Record record in recordEnumerable)
                        {
                            // Compare the feature set with our template' former method  Verificator.Verify(features, record.Template, result)

                            result = DPFP.Verification.Verification.Verify(features, record.Template, 0x7FFFFFFF / 100000);
                            // UpdateStatus(result.FARAchieved)

                            if (result.Verified)
                            {
                                Recognize = true;
                                // set recordid after detection
                                RecordID = record.ID;
                                break;
                            }
                            else
                                Recognize = false;
                        }
                        sw.Stop();

                        if (ShowReport)
                        {
                            if (result.Verified)
                            {
                                TransmittedMessage = "Record Was Identified";
                                MakeReport("The fingerprint was IDENTIFIED in " + TimeToString(sw.Elapsed));
                            }
                            else
                            {
                                TransmittedMessage = "Record Was Not Identified";
                                MakeReport("The fingerprint was NOT RECOGNIZED. Process took: " + TimeToString(sw.Elapsed));
                            }
                        }
                        sw.Stop();
                    }
                    else
                        throw new Exception("Fingerprint is of low quality");
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    TransmittedMessage = ex.Message;
                }
            }
            public void ProcessIdentification(DPFP.Sample Sample, bool ShowReport = true)
            {
                try
                {
                    Process(Sample);
                    Stopwatch sw = new Stopwatch();
                    // Process the sample and create a feature set for the enrollment purpose.
                    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
                    // -----------------------------------------processing -------------------------------
                    // Check quality of the sample and start verification if it's good
                    if (features != null)
                    {
                        sw.Start(); // stsrt timer

                        // 'identification on user collection
                        int One = 0x7FFFFFFF;
                    var userCollection = DPData.Database.RecordsWithIdentity;
                        DPFP.ID.Identification IDentify = new DPFP.ID.Identification(ref userCollection, Convert.ToUInt32(One / 2000));
                        DPFP.ID.CandidateIDList CandidateIDList = IDentify.Identify(features);
                        if (CandidateIDList.Count > 0)
                        {
                            Recognize = true;
                            // set recordid after detection
                            RecordID = CandidateIDList.First().ToString();
                        }
                        else
                            Recognize = false;

                        sw.Stop();
                        if (ShowReport)
                        {
                            if (Recognize)
                            {
                                TransmittedMessage = "Record Was Identified";
                                MakeReport("The fingerprint was IDENTIFIED in " + TimeToString(sw.Elapsed));
                            }
                            else
                            {
                                TransmittedMessage = "Record Was Not Identified";
                                MakeReport("The fingerprint was NOT RECOGNIZED. Process took: " + TimeToString(sw.Elapsed));
                            }
                        }
                    }
                    else
                        throw new Exception("Fingerprint is of low quality");
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    TransmittedMessage = ex.Message;
                }
            }

            public static string TimeToString(TimeSpan time)
            {
                long t = time.Ticks/10;
                string value;
                long remm;
                t = Math.DivRem(t, 1000, out remm);
                value = remm.ToString() + " mks";
                if (t != 0)
                {
                    t = Math.DivRem(t, 1000, out remm);
                    value = remm.ToString() + " ms " + value;
                    if (t != 0)
                    {
                        t = Math.DivRem(t, 60, out remm);
                        value = remm.ToString() + " s " + value;
                        if (t != 0)
                        {
                            t = Math.DivRem(t, 60, out remm);
                            value = remm.ToString() + " m " + value;
                            if (t != 0)
                            {
                                t = Math.DivRem(t, 24, out remm);
                                value = remm.ToString() + " h " + value;
                                if (t != 0)
                                    value = t + " d " + value;
                            }
                        }
                    }
                }
                return value;
            }

            public void UpdateStatus(int FAR = 0)
            {
                // Show number of samples needed.
                if (EnrollmentMode)
                    SetStatus(string.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded));
                else
                    SetStatus(string.Format("False Accept Rate (FAR) = {0}", FAR));
            }
            public bool DeleteFingerByID(string ID)
            {
                try
                {
                System.Data.SqlClient.SqlConnection sqlcon = new System.Data.SqlClient.SqlConnection(ConnectionString);
                    DPData.Database.Records.ClearByID(ID, FingerTable, sqlcon);
                    return true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
            }

            public DataTable GetFingerprintsByID(string ID)
            {
                try
                {
                System.Data.SqlClient.SqlConnection sqlcon = new System.Data.SqlClient.SqlConnection();
                    sqlcon.ConnectionString = ConnectionString;

                    return DPData.Database.Records.GetFingerByID(ID, sqlcon, FingerTable);
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
            }

            public bool HasFinger(string ID)
            {
                try
                {
                System.Data.SqlClient.SqlConnection sqlcon = new System.Data.SqlClient.SqlConnection();
                    sqlcon.ConnectionString = ConnectionString;

                    return DPData.Database.Records.HasFinger(ID, sqlcon, FingerTable);
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    return false;
                }
            }

            // enrollfrompicture and verifyfrompicture

            // loadrecordsbyID , deleterecordbyid


            private bool disposedValue = false;        // To detect redundant calls

            // IDisposable
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: free other state (managed objects).
                        StopCapture();
                        DPData.Database.Dispose();
                        Picture = null;
                    }
                }
                this.disposedValue = true;
            }

            // This code added by Visual Basic to correctly implement the disposable pattern.
            public void Dispose()
            {
                // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
                Dispose(true);
                GC.SuppressFinalize(this);
            }


            private DPFP.Sample DPsample;
            private DPFP.FeatureSet DPFeatures;
            private DPFP.Template DPTemplate;
            private byte[] ISOFMD;
            private Byte[] inputData = null;
            private DigitalPersona.Standards.InputParameterForRaw inpRaw = null/* TODO Change to default(_) if this is not a reference type */;
            public static Bitmap EncodeBitmap(Bitmap Bmp, Int16 HorResolution = 500, Int16 VertResolution = 500)
            {
                try
                {
                    Bitmap OutputBmp;
                    if (Bmp != null)
                    {
                        OutputBmp = Bmp;
                        OutputBmp.SetResolution(HorResolution, VertResolution);
                        return OutputBmp;
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
                finally
                {
                }
                return null/* TODO Change to default(_) if this is not a reference type */;
            }

            /// <summary>
            ///     ''' Converts raw fingerprints bitmap as DP Template
            ///     ''' </summary>
            ///     ''' <param name="RawBmp">Raw fingerprints bitmap</param>
            ///     ''' <param name="VertDpi">Vertical Resolution</param>
            ///     ''' <param name="HorDpi">Horizontal Resolution</param>
            ///     ''' <returns>DPFP.Template</returns>
            ///     ''' <remarks></remarks>
            public DPFP.Template ConvertRawBmpAsTemplate(Bitmap RawBmp, short VertDpi = 700, short HorDpi = 700)
            {
                VariantConverter VConverter;
                Enroller = new DPFP.Processing.Enrollment();
                RawBmp = EncodeBitmap(RawBmp, VertDpi, HorDpi);
                try
                {
                    // converts raw image to dpSample using DFC 2.0---------------------------------------
                    // encode the bmp variable using the bitmap Loader
                    BitmapLoader BmpLoader = new BitmapLoader(RawBmp, Convert.ToInt16(RawBmp.HorizontalResolution), Convert.ToInt16(RawBmp.VerticalResolution));
                    BmpLoader.ProcessBitmap();
                    // return the required result
                    inputData = BmpLoader.RawData;
                    inpRaw = BmpLoader.DPInputParam;
                    // dispose the object
                    BmpLoader.Dispose();

                    // start the conversion process
                    VConverter = new VariantConverter(VariantConverter.OutputType.dp_sample, DataType.RawSample, inpRaw, inputData, false);
                    MemoryStream DStream = new MemoryStream(VConverter.Convert());
                    DPsample = new DPFP.Sample(DStream);
                    // DPsample = DirectCast(VConverter.Convert(), DPFP.Sample)

                    // converts dpSample to DPFeatures using the OTW'''''''''''''''''''''''''''''''''''''''
                    DPFeatures = ExtractFeatures(DPsample, DPFP.Processing.DataPurpose.Enrollment);
                    // ==========================================================================
                    // convert DPfeatures to ISO FMD using the DFC 2.0'''''''''''''''''''''''''''''''''''''''  
                    byte[] SerializedFeatures = null;
                    DPFeatures.Serialize(ref SerializedFeatures); // serialized features into the array of bytes
                    ISOFMD = DigitalPersona.Standards.Converter.Convert(SerializedFeatures, DigitalPersona.Standards.DataType.DPFeatureSet, DataType.ISOFeatureSet);

                    // convert ISO FMD to DPTemplate using DFC 2.0'''''''''''''''''''''''''''''''''''''''
                    byte[] DPTemplateData = DigitalPersona.Standards.Converter.Convert(ISOFMD, DigitalPersona.Standards.DataType.ISOTemplate, DataType.DPTemplate);
                    // deserialize data to Template
                    DPTemplate = new DPFP.Template();
                    DPTemplate.DeSerialize(DPTemplateData); // required for database purpose
                                                            // ============================================================================ 
                    DStream.Close();
                    return DPTemplate;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    return null/* TODO Change to default(_) if this is not a reference type */;
                }
            }

            private byte[] ConvertRawBmpAsTemplateData(Bitmap RawBmp, short VertDpi = 700, short HorDpi = 700)
            {
                VariantConverter VConverter;
                Enroller = new DPFP.Processing.Enrollment();
                RawBmp = EncodeBitmap(RawBmp, VertDpi, HorDpi);
                try
                {
                    // converts raw image to dpSample using DFC 2.0---------------------------------------
                    // encode the bmp variable using the bitmap Loader
                    BitmapLoader BmpLoader = new BitmapLoader(RawBmp, Convert.ToInt16(RawBmp.HorizontalResolution), Convert.ToInt16(RawBmp.VerticalResolution));
                    BmpLoader.ProcessBitmap();
                    // return the required result
                    inputData = BmpLoader.RawData;
                    inpRaw = BmpLoader.DPInputParam;
                    // dispose the object
                    BmpLoader.Dispose();

                    // start the conversion process
                    VConverter = new VariantConverter(VariantConverter.OutputType.dp_sample, DataType.RawSample, inpRaw, inputData, false);
                    MemoryStream DStream = new MemoryStream(VConverter.Convert());
                    DPsample = new DPFP.Sample(DStream);
                    // DPsample = DirectCast(VConverter.Convert(), DPFP.Sample)

                    // converts dpSample to DPFeatures using the OTW'''''''''''''''''''''''''''''''''''''''
                    DPFeatures = ExtractFeatures(DPsample, DPFP.Processing.DataPurpose.Enrollment);
                    // ==========================================================================
                    // convert DPfeatures to ISO FMD using the DFC 2.0'''''''''''''''''''''''''''''''''''''''  
                    byte[] SerializedFeatures = null;
                    DPFeatures.Serialize(ref SerializedFeatures); // serialized features into the array of bytes
                    ISOFMD = DigitalPersona.Standards.Converter.Convert(SerializedFeatures, DigitalPersona.Standards.DataType.DPFeatureSet, DataType.ISOFeatureSet);

                    // convert ISO FMD to DPTemplate using DFC 2.0'''''''''''''''''''''''''''''''''''''''
                    byte[] DPTemplateData = DigitalPersona.Standards.Converter.Convert(ISOFMD, DigitalPersona.Standards.DataType.ISOTemplate, DataType.DPTemplate);

                    return DPTemplateData;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    return null;
                }
            }

            private Sample ConvertRawBmpAsSample(Bitmap RawBmp, short VertDpi = 700, short HorDpi = 700)
            {
                VariantConverter VConverter;
                Enroller = new DPFP.Processing.Enrollment();
                RawBmp = EncodeBitmap(RawBmp, VertDpi, HorDpi);
                try
                {
                    // converts raw image to dpSample using DFC 2.0---------------------------------------
                    // encode the bmp variable using the bitmap Loader
                    BitmapLoader BmpLoader = new BitmapLoader(RawBmp, Convert.ToInt16(RawBmp.HorizontalResolution), Convert.ToInt16(RawBmp.VerticalResolution));
                    BmpLoader.ProcessBitmap();
                    // return the required result
                    inputData = BmpLoader.RawData;
                    inpRaw = BmpLoader.DPInputParam;
                    // dispose the object
                    BmpLoader.Dispose();

                    // start the conversion process
                    VConverter = new VariantConverter(VariantConverter.OutputType.dp_sample, DataType.RawSample, inpRaw, inputData, false);
                    MemoryStream DStream = new MemoryStream(VConverter.Convert());
                    DPsample = new DPFP.Sample(DStream);
                    return DPsample;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    return null/* TODO Change to default(_) if this is not a reference type */;
                }
            }

            /// <summary>
            ///     ''' Converts  DP Sample to DP Template
            ///     ''' </summary>
            ///     ''' <param name="Sample">DP Sample object</param>
            ///     ''' <returns>DP Template</returns>
            ///     ''' <remarks></remarks>
            public Template ConvertSampleAsTemplate(Sample Sample)
            {
                Enroller = new DPFP.Processing.Enrollment();
                try
                {
                    // converts dpSample to DPFeatures using the OTW'''''''''''''''''''''''''''''''''''''''
                    DPFeatures = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
                    // ==========================================================================
                    // convert DPfeatures to ISO FMD using the DFC 2.0'''''''''''''''''''''''''''''''''''''''  
                    byte[] SerializedFeatures = null;
                    DPFeatures.Serialize(ref SerializedFeatures); // serialized features into the array of bytes
                    ISOFMD = DigitalPersona.Standards.Converter.Convert(SerializedFeatures, DigitalPersona.Standards.DataType.DPFeatureSet, DataType.ISOFeatureSet);

                    // convert ISO FMD to DPTemplate using DFC 2.0'''''''''''''''''''''''''''''''''''''''
                    byte[] DPTemplateData = DigitalPersona.Standards.Converter.Convert(ISOFMD, DigitalPersona.Standards.DataType.ISOTemplate, DataType.DPTemplate);
                    // deserialize data to Template
                    DPTemplate = new DPFP.Template();
                    DPTemplate.DeSerialize(DPTemplateData); // required for database purpose
                                                            // ============================================================================ 

                    return DPTemplate;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    return null/* TODO Change to default(_) if this is not a reference type */;
                }
            }

            /// <summary>
            ///     ''' Converts ISO Template Binary to DP Template
            ///     ''' </summary>
            ///     ''' <param name="ISOTemplate">ISO Template Binary</param>
            ///     ''' <returns>DP Template</returns>
            ///     ''' <remarks></remarks>
            public Template ConvertISOTemplateAsDPTemplate(byte[] ISOTemplate)
            {
                try
                {
                    // Dim OutputParamANSIandISO As New OutputParameterForConvertSample  With {.rotation = 128}

                    byte[] DPTemplateData = DigitalPersona.Standards.Converter.Convert(ISOTemplate, DigitalPersona.Standards.DataType.ISOTemplate, DataType.DPTemplate);
                    // deserialize data to Template
                    DPTemplate = new DPFP.Template();
                    DPTemplate.DeSerialize(DPTemplateData); // required for database purpose
                    return DPTemplate;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    return null/* TODO Change to default(_) if this is not a reference type */;
                }
            }

            /// <summary>
            ///     ''' Converts ANSI Template Binary to DP Template
            ///     ''' </summary>
            ///     ''' <param name="ANSITemplate">ANSI Template Binary</param>
            ///     ''' <returns>DP Template</returns>
            ///     ''' <remarks></remarks>
            public Template ConvertANSITemplateAsDPTemplate(byte[] ANSITemplate)
            {
                try
                {
                    // Dim OutputParamANSIandISO As New OutputParameterForConvertSample  With {.rotation = 128}

                    byte[] DPTemplateData = DigitalPersona.Standards.Converter.Convert(ANSITemplate, DigitalPersona.Standards.DataType.ANSITemplate, DataType.DPTemplate);
                    // deserialize data to Template
                    DPTemplate = new DPFP.Template();
                    DPTemplate.DeSerialize(DPTemplateData); // required for database purpose
                    return DPTemplate;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    return null/* TODO Change to default(_) if this is not a reference type */;
                }
            }

            /// <summary>
            ///     ''' Returns binary of ISO Template
            ///     ''' </summary>
            ///     ''' <param name="RawBmp">Raw fingerprints bitmap</param>
            ///     ''' <param name="VertDpi">Vertical Resolution</param>
            ///     ''' <param name="HorDpi">Horizontal Resolution</param>
            ///     ''' <returns></returns>
            ///     ''' <remarks></remarks>
            public byte[] ConvertRawBmpAsISOTemplate(Bitmap RawBmp, short VertDpi = 700, short HorDpi = 700)
            {
                try
                {
                    Template DPTemplate = ConvertRawBmpAsTemplate(RawBmp, VertDpi, HorDpi);
                    OutputParameterForIsoAndAnsi OutputParamANSIandISO = new OutputParameterForIsoAndAnsi() { rotation = 128 };

                    byte[] ISOTemplate = DigitalPersona.Standards.Converter.Convert(DPTemplate.Bytes, DigitalPersona.Standards.DataType.DPTemplate, DataType.ISOTemplate, OutputParamANSIandISO);
                    return ISOTemplate;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    return null;
                }
            }

            /// <summary>
            ///     ''' Returns binary of ANSI Template
            ///     ''' </summary>
            ///     ''' <param name="RawBmp">Raw fingerprints bitmap</param>
            ///     ''' <param name="VertDpi">Vertical Resolution</param>
            ///     ''' <param name="HorDpi">Horizontal Resolution</param>
            ///     ''' <returns></returns>
            ///     ''' <remarks></remarks>
            public byte[] ConvertRawBmpAsANSITemplate(Bitmap RawBmp, short VertDpi = 700, short HorDpi = 700)
            {
                try
                {
                    Template DPTemplate = ConvertRawBmpAsTemplate(RawBmp, VertDpi, HorDpi);
                    OutputParameterForIsoAndAnsi OutputParamANSIandISO = new OutputParameterForIsoAndAnsi() { rotation = 128 };

                    byte[] ANSITemplate = DigitalPersona.Standards.Converter.Convert(DPTemplate.Bytes, DigitalPersona.Standards.DataType.DPTemplate, DataType.ANSITemplate, OutputParamANSIandISO);
                    return ANSITemplate;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    return null;
                }
            }
        }

        public class VariantConverter
        {
            private DPFP.Capture.ReadersCollection dpSensorCollection = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.Capture.Capture dpSensorCapturer = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.Capture.SampleConversion dpImageConverter = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.Processing.FeatureExtraction dpFtrExtractor = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.Processing.Enrollment dpFtrEnroller = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.Template dpTemplate = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.FeatureSet dpFeatureSet = null/* TODO Change to default(_) if this is not a reference type */;
            private Byte[] inputData = null;
            private DigitalPersona.Standards.InputParameterForRaw inpRaw = null/* TODO Change to default(_) if this is not a reference type */;
            private DigitalPersona.Standards.DataType dataType = DigitalPersona.Standards.DataType.DPTemplate;
            private OutputType cbOutputType;
            private bool WriteOutputToFile;
            public enum OutputType
            {
                dp_sample,
                dp_tmpl,
                dp_ftr,
                ansi_sample,
                ansi_ftr,
                ansi_tmplX,
                iso_sample,
                iso_ftr,
                iso_tmpl,
                iso_tmplX
            }

            public VariantConverter(OutputType Output, DigitalPersona.Standards.DataType _dataType, DigitalPersona.Standards.InputParameterForRaw _inpRaw, byte[] _inputData, bool _WriteOutputToFile = false)
            {
                try
                {
                    cbOutputType = Output;
                    dataType = _dataType;
                    inpRaw = _inpRaw;
                    inputData = _inputData;
                    WriteOutputToFile = _WriteOutputToFile;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                }
            }

            public byte[] Convert()
            {
                string ext = null;
                // holds the file extension
                DigitalPersona.Standards.DataType outputType = DigitalPersona.Standards.DataType.DPTemplate;
                switch (cbOutputType)
                {
                    case VariantConverter.OutputType.dp_sample:
                        {
                            // DP Sample
                            ext = "dp_sample";
                            outputType = DigitalPersona.Standards.DataType.DpSample;
                            break;
                        }

                    case VariantConverter.OutputType.dp_tmpl:
                        {
                            // DP Template
                            ext = "dp_tmpl";
                            outputType = DigitalPersona.Standards.DataType.DPTemplate;
                            break;
                            break;
                        }

                    case VariantConverter.OutputType.dp_ftr:
                        {
                            // DP Feature Set
                            ext = "dp_ftr";
                            outputType = DigitalPersona.Standards.DataType.DPFeatureSet;
                            break;
                        }

                    case VariantConverter.OutputType.ansi_sample:
                        {
                            // ANSI Sample
                            ext = "ansi_sample";
                            outputType = DigitalPersona.Standards.DataType.ANSISample;
                            break;
                        }

                    case VariantConverter.OutputType.ansi_ftr:
                        {
                            // ANSI Feature Set
                            ext = "ansi_ftr";
                            outputType = DigitalPersona.Standards.DataType.ANSIFeatureSet;
                            break;
                        }

                    //case VariantConverter.OutputType.ansi:
                    //    {
                    //        // ANSI Template
                    //        ext = "ansi_tmpl";
                    //        outputType = DigitalPersona.Standards.DataType.ANSITemplate;
                    //        break;
                    //    }

                    case VariantConverter.OutputType.ansi_tmplX:
                        {
                            // ANSI Template Extended
                            ext = "ansi_tmplX";
                            outputType = DigitalPersona.Standards.DataType.ANSITemplateWithExtendedData;
                            break;
                        }

                    case VariantConverter.OutputType.iso_sample:
                        {
                            // ISO Sample
                            ext = "iso_sample";
                            outputType = DigitalPersona.Standards.DataType.ISOSample;
                            break;
                        }

                    case VariantConverter.OutputType.iso_ftr:
                        {
                            // ISO Feature Set
                            ext = "iso_ftr";
                            outputType = DigitalPersona.Standards.DataType.ISOFeatureSet;
                            break;
                        }

                    case VariantConverter.OutputType.iso_tmpl:
                        {
                            // ISO Template
                            ext = "iso_tmpl";
                            outputType = DigitalPersona.Standards.DataType.ISOTemplate;
                            break;
                        }

                    case VariantConverter.OutputType.iso_tmplX:
                        {
                            // ISO Template Extended
                            ext = "iso_tmplX";
                            outputType = DigitalPersona.Standards.DataType.ISOTemplateWithExtendedData;
                            break;
                        }
                }

                byte[] dataToFile = null;

                try
                {
                    if (dataType == DigitalPersona.Standards.DataType.RawSample)
                    {
                        if (outputType != DigitalPersona.Standards.DataType.ISOSample && outputType != DigitalPersona.Standards.DataType.ANSISample && outputType != DigitalPersona.Standards.DataType.DpSample)
                        {
                            MessageBox.Show("You can only convert a raw sample to another sample format.  Please select an appropriate output type.");
                            return null;
                        }
                        Object outParameter = null;

                        dataToFile = DigitalPersona.Standards.Converter.Convert(inputData, dataType, inpRaw, outputType, outParameter);
                    }
                    else
                        dataToFile = DigitalPersona.Standards.Converter.Convert(inputData, dataType, outputType);
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    MessageBox.Show(ex.Message + " inner: " + ex.InnerException.Message);
                    return null;
                }

                if (WriteOutputToFile)
                {
                    SaveFileDialog dlgSave = new SaveFileDialog();

                    dlgSave.Filter = "Biometric File| *." + ext;
                    dlgSave.Title = "Save Biometric Data";

                    if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        return null;

                    String fileName = dlgSave.FileName;

                    FileStream fsOut = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                    BinaryWriter writer = new BinaryWriter(fsOut);
                    writer.Write(dataToFile);
                    writer.Close();
                    fsOut.Close();
                    MessageBox.Show("Successfully Saved File" + Constants.vbLf + dlgSave.FileName);
                }

                return dataToFile;
            }
        }

        public class BitmapLoader : Form
        {
            private DigitalPersona.Standards.InputParameterForRaw inpRaw;
            private byte[] m_rawData;
            private String filename;
            private Bitmap bmp = null/* TODO Change to default(_) if this is not a reference type */;
            private PictureBox pbBitmap = new PictureBox();
            private int tbXdpi, tbYdpi;
            public BitmapLoader()
            {
            }

            public BitmapLoader(Bitmap Rawbmp, int _tbXdpi, int _tbYdpi)
            {
                try
                {
                    bmp = Rawbmp;
                    pbBitmap = new PictureBox();
                    pbBitmap.Size = new Size(152, 200);
                    tbXdpi = _tbXdpi;
                    tbYdpi = _tbYdpi;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    MessageBox.Show("Error opening bitmap file: " + ex.Message);
                    return;
                }
                try
                {
                    Bitmap resizedBMP = new Bitmap(pbBitmap.Width, pbBitmap.Height);
                    Graphics g = Graphics.FromImage((Image)resizedBMP);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
                    g.DrawImage(bmp, 0, 0, resizedBMP.Width, resizedBMP.Height);
                    pbBitmap.Image = resizedBMP;
                    g.Dispose();
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
            }

            public byte[] RawData
            {
                get
                {
                    return m_rawData;
                }
            }

            public DigitalPersona.Standards.InputParameterForRaw DPInputParam
            {
                get
                {
                    return inpRaw;
                }
            }

            public void ProcessBitmap()
            {
                int width = 0;
                int height = 0;
                int dpiX = 0;
                int dpiY = 0;
                int bpp = 0;


                try
                {
                    dpiX = Convert.ToInt32(tbXdpi);
                    dpiY = Convert.ToInt32(tbYdpi);

                    width = bmp.Width;
                    height = bmp.Height;
                    System.Drawing.Imaging.BitmapData bmpData;

                    Rectangle rect = new Rectangle(0, 0, width, height);

                    switch (bmp.PixelFormat)
                    {
                        case System.Drawing.Imaging.PixelFormat.Format8bppIndexed:
                            {
                                m_rawData = new byte[width * height - 1 + 1];
                                // what about padding?
                                bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
                                Marshal.Copy(bmpData.Scan0, m_rawData, 0, width * height);
                                bmp.UnlockBits(bmpData);
                                inpRaw = new DigitalPersona.Standards.InputParameterForRaw(width, height, dpiX, dpiY, 8);
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                break;
                            }

                        case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
                            {
                                m_rawData = new byte[width * height - 1 + 1];
                                bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
                                for (int y = 0; y <= height - 1; y++)
                                {
                                    for (int x = 0; x <= width - 1; x++)
                                    {
                                        // Calculate greyscale based on average RGB intensity
                                        int i = x * 3 + y * bmpData.Stride;
                                        int Dividend = Marshal.ReadByte(bmpData.Scan0, i);
                                        int Dividend2 = Marshal.ReadByte(bmpData.Scan0, i + 1);
                                        int Dividend3 = Marshal.ReadByte(bmpData.Scan0, i + 2);

                                        int avg_val = (Dividend + Dividend2 + Dividend3) / 3;
                                        // Convert to byte and save gray scale data
                                        m_rawData[x + y * width] = System.Convert.ToByte(avg_val);
                                    }
                                }
                                // ----------------------------
                                bmp.UnlockBits(bmpData);
                                inpRaw = new DigitalPersona.Standards.InputParameterForRaw(width, height, dpiX, dpiY, 8);
                                break;
                            }

                        case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
                        case  System.Drawing.Imaging.PixelFormat.Format32bppRgb:
                            {
                                m_rawData = new byte[width * height - 1 + 1];
                                bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
                                for (int y = 0; y <= height - 1; y++)
                                {
                                    for (int x = 0; x <= width - 1; x++)
                                    {
                                        // Calculate greyscale based on average RGB intensity
                                        int i = x * 4 + y * bmpData.Stride;
                                        int Dividend = Marshal.ReadByte(bmpData.Scan0, i);
                                        int Dividend2 = Marshal.ReadByte(bmpData.Scan0, i + 1);
                                        int Dividend3 = Marshal.ReadByte(bmpData.Scan0, i + 2);

                                        int avg_val = (Dividend + Dividend2 + Dividend3) / 3;
                                        m_rawData[x + y * width] = System.Convert.ToByte(avg_val);
                                    }
                                }
                                // ----------------------------
                                bmp.UnlockBits(bmpData);
                                inpRaw = new DigitalPersona.Standards.InputParameterForRaw(width, height, dpiX, dpiY, 8);
                                break;
                            }

                        default:
                            {
                                MessageBox.Show("Bitmap format not supported.  Please convert to either 8bpp indexed or 24 bpp non-indexed");
                                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                break;
                            }
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            private void BitmapLoader_FormClosing(object sender, FormClosingEventArgs e)
            {
                bmp.Dispose();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    
}
