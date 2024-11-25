using FluentValidation;

namespace RailTrip.Application.RailOperators.Commands.CreateRailOperator
{
    public sealed class CreateRailOperatorCommandValidator : AbstractValidator<CreateRailOperatorCommand>
    {
        public CreateRailOperatorCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.OperatingRegion).NotEmpty();
        }
    }
}
