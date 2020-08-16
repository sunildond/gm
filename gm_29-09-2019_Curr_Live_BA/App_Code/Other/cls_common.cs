using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;

/// <summary>
/// Summary description for cls_common
/// </summary>
public class cls_common
{
    public cls_common()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //*****Function CreateThumbnail() : Creates a Thumbnail Image from a Normal Image***** 
    public void CreateThumdnail(string srcpath, string destpath)
    {
        //Creates image object and uploaded file path is assigned to it
        System.Drawing.Image img = System.Drawing.Image.FromFile(srcpath);

        //Creates thumbnail image object and assigns the returned Thumbnail Image of size mentioned in parameters to it
        System.Drawing.Image imgthumb = img.GetThumbnailImage(100, 75, null, new System.IntPtr(0));

        //Saves the thumbnail image in Destination Folder in JPEG format
        imgthumb.Save(destpath, ImageFormat.Jpeg);

        //Releases all resources used by the Class
        img.Dispose();
        imgthumb.Dispose();
    }

    public void CreateThumdnail_Last(string srcpath, string destpath)
    {
        //Creates image object and uploaded file path is assigned to it
        System.Drawing.Image img = System.Drawing.Image.FromFile(srcpath);

        //Creates thumbnail image object and assigns the returned Thumbnail Image of size mentioned in parameters to it
        System.Drawing.Image imgthumb = img.GetThumbnailImage(201, 185, null, new System.IntPtr(0));
        
        //Saves the thumbnail image in Destination Folder in JPEG format
        imgthumb.Save(destpath, ImageFormat.Jpeg);

        //Releases all resources used by the Class
        img.Dispose();
        imgthumb.Dispose();
    }

    //function to delete the files
    public void file_delete(String str_sourcepath, String str_filename)
    {
        FileInfo file = new FileInfo(Path.Combine(str_sourcepath, str_filename));
        if (file.Exists)
        {
            File.Delete(Path.Combine(str_sourcepath, str_filename));
        }
    }

    public string file_name(String filenm)
    {
        DateTime time = DateTime.Now;
        long l_ticks = time.Ticks;
        string str_filenm = l_ticks + "_" + filenm;
        return str_filenm;
    }

    public void fn_SendEmail(string FromEmail, string ToEmail, string Subject, string Body)
    {
        try
        {
            //Send Email Code...........................................................................................................
            //System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]);
            //System.Net.NetworkCredential myCredentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["MailPassword"]);
            //System.Net.Mail.MailMessage emailMessage = null;
            //emailMessage = new System.Net.Mail.MailMessage(FromEmail, ToEmail, Subject, Body);
            //emailMessage.IsBodyHtml = true;
            //emailMessage.ReplyTo = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["FromEmail"].ToString());
            //mailClient.UseDefaultCredentials = false;
            //mailClient.Credentials = myCredentials;
            //mailClient.Send(emailMessage);
            //--------------------------------------------------------------------------------------------------------------------------
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

}
