using _01_EntityLayer;
using FluentValidation;
using Namari.Helper;

namespace Namari.FluentValidation
{
    public class CustomerValidatior : AbstractValidator<Customers>
    {
        public CustomerValidatior()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("FirstName boş geçilemez");
            
            RuleFor(x => x.FirstName)
                .MinimumLength(NumericConst.MIN)
                .WithMessage($"FirstName Minumum {NumericConst.MIN} Karakter olmalidir.");
            
            RuleFor(x => x.FirstName)
                .MaximumLength(NumericConst.MAX)
                .WithMessage($"FirstName Maksimum {NumericConst.MAX} Karakter olmalidir.");



            RuleFor(x => x.LastName)
               .NotEmpty()
               .WithMessage("LastName boş geçilemez");

            RuleFor(x => x.FirstName)
                .MinimumLength(NumericConst.MIN)
                .WithMessage($"LastName Minumum {NumericConst.MIN} Karakter olmalidir.");

            RuleFor(x => x.FirstName)
                .MaximumLength(NumericConst.MAX)
                .WithMessage($"LastName Maksimum {NumericConst.MAX} Karakter olmalidir.");



            RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage("Description boş geçilemez");

            RuleFor(x => x.FirstName)
                .MinimumLength(NumericConst.MIN)
                .WithMessage($"Description Minumum {NumericConst.MIN} Karakter olmalidir.");

            RuleFor(x => x.FirstName)
                .MaximumLength(NumericConst.MAXDESC)
                .WithMessage($"Description Maksimum {NumericConst.MAXDESC} Karakter olmalidir.");

            RuleFor(x => x.Image)
                .NotNull()
                .WithMessage("Image boş geçilemez");
        }
    }
}
