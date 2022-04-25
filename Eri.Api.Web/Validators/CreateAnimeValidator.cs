using Eri.Api.Web.Models;
using FluentValidation;

namespace Eri.Api.Web.Validators;

public class CreateAnimeValidator : AbstractValidator<Models.Anime>
{
    public CreateAnimeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();
    }
}
