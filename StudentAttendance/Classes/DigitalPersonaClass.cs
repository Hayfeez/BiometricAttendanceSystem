using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DigitalPersona.Standards;
using DPFP;
using DPFP.Processing;
using static StudentAttendance.Classes.ErrorLoggerBase;

namespace StudentAttendance.Classes
{
    public class DigitaPersonaClass
    {
        public System.ComponentModel.ISynchronizeInvoke IObj;
        public byte[] bmpByte;
        public System.Drawing.Bitmap Resultbmp;
        public System.Drawing.Bitmap Derivedbmp;
        private DPFP.Capture.Capture Capturer = new DPFP.Capture.Capture();
        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Verification.Verification Verificator;
        private DPFP.Template Template;
        public event OnTemplateEventHandler OnTemplate;

        public delegate void OnTemplateEventHandler(object template);

        private Bitmap TrueBitmap = null/* TODO Change to default(_) if this is not a reference type */;
        private int Dpi = 700;
        Byte[] inputData = null;
        DigitalPersona.Standards.InputParameterForRaw inpRaw = null;
        DPFP.Sample DPsample;
        DPFP.FeatureSet DPFeatures;
        DPFP.Template DPTemplate;
        byte[] ISOFMD;
        public bool NonUnique(ref Bitmap LeftFinger, ref Bitmap RightFinger)
        {
            try
            {
                // convert the leftfinger to sample
                Sample LeftSample = ConvertRawBmpAsSample(LeftFinger);

                // convert the right finger as template
                Template RightTemplate = ConvertRawBmpAsTemplate(RightFinger, DataPurpose.Verification);

                // Process the sample and create a feature set for the enrollment purpose.
                DPFP.FeatureSet features = ExtractFeatures(LeftSample, DPFP.Processing.DataPurpose.Verification);

                Stopwatch sw = new Stopwatch();
                // Check quality of the sample and start verification if it's good
                if (features != null & RightTemplate != null)
                {
                    // loads the collection

                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                    // timer for current comparison 
                    sw.Start();

                    result = DPFP.Verification.Verification.Verify(features, RightTemplate, 0x7FFFFFFF / 100000);

                    if (result.Verified)
                        return true;
                    else
                        return false;
                    sw.Stop();
                }
                else
                    throw new Exception("Fingerprint is of low quality");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public DPFP.Template ConvertRawBmpAsTemplate(Bitmap RawBmp, DataPurpose ProcessPurpose = DataPurpose.Enrollment, short VertDpi = 700, short HorDpi = 700)
        {
            VariantConverter VConverter;
            Enroller = new DPFP.Processing.Enrollment();
            RawBmp = EncodeBitmap(RawBmp, VertDpi, HorDpi);
            try
            {
                // converts raw image to dpSample using DFC 2.0---------------------------------------
                // encode the bmp variable using the bitmap Loader
                BitmapLoader BmpLoader = new BitmapLoader(RawBmp, (int)RawBmp.HorizontalResolution, (int)RawBmp.VerticalResolution);
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
                DPFeatures = ExtractFeatures(DPsample, ProcessPurpose);
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
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }
        public Sample ConvertRawBmpAsSample(Bitmap RawBmp, short VertDpi = 700, short HorDpi = 700)
        {
            VariantConverter VConverter;
            Enroller = new DPFP.Processing.Enrollment();
            RawBmp = EncodeBitmap(RawBmp, VertDpi, HorDpi);
            try
            {
                // converts raw image to dpSample using DFC 2.0---------------------------------------
                // encode the bmp variable using the bitmap Loader
                BitmapLoader BmpLoader = new BitmapLoader(RawBmp, (int)RawBmp.HorizontalResolution, (int)RawBmp.VerticalResolution);
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
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
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
                throw new Exception("Error Extracting Features");
            }
        }

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
                throw ex;
            }
            finally
            {
            }
            return null/* TODO Change to default(_) if this is not a reference type */;
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
                throw ex;
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
                throw ex;
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
                MessageBox.Show("Successfully Saved File " + dlgSave.FileName);
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
                    case System.Drawing.Imaging.PixelFormat.Format32bppRgb:
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
