using Aeon.Domain;
using AutoMapper;
using FluentValidation.Results;
using Ista.Api.Rest.Model;
using Ista.Api.Rest.Model.CardsList;
using Ista.Application.Cards.Commands.CardsList.Create;
using Ista.Application.Cards.Commands.CardsList.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ista.Api.Rest.AutoMapper.CardsList
{
    public class CardListAutoMapper: Profile
    {

        public CardListAutoMapper()
        {
            CreateMap<CardListRequestModel, CreateCardListRequest>();
            CreateMap<CreateCardListResponse, CreateResponseModel>();


            CreateMap<CardListRequestModel, UpdateCardListRequest>();
            CreateMap<UpdateCardListResponse, ResponseModel>();

        }
    }
}
