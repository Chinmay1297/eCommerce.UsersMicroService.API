namespace eCommerce.Core.DTO
{
    // This record represents the data transfer object for a login request.
    // POCO class with properties for Email and Password. This will be used to capture the login credentials from the client when they attempt to log in.
    public record LoginRequest(
        string? Email,
        string? Password
    );
}
