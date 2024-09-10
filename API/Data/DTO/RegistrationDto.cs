using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class RegistrationDto
    {
        [Key]
        public Guid Hmy { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredDate { get; set; }
        public int UserStatus { get; set; }

    }
}
