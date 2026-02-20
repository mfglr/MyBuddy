using StudyProgramService.Domain.Exceptions;
using StudyProgramService.Domain.ValueObjects;

namespace StudyProgramService.Domain.Entities
{
    public class SP
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt {  get; private set; }
        public int Version { get; private set; }
        public bool IsDeleted { get; private set; }
        public Guid UserId { get; private set; }
        public SPTitle Title { get; private set; } = null!;
        public SPDescription Description { get; private set; } = null!;
        public SPDailyStudyTarget DailyStudyTarget { get; private set; } = null!;
        public SPDaysPerWeek DaysPerWeek { get; private set; } = null!;
        public SPDurationInWeeks DurationInWeeks { get; private set; } = null!;
        public SPStatus Status { get; private set; }
        public SPMoney Price { get; private set; } = null!;
        public SPEnrollmentStrategy EnrollmentStrategy { get; private set; } = null!;

        public bool IsFree => Price == 0;

        private SP() { }

        public SP(
            Guid userId,
            SPTitle title,
            SPDescription description,
            SPDailyStudyTarget dailyStudyTarget,
            SPDaysPerWeek daysPerWeek,
            SPDurationInWeeks durationInWeeks,
            SPMoney price,
            SPEnrollmentStrategy enrollmentStrategy
        )
        {
            UserId = userId;
            Title = title;
            Description = description;
            DailyStudyTarget = dailyStudyTarget;
            DaysPerWeek = daysPerWeek;
            DurationInWeeks = durationInWeeks;
            Price = price;
            EnrollmentStrategy = enrollmentStrategy;
        }

        public void Create()
        {
            Id = Guid.CreateVersion7();
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            IsDeleted = false;
            Status = SPStatus.Draft;
        }
        public void MarkAsDraft()
        {
            if (Status != SPStatus.Active)
                throw new InvalidSPStateTransitionException();

            Status = SPStatus.Draft;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void MarkAsActive()
        {
            if (Status != SPStatus.Draft)
                throw new InvalidSPStateTransitionException();

            Status = SPStatus.Active;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void MarkAsInProgress()
        {
            if (Status != SPStatus.Active)
                throw new InvalidSPStateTransitionException();

            Status = SPStatus.InProgress;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void MarkAsCompleted()
        {
            if (Status != SPStatus.InProgress)
                throw new InvalidSPStateTransitionException();

            Status = SPStatus.Completed;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void Delete()
        {
            if (Status == SPStatus.InProgress)
                throw new SPDeletionNotAllowedException();

            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void UpdateSchedule(
            SPDailyStudyTarget dailyStudyTarget,
            SPDaysPerWeek daysPerWeek,
            SPDurationInWeeks durationInWeeks
        )
        {
            if (Status != SPStatus.Draft)
                throw new SPUpdateNotAllowedException();

            DailyStudyTarget = dailyStudyTarget;
            DaysPerWeek = daysPerWeek;
            DurationInWeeks = durationInWeeks;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdatePrice(SPMoney price)
        {
            if (Status != SPStatus.Draft)
                throw new SPUpdateNotAllowedException();

            Price = price;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdateTitle(SPTitle title)
        {
            if (Status != SPStatus.Draft)
                throw new SPUpdateNotAllowedException();

            Title = title;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdateDescription(SPDescription description)
        {
            if (Status != SPStatus.Draft)
                throw new SPUpdateNotAllowedException();

            Description = description;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}
