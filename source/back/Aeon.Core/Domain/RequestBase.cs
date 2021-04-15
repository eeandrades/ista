using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace Aeon.Domain
{
    public abstract class RequestBase<TREsponse> : IRequest<TREsponse>
        where TREsponse : ResponseBase
    {

    }


    public abstract class RequestBase : RequestBase<ResponseBase>
    {
    }
}
