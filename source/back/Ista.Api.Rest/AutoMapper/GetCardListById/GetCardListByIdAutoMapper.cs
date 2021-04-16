using Aeon.Domain;
using AutoMapper;
using FluentValidation.Results;
using Ista.Api.Rest.Model;
using Ista.Api.Rest.Model.CardsList;
using Ista.Api.Rest.Model.GetCardListById;
using Ista.Application.Cards.Commands.CardsList.Create;
using Ista.Application.Cards.Commands.CardsList.Update;
using Ista.Application.Cards.Queries.GetCardListById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ista.Api.Rest.AutoMapper.GetCardListById
{
    public class GetCardListByIdAutoMapper : Profile
    {

        public GetCardListByIdAutoMapper()
        {
            CreateMap<GetCardListByIdResponse, GetCardListByIdResponseModel>();
        }
    }
}
