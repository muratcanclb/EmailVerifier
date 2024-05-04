using email_verifier_api.Data;
using email_verifier_api.Domain.Dto;
using email_verifier_api.Domain.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace email_verifier_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmailController(AppDbContext context)
        {
            _context = context;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> PostEmail([FromBody] EmailPostDto data)
        {
            if (data.email == null)
            {
                return NoContent();
            }
            else
            {
                var isThere = _context.emails.Any(x => x.email == data.email && x.isVerify == true);

                if (isThere)
                {
                    //email var
                    return Ok();
                }
                else
                {
                    //email yok
                    //mail gönderme işlemi
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Email Verifier App", "muratcanclbi@gmail.com");

                    MailboxAddress mailboxAddressTo = new MailboxAddress("User",data.email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    var verifyCode = Guid.NewGuid().ToString("N").Substring(0, 6);
                    bodyBuilder.HtmlBody = "<h1>Merhaba</h1> <br/>";
                    bodyBuilder.HtmlBody += "<p>Email doğrulama kodunuz: "+ verifyCode +" \r\n</p>";
                    bodyBuilder.HtmlBody += "<p>Teşekkürler,</p>";
                    bodyBuilder.HtmlBody += "<p>Verifier App Ekibi</p>";
                    bodyBuilder.HtmlBody += "<p>Murat Can Çelebi</p>";
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Email Doğrulama Kodu";
                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("muratcanclbi@gmail.com", "jyfsilpmbskjxkyi");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                    return NoContent();
                }
            }
        }
    }
}
