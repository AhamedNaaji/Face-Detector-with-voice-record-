using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Face_Detector
{
    public partial class Voice_Record : Form
    {
        public Voice_Record()
        {
            InitializeComponent();
        }
        //Code for importing winm.dynamic - link library methods to access in the program 
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);
        string record = "";

        private void btnRecord_Click(object sender, EventArgs e)
        {
            //Code For Recording
            mciSendString("open new type waveaudio alias Som", null, 0, 0);
            mciSendString("record Som", null, 0, 0);
            lbl_Recorder.Text = "Recording...";
            lbl_Recorder.ForeColor = Color.PaleVioletRed;
            timer1.Start();
            Count_Down.Start();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Code to Save Recording File
            mciSendString("pause Som", null, 0, 0);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "wave|*.wav";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                mciSendString("save Som " + sfd.FileName, null, 0, 0);
                mciSendString("close Som", null, 0, 0);
            }
            //Code to Save Recording File
            if (!string.IsNullOrEmpty(record))
            {
                mciSendString("save Som " + record, null, 0, 0);
                mciSendString("close Som", null, 0, 0);
                lbl_Recorder.Text = "Recording Saved";
                lbl_Recorder.ForeColor = Color.Green;
            }
            else
            {
                MessageBox.Show("Successfully Saved!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //System.Diagnostics.Stopwatch Count_Down = new System.Diagnostics.Stopwatch();
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    TimeSpan elapsed = Count_Down.Elapsed;
        //    lbl_Timer.Text = "Duration :" + string.Format("{0:00}:{1:00}:{2:00}", Math.Floor(elapsed.TotalHours),
        //    elapsed.Minutes, elapsed.Seconds);
        //}

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Code to Stop Recording
            mciSendString("stop Som", null, 0, 0);
            lbl_Recorder.Text = "Stopped";
            lbl_Recorder.ForeColor = Color.Purple;
            timer1.Stop();
            Count_Down.Stop();
            Count_Down.Reset();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (record == "")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "wave|*.wav";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    record = ofd.FileName;
                }
            }
            mciSendString("play " + record, null, 0, 0);
            lbl_Recorder.Text = "Playing....";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Facedetect = new Form1();
            Facedetect.ShowDialog();
        }
        System.Diagnostics.Stopwatch Count_Down = new System.Diagnostics.Stopwatch();
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeSpan elapsed = Count_Down.Elapsed;
            lbl_Timer.Text = "Duration :" + string.Format("{0:00}:{1:00}:{2:00}", Math.Floor(elapsed.TotalHours),
            elapsed.Minutes, elapsed.Seconds);
        }
    }
}
