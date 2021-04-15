using FluentValidation.Results;
using System.Threading.Tasks;

namespace Aeon.Domain
{
    public interface IValidable
    {
        Task<ValidationResult> ValidateAsync();
        //Task<bool> ValidateAsync(out ValidationResult validationResult);
    }
}
