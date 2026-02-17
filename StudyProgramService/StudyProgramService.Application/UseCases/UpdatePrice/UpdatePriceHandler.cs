using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.UpdatePrice
{
    internal class UpdatePriceHandler(IUnitOfWork unitOfWork, UpdatePriceMapper mapper, IIdentityService identityService, IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository) : IRequestHandler<UpdatePriceRequest>
    {
        public async Task Handle(UpdatePriceRequest request, CancellationToken cancellationToken)
        {
            var currency = new StudyProgramCurrency(request.Currency);
            var price = new StudyProgramMoney(request.Price, currency);

            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.UpdatePrice(price);
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
