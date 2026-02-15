using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.CreateStudyProgram
{
    internal class CreateStudyProgramHandler(CreateStudyProgramMapper mapper, IIdentityService identityService, IStudyProgramRepository studyProgramRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<CreateStudyProgramRequest, CreateStudyProgramResponse>
    {
        public async Task<CreateStudyProgramResponse> Handle(CreateStudyProgramRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var title = new Title(request.Title);
            var description = new Description(request.Description);
            var dailyStudyTarget = new DailyStudyTarget(request.DailyStudyTarget);
            var daysPerWeek = new DaysPerWeek(request.DaysPerWeek);
            var durationInWeeks = new DurationInWeeks(request.DurationInWeeks);
            var studySchedule = new Schedule(dailyStudyTarget, daysPerWeek, durationInWeeks);
            var currency = new Currency(request.Currency);
            var price = new Money(request.Money, currency);
            var capacity = new Capacity(request.Capacity);

            var studyProgram = new StudyProgram(userId, title, description, studySchedule, price, capacity);
            studyProgram.Create();
            await studyProgramRepository.CreateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event,cancellationToken);

            return new(studyProgram.Id);
        }
    }
}
