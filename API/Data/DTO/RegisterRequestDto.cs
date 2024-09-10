namespace API.Data.DTO
{
    public class RegisterRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Sarpanch { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }
}
