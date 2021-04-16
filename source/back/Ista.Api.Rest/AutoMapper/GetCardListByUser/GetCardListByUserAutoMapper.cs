using AutoMapper;
using Ista.Api.Rest.Model.GetCardListByUser;
using Ista.Application.Cards.Queries.GetCardListByUser;

namespace Ista.Api.Rest.AutoMapper.GetCardListByUser
{
    public class GetCardListByUserAutoMapper : Profile
    {

        public GetCardListByUserAutoMapper()
        {
            CreateMap<GetCardListByUserResponse, GetCardListByUserResponseModel>();
        }
    }
}
