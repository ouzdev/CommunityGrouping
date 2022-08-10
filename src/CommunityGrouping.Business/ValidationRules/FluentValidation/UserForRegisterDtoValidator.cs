using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Entities.Dto;
using FluentValidation;

namespace CommunityGrouping.Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(request => request.Email).EmailAddress().NotEmpty();
            RuleFor(request => request.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Equal(request => request.ConfirmPassword).WithMessage("Parolalar Uyuşmuyor");
            RuleFor(request => request.ConfirmPassword).NotEmpty();

        }
    }
}
