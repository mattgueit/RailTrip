using RailTrip.Domain.Abstractions;
using RailTrip.Domain.Entities;

namespace RailTrip.Infrastructure.Repositories
{
    public sealed class RailOperatorRepository : IRailOperatorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RailOperatorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(RailOperator railOperator)
        {
            _dbContext.Set<RailOperator>().Add(railOperator);
        }
    }
}
