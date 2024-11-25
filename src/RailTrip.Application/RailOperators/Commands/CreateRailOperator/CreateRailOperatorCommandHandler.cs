using RailTrip.Application.Abstractions.Messaging;
using RailTrip.Domain.Abstractions;
using RailTrip.Domain.Entities;

namespace RailTrip.Application.RailOperators.Commands.CreateRailOperator
{
    internal sealed class CreateRailOperatorCommandHandler : ICommandHandler<CreateRailOperatorCommand, Guid>
    {
        private readonly IRailOperatorRepository _railOperatorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRailOperatorCommandHandler(IRailOperatorRepository railOperatorRepository, IUnitOfWork unitOfWork)
        {
            _railOperatorRepository = railOperatorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateRailOperatorCommand request, CancellationToken cancellationToken)
        {
            var railOperator = new RailOperator(Guid.NewGuid(), request.Name, request.ContactNumber, request.OperatingRegion);

            _railOperatorRepository.Insert(railOperator);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return railOperator.Id;
        }
    }
}
