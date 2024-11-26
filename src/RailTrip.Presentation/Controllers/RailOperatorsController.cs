using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailTrip.Application.RailOperators.Commands.CreateRailOperator;
using RailTrip.Application.RailOperators.Queries.GetRailOperatorById;

namespace RailTrip.Presentation.Controllers
{
    public sealed class RailOperatorsController : ApiController
    {
        /// <summary>
        /// Gets the rail operator with the specified identifier, if it exists.
        /// </summary>
        /// <param name="railOperatorId">The rail operator identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The rail operator with the specified identifier, if it exists</returns>
        [HttpGet("{railOperatorId:guid}")]
        [ProducesResponseType(typeof(RailOperatorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRailOperator(Guid railOperatorId, CancellationToken cancellationToken)
        {
            var query = new GetRailOperatorByIdQuery(railOperatorId);

            var railOperator = await Sender.Send(query, cancellationToken);

            return Ok(railOperator);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRailOperator([FromBody] CreateRailOperatorRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateRailOperatorCommand(request.Name, request.ContactNumber, request.OperatingRegion);

            var railOperatorId = await Sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(CreateRailOperator), new { railOperatorId }, railOperatorId);
        }
    }
}
