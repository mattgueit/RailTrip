using RailTrip.Domain.Exceptions.Base;

namespace RailTrip.Domain.Exceptions
{
    public sealed class RailOperatorNotFoundException : NotFoundException
    {
        public RailOperatorNotFoundException(Guid railOperatorId)
            : base($"The rail operator with the identifier {railOperatorId} was not found.")
        {

        }
    }
}
