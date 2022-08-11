using CommunityGrouping.Entities.Dto;
using FluentValidation;

namespace CommunityGrouping.Business.ValidationRules.FluentValidation;

public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(request => request.Email).EmailAddress().NotEmpty();
        RuleFor(request => request.Password).NotEmpty();
    }
}