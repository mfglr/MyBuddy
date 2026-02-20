using MassTransit;
using MediatR;
using Shared.Exceptions;
using StudyProgramService.Domain.Abstracts;
using StudyProgramService.Domain.ValueObjects;

namespace StudyProgramService.Application.UseCases.UpdateSPPrice
{
    internal class UpdateSPPriceHandler(IUnitOfWork unitOfWork, UpdateSPPriceMapper mapper, IIdentityService identityService, IPublishEndpoint publishEndpoint, ISPRepository studyProgramRepository) : IRequestHandler<UpdateSPPriceRequest>
    {
        public async Task Handle(UpdateSPPriceRequest request, CancellationToken cancellationToken)
        {
            var currency = new SPCurrency(request.Currency);
            var price = new SPMoney(request.Price, currency);

            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new SPNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new AuthorizationException();

            studyProgram.UpdatePrice(price);
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
