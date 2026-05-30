using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? applicationUser = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (applicationUser == null) {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(applicationUser) with { Success = true, Token = "token" };
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

            //return new AuthenticationResponse(registerUser.UserID, registerUser.Email, registerUser.PersonName, registerUser.Gender, "token", Success: true);
            // _mapper.Map<destination>(source)
            return _mapper.Map<AuthenticationResponse>(registerUser) with { Success = true, Token = "token"};  // with expression to set Success and Token properties (which were ignored in mapping profile)
        }
    }
}
