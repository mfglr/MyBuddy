using MediatR;
using StudyProgramInviteService.Domain;

namespace StudyProgramInviteService.Application.UseCases.InvalidateSPICreation
{
    internal class InvalidateSPICreationHandler(ISPIRepository spiRepository, IUnitOfWork unitOfWork) : IRequestHandler<InvalidateSPICreationRequest>
    {
        public async Task Handle(InvalidateSPICreationRequest request, CancellationToken cancellationToken)
        {
            var spi =
                await spiRepository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken) ??
                throw new SPINotFoundException();
            spi.InvalidaCreation(request.InvalidationReason);
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
