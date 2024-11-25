using System.Data;
using RailTrip.Application.Abstractions.Messaging;
using RailTrip.Domain.Exceptions;
using Dapper;

namespace RailTrip.Application.RailOperators.Queries.GetRailOperatorById
{
    internal sealed class GetRailOperatorQueryHandler : IQueryHandler<GetRailOperatorByIdQuery, RailOperatorResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetRailOperatorQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<RailOperatorResponse> Handle(GetRailOperatorByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT Id, Name, ContactNumber, OperatingRegion FROM ""RailOperators"" WHERE ""Id"" == @RailOperatorId";

            var railOperator = await _dbConnection.QueryFirstOrDefaultAsync<RailOperatorResponse>(sql, new { request.RailOperatorId });

            if (railOperator == null) 
            {
                throw new RailOperatorNotFoundException(request.RailOperatorId);
            }

            return railOperator;
        }
    }
}
