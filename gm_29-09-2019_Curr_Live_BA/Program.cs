using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GlanMark
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DateTime expiryDate;

            //string validFrom, validTo;
            //DateTime validFromdate, validTodate;
            //IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
            //validFrom = "01-01-2014 00:00:00";
            //validTo = "30-03-2014 00:00:00";

            //validFromdate = Convert.ToDateTime(validFrom);
            //validTodate = Convert.ToDateTime(validTo);
            //if (DateTime.Compare(validFromdate, DateTime.Today) < 0 && DateTime.Compare(DateTime.Today, validTodate) < 0)
            //if (DateTime.Parse(DateTime.Now.ToShortDateString(), dateformat) <= DateTime.Parse("30-04-2014 12:00:00", dateformat))
            //{
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new MdiForm());
                Application.Run(new frmLogin());
            //}
            //else
            //{
            //    MessageBox.Show("Software Expired Please Contact System Administrator !");
            //}

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            ////Application.Run(new MdiForm());
            //Application.Run(new frmLogin());
        }
    }
}
