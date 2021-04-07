using FluentValidation.Results;
using System;

namespace Ista.Application.Cards.Queries.GetCardsByUser
{
    public class GetCardsByUserRequest : Aeon.Domain.RequestBase<GetCardsByUserResponse>
    {
        public Guid UserId { get; set; }

        protected override ValidationResult DoValidate() => new GetCardsByUserRequestValidator().Validate(this);


    }
}
