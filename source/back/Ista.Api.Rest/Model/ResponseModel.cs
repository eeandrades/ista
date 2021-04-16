using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ista.Api.Rest.Model
{
    public class ResponseModel
    {
        public bool IsValid => !this.Messages.Any(m => m.Kind == UserMessageKind.Error);

        public IEnumerable<UserMessage> Messages { get; init; }

    }
    public class UserMessage
    {
        public string Message { get; set; }
        public UserMessageKind Kind { get; set; }
        public string Code { get; set; }
    }

    public enum UserMessageKind
    {
        Error = 0,
        Warning = 1,
        Info = 2
    }
}
