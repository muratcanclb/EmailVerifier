using Microsoft.EntityFrameworkCore;

namespace email_verifier_api.Domain.Dto
{
    
    public class EmailCodeDto
    {
        public string email { get; set; }
        public string code { get; set; }
    }
}
