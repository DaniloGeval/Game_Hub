using FluentValidation;
using Game_Hub.Models;

namespace Game_Hub.Validators
{
    public class GameSubmissionValidator : AbstractValidator<GameSubmissionViewModel>
    {
        public GameSubmissionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0).WithMessage("ID не може бути від'ємним.");

            RuleFor(x => x.GameTitle)
                .NotEmpty().WithMessage("Назва гри є обов'язковою.")
                .Length(2, 100).WithMessage("Назва має містити від 2 до 100 символів.");

            RuleFor(x => x.DeveloperStudio)
                .NotEmpty().WithMessage("Вкажіть студію-розробника.");

            // Правило для nullable поля (перевіряємо тільки якщо воно заповнене)
            RuleFor(x => x.ReleaseYear)
                .InclusiveBetween(1970, 2030).WithMessage("Рік випуску має бути в межах від 1970 до 2030.")
                .When(x => x.ReleaseYear.HasValue);

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Ціна не може бути від'ємною.")
                .When(x => x.Price.HasValue);

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Оберіть категорію гри.");

            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("Email є обов'язковим.")
                .EmailAddress().WithMessage("Введіть коректну електронну адресу.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Опис не може бути порожнім.")
                .MinimumLength(10).WithMessage("Опис має містити хоча б 10 символів.");

            RuleFor(x => x.AgeRating)
                .InclusiveBetween(0, 21).WithMessage("Віковий рейтинг має бути від 0 до 21.")
                .When(x => x.AgeRating.HasValue);

            RuleFor(x => x.IsMultiplayer)
                .NotNull();
        }
    }
}