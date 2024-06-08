// Ignore Spelling: Validator

using ServiceStack;
using ServiceStack.FluentValidation;
using ServiceStack.FluentValidation.Results;

using Int2Roman.ServiceModel;
using System.Linq;

namespace Int2Roman.ServiceInterface;

public class Int2RomanDTOValidator : AbstractValidator<Int2RomanDTO>
{
    /// <summary>
    /// The validator rules that will be enforced in the DTO
    /// </summary>
    public Int2RomanDTOValidator()
    {
        RuleFor(r => r.Number).GreaterThan(0)
                              .WithMessage($"Number  must be greater that zeros");

        RuleFor(r => r.Number).LessThanOrEqualTo(1_000_000)
                              .WithMessage("Number must be less or equal 1,000,000");
    }

    /// <summary>
    /// Validates the DTO using the Validator rules
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static ResponseStatus ValidateDTO(Int2RomanDTO request)
    {
        Int2RomanDTOValidator validator = new();
        ValidationResult errors = validator.Validate(request);

        ResponseStatus rs = new();

        if (errors.Errors.Count == 0)
        {
            return rs;
        }
        rs.ErrorCode = errors.Errors.First().ErrorCode;
        rs.Message = errors.Errors.First().ErrorMessage;

        return rs;

    }
}
