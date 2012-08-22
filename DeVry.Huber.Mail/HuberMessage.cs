using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeVry.Huber.Mail
{
    public class HuberMessage
    {
      //  public string messagebody { get; set; }

        public bool Send(string messagebody, string from, string to, string subject)
        {
            try
            {

            System.Net.Mail.MailMessage message =
                       new System.Net.Mail.MailMessage(from, to);

            message.Subject = "Your recent order with Shawn copies everything.com";
            message.Body = messagebody;
            message.IsBodyHtml = true;


            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("");
            client.Send(message);
            return true;
            }
            catch (Exception)
            {

                return false;
            }
            //final exam notes....

            //statement of work.
            //you create this
            //You are graded on. How many of the items from the labs you include in your statement of work
            //AND how many you actually complete.
            //if your statement of work is really easy then your max grade will start LOWER.
            //for example picking seven of the more difficult items from the labs would give you a starting grade of an A
            //missing one item might drop you 100%/7 (14%).
            //email is a given if you want credit for lab 7

        }
    }
}
