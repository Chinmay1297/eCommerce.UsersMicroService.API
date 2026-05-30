using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser applicationUser = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (applicationUser == null) {
                return null;
            }

            return new AuthenticationResponse(applicationUser.UserID, applicationUser.Email, applicationUser.PersonName, applicationUser.Gender, "token", Success: true);
        }

        public async Task<AuthenticationResponse?> Registration(RegisterRequest registerRequest)
        {
            //Create a new ApplicationUser object from RegisterRequest
            ApplicationUser user = new ApplicationUser
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                PersonName = registerRequest.PersonName,
                Gender = registerRequest.Gender.ToString()
            };

            ApplicationUser? registerUser = await _userRepository.AddUser(user);

            if(registerUser == null) {
                return null;
            }

            return new AuthenticationResponse(registerUser.UserID, registerUser.Email, registerUser.PersonName, registerUser.Gender, "token", Success: true);
        }
    }
}
