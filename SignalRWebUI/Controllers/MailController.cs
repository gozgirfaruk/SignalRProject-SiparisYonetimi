using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto model)
        {
			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailBoxFrom = new MailboxAddress("Ömer Faruk Gözegir", "gozgirfaruk@gmail.com");
			mimeMessage.From.Add(mailBoxFrom);

			MailboxAddress mailBoxAddress = new MailboxAddress("Ömer Faruk", model.ReceiverMail);
			mimeMessage.To.Add(mailBoxAddress);
			mimeMessage.Subject = model.Subject;
			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = model.Body;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			SmtpClient client = new SmtpClient(); //MailKit.Net.Smtp kütüphanesi olacak
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("gozgirfaruk@gmail.com", "şifreşifre"); 
  client.Send(mimeMessage);
			client.Disconnect(true);
			return RedirectToAction("Index", "AdminDashboard");

        }
    }
}
