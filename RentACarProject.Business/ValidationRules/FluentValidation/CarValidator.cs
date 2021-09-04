using FluentValidation;
using RentACarProject.Entity.Concrete;

namespace RentACarProject.Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.DailyPrice).GreaterThan(0);
            RuleFor(x => x.Name).MinimumLength(2);
        }
    }
}
