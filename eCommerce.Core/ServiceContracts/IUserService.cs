using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts
{
    /// <summary>
    /// Contract for users service that contains use cases for users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method to handle user login use case and return an AuthenticationResponse that contains the details of the logged in user and a JWT token if the login is successful
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
        /// <summary>
        /// Method to handle user registration use case and return an AuthenticationResponse that contains the details of the registered user and a JWT token if the registration is successful
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>

        Task<AuthenticationResponse?> Registration(RegisterRequest registerRequest);
    }
}
