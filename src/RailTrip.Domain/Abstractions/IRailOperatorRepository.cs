using RailTrip.Domain.Entities;

namespace RailTrip.Domain.Abstractions
{
    public interface IRailOperatorRepository
    {
        void Insert(RailOperator railOperator);
    }
}
