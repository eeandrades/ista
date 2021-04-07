using FluentValidation.Results;
using System;

namespace Ista.Application.Cards.Queries.GetCardListById
{
    public class GetCardListByIdRequest : Aeon.Domain.RequestBase<GetCardListByIdResponse>
    {
        public Guid ListId { get; set; }

        protected override ValidationResult DoValidate() => new GetCardListByIdRequestValidator().Validate(this);


    }
}
