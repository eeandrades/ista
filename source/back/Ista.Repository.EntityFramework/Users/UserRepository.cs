using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ista.Domain.Users;
using Ista.Repository.EntityFramework.Users.Tables;

namespace Ista.Repository.EntityFramework.Users
{
    internal class UserRepository : IUserRepository
    {
        private AppContext appDbContext;

        public UserRepository(AppContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        User IUserRepository.FindById(Guid userId)
        {
            var id = userId.ToString();
            var result = appDbContext.Set<UserTable>()
                .Where(t => t.Uid == id)
                .Select(t => new User()
                {
                    Id = new Guid(t.Uid),
                    Name = t.Name,
                    Login = t.Login
                })
                //.DefaultIfEmpty(User.Empty)
                .FirstOrDefault();

            return result ?? User.Empty;
        }
    }
}
