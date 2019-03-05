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
    public partial class Form1 : Form
    {
        private IVideoSource videoSource;
        int frameCount;
        static HttpClient client = new HttpClient();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmap;
            frameCount++;
            if (frameCount == 60)
            {
                Bitmap b = (Bitmap)bitmap.Clone();
                var t = Task.Run(() => CheckForQRCode(b));
            }
        }

        private async void CheckForQRCode(Bitmap image)
        {
            LuminanceSource source;
            source = new BitmapLuminanceSource(image);
            BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
            Result result = new MultiFormatReader().decode(bitmap);

            if (result != null) //Code Found
            {
                var QRCodeString = result.ToString();
                bool codevalid = await CheckQRString(QRCodeString);
                if(codevalid)
                {
                    StopVideo();
                    pictureBox1.Image = null;
                    pictureBox1.BackColor = Color.Green;
                }

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

        static async Task<bool> CheckQRString(string QRString)
        {
            string checkAPIURL = "http://192.168.0.24:45455/api/Booking/CheckQR/{0}";
            checkAPIURL = string.Format(checkAPIURL, QRString);
            bool Accepted = false;
            try
            {
                var response = await client.GetAsync(checkAPIURL);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (content.Contains("success"))
                        return true;
                    else
                        return false;
                            
                }
            }
            catch (Exception e)
            {
                
            }
            return false;
        }
    }
}
