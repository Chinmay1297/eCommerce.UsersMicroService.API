namespace eCommerce.Core.DTO
{
    // This class represents the data transfer object for a login request.
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
