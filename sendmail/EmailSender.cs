using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assign1._1.sendmail
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String Email, string Phone_No, string NofCustomer)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 ");
            var to = new EmailAddress(Email, "");
            var plainTextContent = NofCustomer + "people";
            var htmlContent = "<p>" + NofCustomer + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, Phone_No, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

    }
}