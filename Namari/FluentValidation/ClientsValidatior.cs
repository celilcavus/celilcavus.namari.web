using _01_EntityLayer;
using FluentValidation;

namespace Namari.FluentValidation
{
    public class ClientsValidatior:AbstractValidator<Clients>
    {
        private const int MIN = 3;
        private const int MAX = 50;
        public ClientsValidatior()
        {
            RuleFor(x => x.Title).MinimumLength(MIN).WithMessage($"Minumum {MIN} Karakter Olmalidir.");
            RuleFor(x => x.Title).MaximumLength(MAX).WithMessage($"Maksimum {MAX} Karakter Olmalidir.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Boş Olamaz");
        }
    }
}
