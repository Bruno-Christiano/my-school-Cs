using FluentValidation;
using MySchool.Models.Auth;
using MySchool.Models.User;

namespace MySchool.Resources.Shared.Validators;
public class LoginValidator: AbstractValidator<Auth>
{
   public LoginValidator()
   {
       int caracters = 4;
       RuleFor(auth => auth.UserName)
           .NotEmpty().WithMessage("Campo Obrigatório!")
           .DependentRules(() =>
           {
               RuleFor(auth => auth.UserName)
                   .MinimumLength(caracters).WithMessage("Mínimo 4 caracteres");
           });
       
       RuleFor((auth => auth.Password)).NotEmpty().WithMessage("Campo Obrigatório!");
   }
}