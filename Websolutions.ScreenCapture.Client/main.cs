using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Websolutions.ScreenCapture.Capture;
using Websolutions.ScreenCapture.Client.Hotkeys;

namespace Websolutions.ScreenCapture.Client
{
    public partial class main : Form
    {

        private Hotkeys.GlobalHotkey ghk;

        public main()
        {
            InitializeComponent();
            ghk = new Hotkeys.GlobalHotkey(Constants.ALT , Keys.P, this);
        }
        // this is ON CLICK event off HOTKEY..
        private void HandleHotkey()
        {
            WriteLine("Hotkey pressed!");
            var fileName = Microsoft.VisualBasic.Interaction.InputBox("Enter File Name", "ScreenShot Name", "");
            System.Threading.Thread.Sleep(500);
            CaptureScreen.Capture(fileName);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WriteLine("Trying to register SHIFT+ALT+O");
            if (ghk.Register())
                WriteLine("Hotkey registered.");
            else
                WriteLine("Hotkey failed to register");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ghk.Unregiser())
                MessageBox.Show("Hotkey failed to unregister!");
        }

        private void WriteLine(string text)
        {
            textBox1.Text += text + Environment.NewLine;
        }

    }
}
