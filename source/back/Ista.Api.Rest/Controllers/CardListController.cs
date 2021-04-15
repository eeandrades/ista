using Ista.Application.Cards.Commands.CardsList.Create;
using Ista.Application.Cards.Commands.CardsList.Update;
using Ista.Application.Cards.Queries.GetCardListById;
using Ista.Application.Cards.Queries.GetCardsByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Ista.Application.Cards.Commands.Cards.Create;
using Ista.Application.Cards.Commands.Cards.Update;

namespace Ista.Api.Rest.Controllers
{
    [Route("api/lists")]
    public class CardListController : ControllerBase
    {

        private Guid GetUserId()
        {
            if(this.Request.Headers.TryGetValue("Token", out var token ))
            {
                return Guid.Parse(token.ToString());
            }
            else
            {
                throw new Exception("Não autorizado");
            }
        }

        [HttpPost]
        public async Task<CreateCardListResponse> CreateCardList([FromServices] IMediator mediator, [FromBody] CreateCardListRequest request)
        {
            request.OwnerUserId = GetUserId();
            return await mediator.Send(request);
        }        
        
        [HttpPut]
        [Route("{cardListId}")]
        public async Task<UpdateCardListResponse> UpdateCardList([FromServices] IMediator mediator, Guid cardListId, [FromBody] UpdateCardListRequest  request)
        {
            request.CardListId = cardListId;
            request.OwnerUserId = this.GetUserId();
            return await mediator.Send(request);
        }


        [HttpPost]
        [Route("{cardListId}/Cards")]
        public async Task<CreateCardResponse> CreateCard
            ([FromServices] IMediator mediator, [FromRoute] Guid cardListId, [FromBody] CreateCardRequest request)
        {
            request.OwnerUserId = GetUserId();
            request.CardListId = cardListId;
            return await mediator.Send(request);
        }

        [HttpPut]
        [Route("{cardListId}/Cards/{cardId}")]
        public async Task<UpdateCardResponse> UpdateCard
            ([FromServices] IMediator mediator, [FromRoute] Guid cardListId, Guid cardId, [FromBody] UpdateCardRequest request)
        {
            request.OwnerUserId = GetUserId();
            request.CardListId = cardListId;
            request.CardId = cardId;
            return await mediator.Send(request);
        }


        [HttpGet]
        [Route("{ListId}")]
        public async Task<GetCardListByIdResponse> GetCardListById([FromServices] IMediator mediator, [FromRoute] GetCardListByIdRequest request)
        {
            request.OwnerId = GetUserId();
            return await mediator.Send(request);
        }

        [HttpGet]
        public async Task<GetCardsByUserResponse> GetCardList([FromServices] IMediator mediator, [FromQuery] GetCardsByUserRequest request)
        {
            request.UserId = GetUserId();
            return await mediator.Send(request);
        }
    }
}
