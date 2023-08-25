using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for GmailSender
/// </summary>
public class GmailSender
{
	public GmailSender()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool SendMail(string gMailAccount, string password, string to, string subject, string message)
    {
        try
        {
            NetworkCredential loginInfo = new NetworkCredential(gMailAccount, "3D17A8F09E433F93F0849A8B254060931A81");
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(gMailAccount, "info@vijapurainfotech.com");
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.elasticemail.com",2525);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.Send(msg);

            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    public static bool SendMail(string text, string v, string msg)
    {
        throw new NotImplementedException();
    }

    public static bool SendMailWithAttachement(string gMailAccount, string password, string to, string subject, string message,string path)
    {
        try
        {
            NetworkCredential loginInfo = new NetworkCredential(gMailAccount, "3D17A8F09E433F93F0849A8B254060931A81");
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(gMailAccount, "info@vijapurainfotech.com");
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = true;
            msg.Attachments.Add(new Attachment(path));
            SmtpClient client = new SmtpClient("smtp.elasticemail.com", 2525);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.Send(msg);

            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

   
}
