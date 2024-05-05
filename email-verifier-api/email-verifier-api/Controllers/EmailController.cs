using email_verifier_api.Data;
using email_verifier_api.Domain.Dto;
using email_verifier_api.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                    //email yok ve doğrulanmamış
                    var verifyCode = Guid.NewGuid().ToString("N").Substring(0, 6);
                    var email = _context.emails.SingleOrDefault(u => u.email == data.email);
                    if(email == null)
                    {
                        var newEmail = new Emails()
                        {
                            id = new Guid(),
                            email = data.email,
                            code = verifyCode,
                            isVerify = false
                        };
                        _context.emails.Add(newEmail);
                    }
                    else
                    {
                        email.code = verifyCode;
                        _context.Entry(email).State = EntityState.Modified;
                        
                    }
                    _context.SaveChanges();
                    //mail gönderme işlemi
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Email Verifier App", "muratcanclbi@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User",data.email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    
                    bodyBuilder.HtmlBody = "<h1>Merhaba</h1> <br/>";
                    bodyBuilder.HtmlBody += "<p>Email doğrulama kodunuz: "+ verifyCode +" \r\n</p>";
                    bodyBuilder.HtmlBody += "<p>Teşekkürler,</p>";
                    bodyBuilder.HtmlBody += "<p>Verifier App Ekibi</p>";
                    bodyBuilder.HtmlBody += "<p>Murat Can Çelebi</p>";
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Email Doğrulama Kodu";
                    MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("muratcanclbi@gmail.com", "jyfsilpmbskjxkyi");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                    return NoContent();
                }
            }
        }

        [Route("emailVerify")]
        [HttpPost]
        public async Task<IActionResult> VerifyEmail([FromBody] EmailCodeDto data)
        {
            var isThere = _context.emails.Any(x => x.email == data.email && x.isVerify == false);

            if (isThere)
            {
                //email var ve doğrulanmamış
                var email = _context.emails.SingleOrDefault(u => u.email == data.email);
                if (email.code == data.code)
                {
                    email.isVerify = true;
                    _context.Entry(email).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
            else
            {
                return NotFound();
            }
                
        }
    }
}
