using AttendanceSystem.BaseClass;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP.Capture;
using DPFP;
using System.IO;
using AttendanceSystem.Repository;
using AttendanceSystem.Model;
using System.Threading;
using System.Globalization;
using static AttendanceSystem.BaseClass.ErrorLoggerBase;

namespace AttendanceSystem.Forms
{
    delegate void FunctionCall(dynamic param);
    public partial class FrmAttendance : MaterialForm, DPFP.Capture.EventHandler
    {
        private SessionSemesterRepo _semesterRepo;
        private AttendanceRepo _attendanceRepo;
        private StudentRepo _studentRepo;
        private BiometricsRepo _bioRepo;
        private SessionSemester activeSemester;
        private int courseId;
        private int StudentId;
        private StudentDetail studentDetail;

        public FrmAttendance(int courseId, string courseName)
        {
            if (LoggedInUser.UserId == 0)
            {
                FrmLogin login = new FrmLogin();
                login.Show();
            }

            InitializeComponent();
            MaterialSkinBase.InitializeForm(this);
            lblTodaysDate.Text = DateTime.Now.ToLongDateString();
            lblCourse.Text = courseName;
            lblUsername.Text = LoggedInUser.Fullname;

            _semesterRepo = new SessionSemesterRepo();
            _attendanceRepo = new AttendanceRepo();
            _studentRepo = new StudentRepo();
            _bioRepo = new BiometricsRepo();
            this.courseId = courseId;
        }

        public ISynchronizeInvoke IObj;
        public byte[] bmpByte;
        public Bitmap Resultbmp;
        public Bitmap Derivedbmp;
        private FileStream ImageStream;
        Bitmap FingerBmp;
        Image returnImage;
        // '---------------------------
        private DPFP.Capture.Capture Capturer = new DPFP.Capture.Capture();
        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Verification.Verification Verificator;
        private DPFP.Template Template;
        public event OnTemplateEventHandler OnTemplate;

        public delegate void OnTemplateEventHandler(object template);
        private DataTable dt, dt1;
        private string Message, MatricNumber = "";
        private Bitmap TrueBitmap = null/* TODO Change to default(_) if this is not a reference type */;
        private int Dpi = 700;
        Byte[] inputData = null;
        DigitalPersona.Standards.InputParameterForRaw inpRaw = null;
        DPFP.Sample DPsample;
        DPFP.FeatureSet DPFeatures;
        DPFP.Template DPTemplate;
        byte[] ISOFMD;
        DataGridViewRow row;
        String labelMessage; string session; string semester; int NoExpected;
        
