using FirstWebApi.Model;
using FluentValidation;

namespace FirstWebApi.Validator
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter a name")
                .Length(0, 10).WithMessage("Name length should be between 0 and 10 characters");

            RuleFor(s => s.Age)
                .LessThanOrEqualTo(20).WithMessage("The age should be less than 20");


        }


    }
}

