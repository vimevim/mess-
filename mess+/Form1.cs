using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace mess_
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser leftChromeBrowser;
        public ChromiumWebBrowser middleChromeBrowser;
        public ChromiumWebBrowser rightChromeBrowser;

        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
        }
        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            //kullanıcı giriş verilerini tutmaya yarayan satır eklendi
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";
            Cef.Initialize(settings);
            leftChromeBrowser = new ChromiumWebBrowser("https://www.facebook.com/messages/t/");
            middleChromeBrowser = new ChromiumWebBrowser("http://web.whatsapp.com");
            rightChromeBrowser = new ChromiumWebBrowser("https://www.instagram.com/direct/inbox/");
            leftPanel.Controls.Add(leftChromeBrowser);
            middlePanel.Controls.Add(middleChromeBrowser);
            rightPanel.Controls.Add(rightChromeBrowser);
            leftChromeBrowser.Dock = DockStyle.Fill;
            middleChromeBrowser.Dock = DockStyle.Fill;
            rightChromeBrowser.Dock = DockStyle.Fill;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
