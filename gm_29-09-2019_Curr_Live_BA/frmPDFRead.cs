using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using ww_lib;
using ww_admin;
using System.IO;
using System.Data.SqlClient;

namespace GlanMark
{
    public partial class frmPDFRead : Form
    {
        public frmPDFRead(string Name)
        {
            InitializeComponent();

            string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + Name;
            if (File.Exists(strPath))
            {
                System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                myProcess.StartInfo.FileName = "AcroRd32.exe";
                myProcess.StartInfo.Arguments = " /n /A \"nameddest=nameddest\" " + strPath + "\"";
                myProcess.Start();

            }
        }

        private void frmPDFRead_Load(object sender, EventArgs e)
        {
            //string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + str.Name;
            //if (!File.Exists(strPath))
            //{
            //    System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            //    myProcess.StartInfo.FileName = "AcroRd32.exe";
            //    myProcess.StartInfo.Arguments = " /n /A \"nameddest=nameddest\" F:\\sunild17\\WinSearch\\One more chance.pdf\"";
            //    myProcess.Start();
            
            //}
        }
    }


}
