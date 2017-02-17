using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Options;
using Microsoft.Extensions.Options;

namespace MyFirstCoreWeb.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSMSSenderOptions Options { get; }

        public AuthMessageSender(IOptions<AuthMessageSMSSenderOptions> optionsAccessor )
        {
            Options = optionsAccessor.Value;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {

            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            //var twilio = new TwilioRestClient(Options.SID,Options.AuthToken);

            //twilio.SendMessage(Options.SendNumber, number, message);

            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
