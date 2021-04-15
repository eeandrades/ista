using Aeon.Domain;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Domain.Users
{
    public class UserValidator
    {
        private readonly IUserRepository _repository;

        public UserValidator(IUserRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        async public Task UserExists(Guid userId, ValidationResult result)
        {
            var user = await this._repository.FindById(userId);
            if (user.IsEmpty)
            {
                result.AddError(($"Usuário {userId} não existe."));
            }
        }
    }
}
