using EasyDocs.Domain.ValueObjects;
using FluentValidation;

namespace EasyDocs.Domain.Validators;

public sealed class DescriptionValidator : AbstractValidator<Description>
{
    public void Validate()
    {
        RuleFor(d => d.Text)
            .NotEmpty()
            .NotNull()
            .Must(string.IsNullOrWhiteSpace)
            .WithMessage("Descrição inválida.");

        RuleFor(d => d.Text)
            .MinimumLength(3)
          .WithMessage("A descrição não deve conter menos de 3 caracteres.");

        RuleFor(d => d.Text)
          .MaximumLength(250)
          .WithMessage("A descrição não deve conter mais de 250 caracteres.");
    }
}