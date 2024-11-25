
using RailTrip.Application.Abstractions.Messaging;

namespace RailTrip.Application.RailOperators.Queries.GetRailOperatorById
{
    public sealed record GetRailOperatorByIdQuery(Guid RailOperatorId) : IQuery<RailOperatorResponse>;
}
