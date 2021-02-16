using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// add namespace
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

using System.Net;
using Microsoft.Win32;

//add reference
using mshtml;    // Microsoft.mshtml  (set " Interop" to "false") & microsoft html object lib 
using SHDocVw;//COM -  Microsoft Internet Controls


namespace CaptureWebBrowser
{
    public partial class Form1 : Form
    {
        #region DLLImport
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindowEx(IntPtr parent /*HWND*/, IntPtr next /*HWND*/, string sClassName, IntPtr sWindowTitle);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);

        [DllImport("user32.dll")]
        private static extern void GetClassName(int h, StringBuilder s, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        public const int GW_CHILD = 5;
        public const int GW_HWNDNEXT = 2;

        #endregion

        string m_sRegkeyName = @"HKEY_CURRENT_USER\Software\MAJORANA\CaptureWeb";
        string m_sRegValueName = @"SelectedPath";
        string m_sPath = Environment.SpecialFolder.MyPictures.ToString();
        public bool firstScreen = true;


        public Form1()
        {
            InitializeComponent();
        }

        private ImageCodecInfo GetImageInfo(string imageCode)
        {
            ImageCodecInfo fICI = null;
            foreach (ImageCodecInfo i in ImageCodecInfo.GetImageEncoders())
            {
                fICI = i;
                if (i.MimeType == imageCode)
                {
                    fICI = i;
                    break;
                }
           }
            return fICI;
        }

        private void SetMessage(string msg)
        {
            m_tbMessage.Text = msg;
        }

        public void GetPageImage(string url, string path)
        {
            bool flag = firstScreen;
            int URLExtraHeight = 3;
            int URLExtraLeft = 3;

            mshtml.IHTMLDocument2 myDoc = (mshtml.IHTMLDocument2)m_wbBrowser.Document.DomDocument;   
            (myDoc as HTMLDocumentClass).documentElement.setAttribute("scroll", "yes", 0);
            
            //document high
            int heightsize = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollHeight", 0);
            int widthsize = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollWidth", 0);

            ////Get Screen Height
            int screenHeight = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("clientHeight", 0);
            int screenWidth = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("clientWidth", 0);

            IntPtr myIntptr = (IntPtr)m_wbBrowser.Handle;
            IntPtr wbHandle = FindWindowEx(myIntptr, IntPtr.Zero, "Shell Embedding", null);
            wbHandle = FindWindowEx(wbHandle, IntPtr.Zero, "Shell DocObject View", null);
            wbHandle = FindWindowEx(wbHandle, IntPtr.Zero, "Internet Explorer_Server", null);
            IntPtr hwnd = wbHandle;

            Bitmap bm = new Bitmap(screenWidth, screenHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);//.Format16bppRgb555);
            Bitmap bm2 = new Bitmap(widthsize, heightsize, System.Drawing.Imaging.PixelFormat.Format24bppRgb);//.Format16bppRgb555);
            Graphics g = null;
            Graphics g2 = Graphics.FromImage(bm2);
            
            Bitmap tempbm = null;
            Graphics tempg = null;

            IntPtr hdc;
            Image screenfrag = null;
            Image firstScreenfrag = null;

            
            int brwTop = 0;
            int brwLeft = 0;
            int myPage = 0;

            while ((myPage * screenHeight) < heightsize){
                (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollTop", (screenHeight - 5) * myPage, 0);
                ++myPage;
            }
            
            --myPage;

            int myPageWidth = 0;
            
            while ((myPageWidth * screenWidth) < widthsize){
                (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollLeft", (screenWidth - 5) * myPageWidth, 0);
                brwLeft = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollLeft", 0);
                for (int i = myPage; i >= 0; --i){
                    g = Graphics.FromImage(bm);
                    hdc = g.GetHdc();
                    (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollTop", (screenHeight - 5) * i, 0);
                    brwTop = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollTop", 0);
                    PrintWindow(hwnd, hdc, 0);
                    g.ReleaseHdc(hdc);
                    g.Flush();
                    screenfrag = Image.FromHbitmap(bm.GetHbitmap());
                    tempbm = new Bitmap(screenWidth - URLExtraLeft, screenHeight - URLExtraHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);// Format16bppRgb555);
                    tempg = Graphics.FromImage(tempbm);
                    tempg.DrawImage(screenfrag, -URLExtraLeft, -URLExtraHeight);
                    g2.DrawImage(tempbm, brwLeft + URLExtraLeft, brwTop + URLExtraLeft);
                    System.Threading.Thread.Sleep(100);
                }

                if (flag)
                {
                    firstScreenfrag = (Image)tempbm.Clone();
                    flag = false;
                }

                ++myPageWidth;
            }

            int finalWidth = (int)widthsize;
            int finalHeight = (int)heightsize;
            Bitmap finalImage = new Bitmap(finalWidth, finalHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);// Format16bppRgb555);
            Graphics gFinal = Graphics.FromImage((Image)finalImage);
            gFinal.DrawImage(bm2, 0, 0, finalWidth, finalHeight);
            //Get Time Stamp
            DateTime myTime = DateTime.Now;
            String format = "yyyyMMdd-hhmmss";

            EncoderParameters eps = new EncoderParameters(1);
            long myQuality = Convert.ToInt64(100);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, myQuality);

            ImageCodecInfo sICI = GetImageInfo("image/jpeg");
            finalImage.Save(path + myTime.ToString(format) + ".jpg", sICI, eps);
            
            if (firstScreen) {
                firstScreenfrag.Save(path + @"First-" + myTime.ToString(format) + ".jpg", sICI, eps);
                firstScreenfrag.Dispose();
            }

/// Clean       
            myDoc.close();
            myDoc = null;
            g.Dispose();
            g2.Dispose();
            gFinal.Dispose();
            bm.Dispose();
            bm2.Dispose();
            finalImage.Dispose();
            tempbm.Dispose();
            tempg.Dispose();
        }

        private void m_bGo_Click(object sender, EventArgs e)
        {
            checkURL();
            m_wbBrowser.Navigate(m_tbURL.Text);

        }

        private void SetFilePath()
        {
            string sSelectedPath = (string)Registry.GetValue(m_sRegkeyName, m_sRegValueName, m_sPath);
            if (sSelectedPath != null)
                m_folderBrowserDialog.SelectedPath = sSelectedPath;

            if (m_folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                m_sPath = m_folderBrowserDialog.SelectedPath + @"\";
            }

            if (m_sPath.Length < 1)
            {
                m_sPath = Environment.SpecialFolder.MyPictures.ToString();
                return;
            }
            Registry.SetValue(m_sRegkeyName, m_sRegValueName, m_sPath, RegistryValueKind.String);

        }

        private void checkURL()
        {

            Uri uriResult;
            bool result = Uri.TryCreate("http://"+m_tbURL.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (result != true)
                m_tbURL.Text = "www.google.com";
        }
        private void m_bCapture_Click(object sender, EventArgs e)
        {
            checkURL();
            m_wbBrowser.Navigate(m_tbURL.Text);

            SetFilePath();
            SetMessage("Processing...");
            try
            {
                GetPageImage(m_tbURL.Text, m_sPath);
                SetMessage("Finish!");
            }
            catch ( Exception ex)
            {
                SetMessage("Error:"+ex.Message);
            }
            
            
        }
    }
}