        private void FrmAttendance_Load(object sender, EventArgs e)
        {
            try
            {
                activeSemester = _semesterRepo.GetActiveSessionSemester();
                if(activeSemester == null)
                {
                    MessageBox.Show("You cannot mark attendance because there is no active semester", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblSession.Text = activeSemester.Session + " - " + activeSemester.Semester;
                Cursor = Cursors.WaitCursor;
                // set culture
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB", false);

                Capturer = new DPFP.Capture.Capture();               // Create a capture operation.
                try
                {
                    if ((Capturer != null))
                    {
                        Capturer.StartCapture();
                        Capturer.EventHandler = this;
                    }
                    // Subscribe for capturing events.
                    else
                        throw new Exception("Can't initiate capture operation! Please exit and relaunch the application");
                }
                catch (Exception ex)
                {
                   logger.WriteLog(ex);                   
                   MessageBox.Show("Can't initiate capture operation! Please exit and relaunch the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Enroller = new DPFP.Processing.Enrollment();
                Verificator = new DPFP.Verification.Verification();
                Application.DoEvents();

                Capturer.StartCapture();
                SetPrompt("Using the fingerprint reader, scan your fingerprint.");
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                //MsgBox(ex.Message, MsgBoxStyle.Exclamation, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            
            getTodayAttendance();
        }

        private void getTodayAttendance()
        {
            try
            {
                var todayAttendance = _attendanceRepo.GetTodayAttendanceByCourse(courseId);               
                foreach (var item in todayAttendance)
                {

                    DataGridViewRow rw = (DataGridViewRow)gdvAttendance.Rows[0].Clone();
                    rw.Cells[0].Value = item.StudentName;
                    rw.Cells[1].Value = item.StudentMatricNo;
                    rw.Cells[2].Value = item.TimeIn;
                    gdvAttendance.Rows.Add(rw);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while getting today's attendance " + ex.Message + " inner exception: " + ex.InnerException.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            MakeReport("The " + getFingerType() + " fingerprint was captured.");
            Message = null;

            // use verification method
            Process(Sample);
            //check for saturdays and sundays and return if not saturday or sunday
            if (GetFingerPrints(FingerBmp))
            {
                int response = _attendanceRepo.SaveAttendance(courseId, StudentId, activeSemester.Id, LoggedInUser.UserId);
                if (response == 0)
                {
                    labelMessage = "You have already signed in";
                    lblMsg.Invoke(new Action(ShowMsg));
                }
                else if (response == 1)
                {
                    labelMessage = "You have signed in successfully. Welcome to class";
                    lblMsg.Invoke(new Action(LoadUI));
                }

                else
                {
                    labelMessage = "Sign in failed";
                    lblMsg.Invoke(new Action(ShowMsg));
                }

            }
            else
            {
                labelMessage = "Identification Failed";
                lblMsg.Invoke(new Action(ShowMsg));
            }

        }

        private void ShowMsg()
        {
            lblMsg.Text = labelMessage;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        private void LoadUI()
        {
            DataGridViewRow row = (DataGridViewRow)gdvAttendance.Rows[0].Clone();
            gdvAttendance.Rows.Clear();
            getTodayAttendance();

            lblMsg.Text = labelMessage;
            lblMsg.ForeColor = System.Drawing.Color.Blue;
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The " + getFingerType() + " finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader was touched.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {

            MakeReport("The fingerprint reader was connected and started.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {

            MakeReport("The fingerprint reader was disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {

            if (CaptureFeedback == CaptureFeedback.Good)
            {
                MakeReport("The quality of the " + getFingerType() + " fingerprint sample is good.");
            }
            else
            {
                MakeReport("The quality of the " + getFingerType() + " fingerprint sample is poor.");
            }


        }
        protected void MakeReport(object status)
        {
            try
            {
                this.Invoke(new FunctionCall(_MakeReport), status);
            }
            catch (Exception ex)
            {
                try
                {
                    //logger.WriteLog(ex);
                }
                catch (Exception exx)
                {
                }
            }
        }
        private void _MakeReport(dynamic status)
        {
            if (txtLog != null)
            {
                txtLog.AppendText(status + Environment.NewLine);
            }

        }

        public string getFingerType()
        {
            //to remove
            //return rdbLeftThumb.Checked ? "Left" : "Right";
            return "";
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
            }
        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion convertor = new DPFP.Capture.SampleConversion();
            Bitmap bitmap = null/* TODO Change to default(_) if this is not a reference type */;
            convertor.ConvertToPicture(Sample, ref bitmap);
            return bitmap;
        }
        protected void DrawPicture(Image bmp)
        {
            try
            {
                this.Invoke(new FunctionCall(_DrawPicture), bmp);
            }
            catch (Exception ex)
            {
                try
                {
                    //logger.WriteLog(ex);
                }
                catch (Exception exx)
                {
                    MessageBox.Show("An error has occured during draw", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void _DrawPicture(dynamic bmp)
        {

            fingerBox.Image = new Bitmap(bmp, fingerBox.Size);
            FingerBmp = (System.Drawing.Bitmap)bmp;

        }

        protected void SetPrompt(string text)
        {
            try
            {
                this.Invoke(new FunctionCall(_SetPrompt), text);
            }
            catch (Exception ex)
            {
                try
                {
                    // Base.logger.WriteLog(ex);
                }
                catch (Exception exx)
                {
                }
            }
        }

        private void _SetPrompt(dynamic text)
        {
            txtLog.Text = (string)text;
        }

        public static Bitmap BytesToBitmap(byte[] byteArray)
        {
            try
            {
                byte[] bytes = { 3, 10, 8, 25 };
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    ms.Position = 0;
                    dynamic t = byteArray;
                    Bitmap bmpfromDB = new Bitmap(ms);//new Bitmap( Image.FromStream(ms));
                    Image img = Image.FromStream(ms);
                    return bmpfromDB;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            Capturer.StopCapture();
            this.Hide();
            Container mainForm = new Container();
            mainForm.Show();

        }



        private bool GetFingerPrints(Bitmap bmp)
        {
            try
            {
                var fingers = _bioRepo.GetFingers();
                foreach (var item in fingers)
                {
                    
                    FingerBmp = BytesToBitmap((byte[])item.FingerTemplate);
                    StudentId = item.StudentId;

                    DigitaPersonaClass obj = new DigitaPersonaClass();
                    if (obj.NonUnique(ref FingerBmp, ref bmp))
                    {
                        studentDetail = _studentRepo.GetStudent(StudentId);
                        return true;
                    }                   
                }
                
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                returnImage = Image.FromStream(ms, true);//Exception occurs here
            }
            catch { }
            return returnImage;
        }

    }
}
