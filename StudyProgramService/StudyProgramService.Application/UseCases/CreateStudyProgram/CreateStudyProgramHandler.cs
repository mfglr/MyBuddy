using MassTransit;
using MediatR;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;
using StudyProgramService.Domain.StudyProgramAggregate.Entities;
using StudyProgramService.Domain.StudyProgramAggregate.ValueObjects;

namespace StudyProgramService.Application.UseCases.CreateStudyProgram
{
    internal class CreateStudyProgramHandler(CreateStudyProgramMapper mapper, IIdentityService identityService, IStudyProgramRepository studyProgramRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<CreateStudyProgramRequest, CreateStudyProgramResponse>
    {
        public async Task<CreateStudyProgramResponse> Handle(CreateStudyProgramRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var title = new StudyProgramTitle(request.Title);
            var description = new StudyProgramDescription(request.Description);
            var dailyStudyTarget = new StudyProgramDailyStudyTarget(request.DailyStudyTarget);
            var daysPerWeek = new StudyProgramDaysPerWeek(request.DaysPerWeek);
            var durationInWeeks = new StudyProgramDurationInWeeks(request.DurationInWeeks);
            var studySchedule = new StudyProgramSchedule(dailyStudyTarget, daysPerWeek, durationInWeeks);
            var currency = new StudyProgramCurrency(request.Currency);
            var price = new StudyProgramMoney(request.Money, currency);
            var capacity = new StudyProgramCapacity(request.Capacity);

            var studyProgram = new StudyProgram(userId, title, description, studySchedule, price, capacity);
            studyProgram.Create();
            await studyProgramRepository.CreateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event,cancellationToken);

            return new(studyProgram.Id);
        }
    }
}
