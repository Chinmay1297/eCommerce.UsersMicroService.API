namespace eCommerce.Core.Entities
{
    /// <summary>
    /// Define the ApplicationUser entity which represents a user in the e-commerce system. 
    /// This class can be extended with additional properties as needed, such as roles, permissions, profile information etc. 
    /// For now, it includes basic properties like UserID, Email, Password
    /// </summary>
    public class ApplicationUser
    {
        public Guid UserID { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PersonName { get; set; }
        public string? Gender { get; set; }
    }
}
