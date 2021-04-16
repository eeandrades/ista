using AutoMapper;
using Ista.Api.Rest.Model;
using Ista.Api.Rest.Model.Cards;
using Ista.Application.Cards.Commands.Cards.Create;
using Ista.Application.Cards.Commands.Cards.Update;

namespace Ista.Api.Rest.AutoMapper.Cards
{
    public class CardAutoMapper : Profile
    {

        public CardAutoMapper()
        {
            CreateMap<CardRequestModel, CreateCardRequest>();
            CreateMap<CreateCardResponse, CreateResponseModel>();


            CreateMap<CardRequestModel, UpdateCardRequest>();
            CreateMap<UpdateCardResponse, ResponseModel>();

        }
    }
}
