using Application.Features.Brands.Commands.Create;
using FluentValidation;

namespace Application.Features.Brands.Rules;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(b => b.Name)
            .NotNull()
            .NotEmpty().WithMessage("Lütfen marka adını boş geçmeyiniz.")
            .MinimumLength(2).WithMessage("Lütfen marka adını 2 ile 100 karakter arasında giriniz")
            .MaximumLength(100).WithMessage("Lütfen marka adını 2 ile 100 karakter arasında giriniz")
            .WithMessage("Lütfen marka adını 2 ile 100 karakter arasında giriniz");
    }
}
