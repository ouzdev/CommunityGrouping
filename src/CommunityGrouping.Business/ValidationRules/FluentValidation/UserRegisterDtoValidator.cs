using System.Text.RegularExpressions;
using CommunityGrouping.Business.Constant;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Entities.Dto;
using FluentValidation;

namespace CommunityGrouping.Business.ValidationRules.FluentValidation
{
    public class UserRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(request => request.Email).EmailAddress().NotEmpty();
            RuleFor(request => request.Password)
                .NotEmpty()
                .Must(IsPasswordValid).WithMessage(Messages.PASSWORD_NOT_VALID)
                .Equal(request => request.ConfirmPassword).WithMessage(Messages.PASSWORD_NOT_MATCH);
            RuleFor(request => request.ConfirmPassword).NotEmpty();
        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
