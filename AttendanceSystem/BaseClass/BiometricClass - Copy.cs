using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalPersona.Standards;
using DPFP;
using DPFP.Verification;
using DPFP.Processing;
using DPFP.Capture;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace AttendanceSystem.BaseClassCopy
{
   public class BiometricClass
    {
        private Capture Capturer = new Capture();
        private Enrollment Enroller;
        private Verification Verificator;
        private Template Template;
        public event OnTemplateEventHandler OnTemplate;

        public delegate void OnTemplateEventHandler(object template);

        //private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.ComponentModel.ISynchronizeInvoke IObj;
        public byte[] bmpByte;
        public System.Drawing.Bitmap Resultbmp;
        public System.Drawing.Bitmap Derivedbmp;
        private FileStream ImageStream;
        Bitmap LeftBmp, RightBmp;
        DataHolder DataHold;

        private string Message = "";
        private Bitmap TrueBitmap = null/* TODO Change to default(_) if this is not a reference type */;
        private int Dpi = 700;
        Byte[] inputData = null;
        InputParameterForRaw inpRaw = null;
        Sample DPsample;
        FeatureSet DPFeatures;
        Template DPTemplate;
        byte[] ISOFMD;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        public bool Valid()
        {
            try
            {


                if (PicDerived.Image == null || PicDerived2.Image == null)
                {
                    //Interaction.MsgBox("Fingerprints must be captured", MsgBoxStyle.Exclamation);
                    //lblMsg.Text = "";
                    throw new Exception("Fingerprints must be captured");
                    //return false;
                }

                // check if fingerprints are unique
                if (NonUnique(ref LeftBmp, ref RightBmp))
                {
                    //Interaction.MsgBox("Same Fingerprints Are Not Allowed", MsgBoxStyle.Exclamation);
                    //lblMsg.Text = "Same Fingerprints Are Not Allowed";
                    throw new Exception("Same Fingerprints Are Not Allowed");
                    // return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //MsgBox(ex.Message, MsgBoxStyle.Critical, Application.ProductName);
                throw new Exception(ex.Message);
                //return false;
            }
        }
        public bool NonUnique(ref Bitmap LeftFinger, ref Bitmap RightFinger)
        {
            try
            {
                // convert the leftfinger to sample
                Sample LeftSample = ConvertRawBmpAsSample(LeftFinger);

                // convert the right finger as template
                Template RightTemplate = ConvertRawBmpAsTemplate(RightFinger, DataPurpose.Verification);

                // Process the sample and create a feature set for the enrollment purpose.
                FeatureSet features = ExtractFeatures(LeftSample, DataPurpose.Verification);

                Stopwatch sw = new Stopwatch();
                // Check quality of the sample and start verification if it's good
                if (features != null & RightTemplate != null)
                {
                    // loads the collection

                    Verification.Result result = new Verification.Result();

                    // timer for current comparison 
                    sw.Start();

                    result = Verification.Verify(features, RightTemplate, 0x7FFFFFFF / 100000);

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

    }
}
