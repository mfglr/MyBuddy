using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.CreateStudyProgram
{
    internal class CreateStudyProgramHandler(IUnitOfWork unitOfWork, CreateStudyProgramMapper mapper, IIdentityService identityService, IStudyProgramRepository studyProgramRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<CreateStudyProgramRequest, CreateStudyProgramResponse>
    {
        public async Task<CreateStudyProgramResponse> Handle(CreateStudyProgramRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var title = new StudyProgramTitle(request.Title);
            var description = new StudyProgramDescription(request.Description);
            var dailyStudyTarget = new StudyProgramDailyStudyTarget(request.DailyStudyTarget);
            var daysPerWeek = new StudyProgramDaysPerWeek(request.DaysPerWeek);
            var durationInWeeks = new StudyProgramDurationInWeeks(request.DurationInWeeks);
            var currency = new StudyProgramCurrency(request.Currency);
            var price = new StudyProgramMoney(request.Money, currency);
            var capacity = new StudyProgramCapacity(request.Capacity);

            var studyProgram = new StudyProgram(userId, title, description, dailyStudyTarget, daysPerWeek, durationInWeeks, price, capacity);
            studyProgram.Create();
            await studyProgramRepository.CreateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event,cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new(studyProgram.Id);
        }
    }
}
