using Aeon.Domain;
using AutoMapper;
using FluentValidation.Results;
using Ista.Api.Rest.Model;
using Ista.Application.Cards;
using Ista.Application.Cards.Queries;

namespace Ista.Api.Rest.AutoMapper
{
    public class BasicAutoMapper: Profile
    {
        public BasicAutoMapper()
        {
            CreateMap<ValidationFailure, UserMessage>()
                .ForMember(d => d.Code, m => m.MapFrom(s => s.ErrorCode))
                .ForMember(d => d.Kind, m => m.MapFrom(s => s.Severity))
                .ForMember(d => d.Message, m => m.MapFrom(s => s.ErrorMessage));

            CreateMap<ResponseBase, ResponseModel>();
            CreateMap<Card, CardModel>();
            CreateMap<CardList, CardListModel>();
            CreateMap<User, UserModel>();
            CreateMap<CardListBrief, CardListBriefModel>();
        }
    }
}
