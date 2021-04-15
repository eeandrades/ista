using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ista.Domain.Users;
using Ista.Repository.EntityFramework.Users.Tables;
using Microsoft.EntityFrameworkCore;

namespace Ista.Repository.EntityFramework.Users
{
    internal class UserRepository : IUserRepository
    {
        private AppContext appDbContext;

        public UserRepository(AppContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        async Task<User> IUserRepository.FindById(Guid userId)
        {
            var id = userId.ToString();
            var userTable = await appDbContext.User
                .SingleOrDefaultAsync(c => 
                c.Uid == userId.ToString()
            );

            return userTable != null ?
                new User()
                {
                    Id = Guid.Parse(userTable.Uid),
                    Login = userTable.Login,
                    Name = userTable.Name
                }:User.Empty;
        }
    }
}
