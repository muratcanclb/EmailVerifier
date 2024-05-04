using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace email_verifier_api.Domain.Entities
{
    public class Emails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string email {get; set; }
        public Boolean isVerify { get; set; }
        public string code { get; set; }
    }
}
