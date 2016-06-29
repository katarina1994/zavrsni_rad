using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using web.DAL;
using web.Models;

namespace web.Controllers
{
    [RoutePrefix("api/Potvrda")]
    public class PotvrdaController : ApiController
    {

        private DatabaseContext db = new DatabaseContext();


        [AcceptVerbs("GET")]
        [Route("Potvrda/{id:int}")]
        [HttpGet]
        public async Task<string> Potvrda(int id)
        {

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("POTVRDA NARUDŽBE", "bubbles.notification@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", "cvrcko111@gmail.com"));
            emailMessage.Subject = "POTVRDA NARUDŽBE";
            emailMessage.Body = new TextPart("html") { Text = "Vaše naručeno jelo je potvrđeno." };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try {
                    await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync("bubbles.notification", "Dr(!*Ezk@R48");
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
                catch(Exception ovo_je_neki_duzi_naziv)
                {
                    return "uzas";

                }
            }
            return "bla";
        }
}
}
