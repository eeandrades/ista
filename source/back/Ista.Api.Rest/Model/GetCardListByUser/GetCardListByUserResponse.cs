using System.Collections.Generic;

namespace Ista.Api.Rest.Model.GetCardListByUser
{
    public class GetCardListByUserResponseModel : ResponseModel
    {
        public IEnumerable<CardListBriefModel> Cards { get; init; }
    }
}
