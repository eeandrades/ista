using Ista.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Repository.EntityFramework.Users.Tables
{
    internal class UserTable
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string  Login { get; set; }

        public User ToEntity()
        {
            return new User()
            {
                Id = Guid.Parse(this.Uid),
                Name = this.Name,
                Login = this.Login
            };
        }
    }
}
