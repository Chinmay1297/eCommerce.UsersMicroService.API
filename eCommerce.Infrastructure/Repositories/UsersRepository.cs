using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;
        public UsersRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            //Generate unique user ID
            user.UserID = Guid.NewGuid();

            // Sql Query to insert user into the database -> Users table

            //In postgreSQL, we need to use double quotes for table and column names if they are capitalized or contain special characters.
            string query = "INSERT INTO public.\"Users\" (\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

            if (rowCountAffected > 0)
            {
                return user;
            }

            return null;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            //SQL query to select a user by Email and Password
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Email = email, Password = password });

            return user;
        }
    }
}
