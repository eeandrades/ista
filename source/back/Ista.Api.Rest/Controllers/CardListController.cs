using Ista.Application.Cards.Commands.CardsList.Create;
using Ista.Application.Cards.Commands.CardsList.Update;
using Ista.Application.Cards.Queries.GetCardListById;
using Ista.Application.Cards.Queries.GetCardListByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Ista.Application.Cards.Commands.Cards.Create;
using Ista.Application.Cards.Commands.Cards.Update;
using Ista.Api.Rest.Model.CardsList;
using Ista.Api.Rest.Model;
using Ista.Application.Cards;
using System.Linq;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using FluentValidation.Results;
using Aeon.Domain;
using Ista.Api.Rest.Model.Cards;
using Ista.Api.Rest.Model.GetCardListById;
using Ista.Api.Rest.Model.GetCardListByUser;

namespace Ista.Api.Rest.Controllers
{
    [Route("api/card-list")]
    public class CardListController : ControllerBase
    {

        private ObjectResult CreateObjectResult(int successStatusCode, int errorStatusCode, ResponseModel response)
        {
            var statusCode = response.IsValid ? successStatusCode : errorStatusCode;
            return base.StatusCode(statusCode, response);
        }

        private ObjectResult CreateObjectResult(int successStatusCode, ResponseModel response)
        {
            return this.CreateObjectResult(successStatusCode, StatusCodes.Status400BadRequest, response);
        }

        private Guid GetUserId()
        {
            if (this.Request.Headers.TryGetValue("Token", out var token))
            {
                return Guid.Parse(token.ToString());
            }
            else
            {
                throw new Exception("Não autorizado");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseModel))]
        public async Task<ObjectResult> CreateCardList([FromServices] IMapper mapper, [FromServices] IMediator mediator, [FromBody] CardListRequestModel request)
        {
            var commandRequest = mapper.Map<CreateCardListRequest>(request);

            commandRequest.OwnerUserId = this.GetUserId();

            var commandResult = await mediator.Send(commandRequest);

            var response = mapper.Map<CreateResponseModel>(commandResult);

            return this.CreateObjectResult(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        [Route("{cardListId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseModel))]
        public async Task<ObjectResult> UpdateCardList([FromServices] IMapper mapper, [FromServices] IMediator mediator, Guid cardListId, [FromBody] UpdateCardListRequest request)
        {
            var commandRequest = mapper.Map<UpdateCardListRequest>(request);
            commandRequest.CardListId = cardListId;
            commandRequest.OwnerUserId = this.GetUserId();
            
            var commandResult = await mediator.Send(commandRequest);

            var response = mapper.Map<ResponseModel>(commandResult);

            return this.CreateObjectResult(StatusCodes.Status200OK, response);
        }


        [HttpPost]
        [Route("{cardListId}/Cards")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseModel))]
        public async Task<ObjectResult> CreateCard
            ([FromServices] IMapper mapper, [FromServices] IMediator mediator, [FromRoute] Guid cardListId, [FromBody] CardRequestModel request)
        {
            var commandRequest = mapper.Map<CreateCardRequest>(request);
            commandRequest.CardListId = cardListId;
            commandRequest.OwnerUserId = this.GetUserId();
            
            var commandResult = await mediator.Send(commandRequest);

            var response = mapper.Map<CreateResponseModel>(commandResult);

            return this.CreateObjectResult(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        [Route("{cardListId}/Cards/{cardId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseModel))]
        public async Task<ObjectResult> UpdateCard
            ([FromServices] IMapper mapper, [FromServices] IMediator mediator, [FromRoute] Guid cardListId, Guid cardId, [FromBody] CardRequestModel request)
        {
            var commandRequest = mapper.Map<UpdateCardRequest>(request);
            commandRequest.CardListId = cardListId;
            commandRequest.OwnerUserId = this.GetUserId();
            commandRequest.CardId = cardId;

            var commandResult = await mediator.Send(commandRequest);

            var response = mapper.Map<ResponseModel>(commandResult);

            return this.CreateObjectResult(StatusCodes.Status200OK, response);
        }


        [HttpGet]
        [Route("{ListId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCardListByIdResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseModel))]
        public async Task<ObjectResult> GetCardListById([FromServices] IMapper mapper, [FromServices] IMediator mediator, Guid listId)
        {
            var request = new GetCardListByIdRequest()
            {
                ListId = listId,
                OwnerId = GetUserId()
            };

            var queryResult = await mediator.Send(request);

            var response = mapper.Map<GetCardListByIdResponseModel>(queryResult);

            return this.CreateObjectResult(StatusCodes.Status200OK, response);

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCardListByUserResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseModel))]
        public async Task<ObjectResult> GetCardListByUser([FromServices] IMapper mapper, [FromServices] IMediator mediator)
        {
            GetCardListByUserRequest request = new GetCardListByUserRequest()
            {
                UserId = GetUserId()
            };

            
            var queryResult= await mediator.Send(request);

            var response = mapper.Map<GetCardListByUserResponseModel>(queryResult);

            return this.CreateObjectResult(StatusCodes.Status200OK, response);
        }
    }
}
