using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
/// <summary>
/// Summary description for ErrorLogClass
/// </summary>
/// 

namespace ww_admin
{
    public class ErrorLogClass
    {
        public ErrorLogClass(string _strUrl, string _strPageName, string _strMessage, Exception _eException)
        {
            string file = "../../errorlog.htm";

            StreamWriter SW;
            SW = File.AppendText(file);
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<p>********************</p>");
            strBuilder.Append(" <table width='90%' border='1' align='center' cellpadding='2' cellspacing='2'>");
            strBuilder.Append("  <tr>");
            strBuilder.Append(" <td width='33%'><strong>Date</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + DateTime.Now.ToShortDateString() + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Url</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strUrl + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Page Name</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strPageName + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Error Message</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strMessage + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Exception</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _eException.Message + "</td>");
            strBuilder.Append(" </tr>");


            strBuilder.Append(" </table>");
            strBuilder.Append("<p>********************</p>");
            //SW.WriteLine(strBuilder.ToString());
            SW.Close();
        }


        public ErrorLogClass(string _strPageName, string _strMessage, Exception _eException)
        {
            //string file = Server.MapPath(VirtualPathUtility.ToAbsolute("~/errorlog.htm"));
            string file = "../../errorlog.htm";

            StreamWriter SW;
            SW=File.AppendText(file);
            StringBuilder strBuilder=new StringBuilder();
            strBuilder.Append("<p>********************</p>");
            strBuilder.Append(" <table width='90%' border='1' align='center' cellpadding='2' cellspacing='2'>");
            strBuilder.Append("  <tr>");
            strBuilder.Append(" <td width='33%'><strong>Date</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>"+DateTime.Now.ToShortDateString()+"</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Page Name</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strPageName + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Error Message</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strMessage + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Exception</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _eException.Message + "</td>");
            strBuilder.Append(" </tr>");


            strBuilder.Append(" </table>");      
            strBuilder.Append("<p>********************</p>");
            //SW.WriteLine(strBuilder.ToString());
            SW.Close();                   
        }


        public ErrorLogClass(string _strUrl, string _strPageName, string _strFunctionName, string _strMessage)
        {
            //string file = Server.MapPath(VirtualPathUtility.ToAbsolute("~/errorlog.htm"));
            string file = "../../errorlog.htm";

            StreamWriter SW;
            SW = File.AppendText(file);
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<p>********************</p>");
            strBuilder.Append(" <table width='90%' border='1' align='center' cellpadding='2' cellspacing='2'>");
            strBuilder.Append("  <tr>");
            strBuilder.Append(" <td width='33%'><strong>Date</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + DateTime.Now.ToShortDateString() + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Url</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strUrl + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Page Name</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strPageName + "</td>");
            strBuilder.Append(" </tr>");


            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Function Name</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strFunctionName + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Error Message</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strMessage + "</td>");
            strBuilder.Append(" </tr>");



            strBuilder.Append(" </table>");
            strBuilder.Append("<p>********************</p>");
            //SW.WriteLine(strBuilder.ToString());
            SW.Close();
        }


        public ErrorLogClass(string _strPageName, string _strFunctionName, string _strMessage)
        {
            //string file = Server.MapPath(VirtualPathUtility.ToAbsolute("~/errorlog.htm"));
            string file = "../../errorlog.htm";

            StreamWriter SW;
            SW = File.AppendText(file);
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<p>********************</p>");
            strBuilder.Append(" <table width='90%' border='1' align='center' cellpadding='2' cellspacing='2'>");
            strBuilder.Append("  <tr>");
            strBuilder.Append(" <td width='33%'><strong>Date</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + DateTime.Now.ToShortDateString() + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Page Name</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strPageName + "</td>");
            strBuilder.Append(" </tr>");


            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Function Name</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strFunctionName + "</td>");
            strBuilder.Append(" </tr>");

            strBuilder.Append("  <tr>");
            strBuilder.Append("<td width='33%'><strong>Error Message</strong></td>");
            strBuilder.Append(" <td width='1%'><strong>:</strong></td>");
            strBuilder.Append(" <td width='66%'>" + _strMessage + "</td>");
            strBuilder.Append(" </tr>");



            strBuilder.Append(" </table>");
            strBuilder.Append("<p>********************</p>");
            //SW.WriteLine(strBuilder.ToString());
            SW.Close();
        }

        //private string _strPageName = "";
        //public string strPageName
        //{
        //    get
        //    {
        //        return _strPageName;
        //    }
        //    set
        //    {
        //        _strPageName = value;
        //    }
        //}

        //private string _strMessage = "";
        //public string strMessage
        //{
        //    get
        //    {
        //        return _strMessage;
        //    }
        //    set
        //    {
        //        _strMessage = value;
        //    }
        //}

    }
}
