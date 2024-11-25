using RailTrip.Domain.Primitives;

namespace RailTrip.Domain.Entities
{
    public sealed class RailOperator : Entity
    {
        public RailOperator(Guid id, string name, string contactNumber, string operatingRegion)
            : base(id)
        {
            Name = name;
            ContactNumber = contactNumber;
            OperatingRegion = operatingRegion;
        }

        public string Name { get; private set; }
        public string ContactNumber { get; private set; }
        public string OperatingRegion { get; private set; }
    }
}
