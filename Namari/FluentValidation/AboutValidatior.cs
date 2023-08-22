using _01_EntityLayer;
using FluentValidation;

namespace Namari.FluentValidation
{
    public class AboutValidatior : AbstractValidator<About>
    {
        public AboutValidatior()
        {
            RuleFor(x=>x.Title).NotEmpty();
            RuleFor(x=>x.Title).MinimumLength(3);
            RuleFor(x=>x.Title).MaximumLength(300);
        }
    }
}
