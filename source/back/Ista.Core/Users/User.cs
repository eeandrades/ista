using System;

namespace Ista.Domain.Users
{
    public class User
    {
        public Guid Id { get; init; }
        public string Login { get; set; }
        public string Name { get; set; }

        public static readonly User Empty = new User()
        {
            Id = Guid.Empty,
        };
        public bool IsEmpty => this == Empty;
    }
}
