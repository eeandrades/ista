using Ista.Domain.Users;
using System;
using System.Linq;

namespace Ista.Repository.FileSystem.Useres
{
    public class UserRepository : IUserRepository
    {
        User IUserRepository.FindById(Guid userId)
        {
            var users = FileHelper.GetData<User[]>("Users", new User[] { });

            var json = System.Text.Json.JsonSerializer.Serialize(users);

            return users
                .Where(u => u.Id == userId)
                .DefaultIfEmpty(User.Empty)
                .First();
        }
    }
}
