using MediatR;
using StudyProgramInviteService.Domain;

namespace StudyProgramInviteService.Application.UseCases.ValidateSPICreation
{
    internal class ValidateSPICreationHandler(ISPIRepository spiRepository, IUnitOfWork unitOfWork) : IRequestHandler<ValidateSPICreationRequest>
    {
        public async Task Handle(ValidateSPICreationRequest request, CancellationToken cancellationToken)
        {
            var spi = 
                await spiRepository.GetAsync(request.StudyProgramId, request.UserId, cancellationToken) ?? 
                throw new SPINotFoundException();
            spi.ValidateCreation();
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
