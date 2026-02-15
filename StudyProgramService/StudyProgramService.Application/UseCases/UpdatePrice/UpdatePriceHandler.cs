using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.UpdatePrice
{
    internal class UpdatePriceHandler(UpdatePriceMapper mapper, IIdentityService identityService, IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository) : IRequestHandler<UpdatePriceRequest>
    {
        public async Task Handle(UpdatePriceRequest request, CancellationToken cancellationToken)
        {
            var currency = new Currency(request.Currency);
            var price = new Money(request.Price, currency);

            var studyProgram =
                await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.UpdatePrice(price);
            await studyProgramRepository.UpdateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
