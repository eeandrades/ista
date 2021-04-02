using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ista.Commands.Cards.CreateCardList
{
    internal class CreateCardListHandler : Aeon.Domain.CommandHandler<CreateCardListRequest, CreateCardListResponse>
    {
        protected override CreateCardListResponse DoExecute(CreateCardListRequest command)
        {
            return new CreateCardListResponse()
            {
                CadListUid = Guid.NewGuid(),
            };
        }
    }
}
