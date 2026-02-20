using MassTransit;
using MediatR;
using StudyProgramService.Domain.Abstracts;
using StudyProgramService.Domain.Entities;
using StudyProgramService.Domain.ValueObjects;

namespace StudyProgramService.Application.UseCases.CreateSP
{
    internal class CreateSPHandler(IUnitOfWork unitOfWork, CreateSPMapper mapper, IIdentityService identityService, ISPRepository studyProgramRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<CreateSPRequest, CreateSPResponse>
    {
        public async Task<CreateSPResponse> Handle(CreateSPRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var title = new SPTitle(request.Title);
            var description = new SPDescription(request.Description);
            var dailyStudyTarget = new SPDailyStudyTarget(request.DailyStudyTarget);
            var daysPerWeek = new SPDaysPerWeek(request.DaysPerWeek);
            var durationInWeeks = new SPDurationInWeeks(request.DurationInWeeks);
            var currency = new SPCurrency(request.Currency);
            var price = new SPMoney(request.Money, currency);
            var capacity = new SPCapacity(request.Capacity);
            var enrollmentStrategy = new SPEnrollmentStrategy(request.EnrollmentStrategy);

            var studyProgram = new SP(userId, title, description, dailyStudyTarget, daysPerWeek, durationInWeeks, price, enrollmentStrategy);
            studyProgram.Create();
            await studyProgramRepository.CreateAsync(studyProgram, cancellationToken);
            
            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(studyProgram, capacity.Value);
            await publishEndpoint.Publish(@event, cancellationToken);

            return new(studyProgram.Id);
        }
    }
}
