using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace ScannerTest
{
    public partial class ScannerPage : Form
    {
        private IVideoSource videoSource;
        int frameCount;
        static HttpClient client = new HttpClient();
        bool ScanSuccess;

        public int FoundRoom { get; set; }

        public ScannerPage()
        {
            InitializeComponent();
        }

        private void ScannerPage_Load(object sender, EventArgs e)
        {
            VideoCaptureDeviceForm form = new VideoCaptureDeviceForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                videoSource = form.VideoDevice;
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
            }
            this.Size = pictureBox1.Size;
            frameCount = 0;
        }

        private async void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmap;
            frameCount++;
            if (frameCount == 60)
            {
                Bitmap b = (Bitmap)bitmap.Clone();
                await CheckForQRCode(b);
                if (ScanSuccess)
                    this.Invoke(new Action(() => this.Close()));
            }
        }

        private async Task CheckForQRCode(Bitmap image)
        {
            LuminanceSource source;
            source = new BitmapLuminanceSource(image);
            BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
            Result result = new MultiFormatReader().decode(bitmap);

            if (result != null) //Code Found
            {
                var QRCodeString = result.ToString();
                string codevalid = await CheckQRString(QRCodeString);
                if (codevalid.Contains("success"))
                {
                    string trimed = codevalid.Replace("success", "");
                    FoundRoom = Convert.ToInt32(trimed);
                    StopVideo();
                    ScanSuccess = true;

                }
                else if (codevalid == "badDate")
                {
                    MessageBox.Show("This booking is not valid for today. Please check the date of this booking");
                }
                else if (codevalid == "bookingEnded")
                    MessageBox.Show("This booking has already ended. If you wish to continue staying here you must make another booking.");
                else if (codevalid == "fail")
                    MessageBox.Show("An error occured when scanning your code. Please try again!");

            }
            else    //No Code
            {
                //MessageBox.Show("fuck off: ");
            }

            frameCount = 0;
        }

        private void StopVideo()
        {
            videoSource.SignalToStop();
            if (videoSource != null && videoSource.IsRunning && pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            StopVideo();
        }

        static async Task<string> CheckQRString(string QRString)
        {
            string checkAPIURL = "http://192.168.0.24:57162/api/Booking/CheckQR/{0}";
            checkAPIURL = string.Format(checkAPIURL, QRString);
            try
            {
                var response = await client.GetAsync(checkAPIURL);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    content = content.Replace("\\", string.Empty);
                    content = content.Trim('"');
                    return content;

                }
            }
            catch (Exception e)
            {

            }
            return "fail";
        }

        private void ScannerPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopVideo();
        }
    }
}
