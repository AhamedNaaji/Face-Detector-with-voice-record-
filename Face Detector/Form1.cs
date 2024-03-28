using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition;

namespace Face_Detector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FaceRec facerec = new FaceRec();
        private void BtnOpenCam_Click(object sender, EventArgs e)
        {
            facerec.openCamera(pictureBox1, pictureBox2);
        }

        private void btnSaveImg_Click(object sender, EventArgs e)
        {
            facerec.Save_IMAGE(txtName.Text);
            MessageBox.Show("Successfully Saved");
        }

        private void btnDetectface_Click(object sender, EventArgs e)
        {
            facerec.isTrained= true;
        }
    }
}
