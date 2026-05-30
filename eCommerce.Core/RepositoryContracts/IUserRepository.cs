using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts
{
    /// <summary>
    /// Contract to be implemented by the UserRepository class, which will handle data access operations related to user management in the e-commerce system.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Method to add a user to the data store and return the added user with the generated UserID. If the user cannot be added, it returns null.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);

        /// <summary>
        /// Method to retrieve existing user details from the data store based on the provided email and password. If a matching user is found, it returns the user details; otherwise, it returns null.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    }
}
