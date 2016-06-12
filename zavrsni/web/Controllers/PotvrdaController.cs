using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
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
        public String Potvrda(int id)
        {

            IQueryable< OdabranoJelo>  odabrano_jelo =  db.OdabranaJela.Where(s => s.ID == id);
            Console.WriteLine(odabrano_jelo);
            //IQueryable<Jelo> jelo = db.OdabranaJela.Where(s => s.ID == odabrano_jelo.JeloID);
            MailMessage mailMessage = new MailMessage();
            MailAddress fromAddress = new MailAddress("cvrcko111@gmail.com");
            mailMessage.From = fromAddress;
            mailMessage.To.Add("cvrcko111@gmail.com");
            mailMessage.Body = "Vasa narudzba jela je potvrdena.";
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = " Testing Email";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "localhost";
            smtpClient.Send(mailMessage);
            return "id: " + id;
        }
}
}
