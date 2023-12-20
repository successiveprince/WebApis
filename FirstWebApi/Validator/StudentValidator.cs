using FirstWebApi.Model;
using FluentValidation;

namespace FirstWebApi.Validator
{
    public class CustomerValidator : AbstractValidator<Student>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter a name")
                .Length(0, 10).WithMessage("Name length should be between 0 and 10 characters");
        }
    }
}

