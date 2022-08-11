using CommunityGrouping.Entities.Dto;
using FluentValidation;

namespace CommunityGrouping.Business.ValidationRules.FluentValidation;

public class PersonDtoValidator : AbstractValidator<PersonDto>
{
    public PersonDtoValidator()
    {
        RuleFor(request => request.FirstName).NotEmpty();
        RuleFor(request => request.LastName).NotEmpty();
        RuleFor(request => request.Email).NotEmpty().EmailAddress();
    }
}