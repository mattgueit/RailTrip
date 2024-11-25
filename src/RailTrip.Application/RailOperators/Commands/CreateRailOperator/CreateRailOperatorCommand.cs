using RailTrip.Application.Abstractions.Messaging;

namespace RailTrip.Application.RailOperators.Commands.CreateRailOperator
{
    public sealed record CreateRailOperatorCommand(string Name, string ContactNumber, string OperatingRegion) : ICommand<Guid>;
}
