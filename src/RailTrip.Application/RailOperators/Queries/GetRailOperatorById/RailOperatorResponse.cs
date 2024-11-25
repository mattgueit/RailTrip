namespace RailTrip.Application.RailOperators.Queries.GetRailOperatorById
{
    public sealed record RailOperatorResponse(Guid Id, string Name, string ContactNumber, string OperatingRegion);
}
