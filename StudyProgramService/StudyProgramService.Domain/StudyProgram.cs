namespace StudyProgramService.Domain
{
    public class StudyProgram
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt {  get; private set; }
        public int Version { get; private set; }
        public bool IsDeleted { get; private set; }
        public Guid UserId { get; private set; }
        public StudyProgramTitle Title { get; private set; }
        public StudyProgramDescription Description { get; private set; }
        public StudyProgramDailyStudyTarget DailyStudyTarget { get; private set; }
        public StudyProgramDaysPerWeek DaysPerWeek { get; private set; }
        public StudyProgramDurationInWeeks DurationInWeeks { get; private set; }
        public StudyProgramStatus Status { get; private set; }
        public StudyProgramMoney Price { get; private set; }
        public StudyProgramCapacity Capacity { get; private set; }

        public bool IsFree => Price == 0;

        private StudyProgram() { }

        public StudyProgram(Guid userId, StudyProgramTitle title, StudyProgramDescription description, StudyProgramDailyStudyTarget dailyStudyTarget, StudyProgramDaysPerWeek daysPerWeek, StudyProgramDurationInWeeks durationInWeeks, StudyProgramMoney price, StudyProgramCapacity capacity)
        {
            UserId = userId;
            Title = title;
            Description = description;
            DailyStudyTarget = dailyStudyTarget;
            DaysPerWeek = daysPerWeek;
            DurationInWeeks = durationInWeeks;
            Price = price;
            Capacity = capacity;
        }

        public void Create()
        {
            Id = Guid.CreateVersion7();
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            IsDeleted = false;
            Status = StudyProgramStatus.Draft;
        }
        public void MarkAsDraft()
        {
            if (Status != StudyProgramStatus.Active)
                throw new InvalidStateTransitionException();

            Status = StudyProgramStatus.Draft;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void MarkAsActive()
        {
            if (Status != StudyProgramStatus.Draft)
                throw new InvalidStateTransitionException();

            Status = StudyProgramStatus.Active;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void MarkAsInProgress()
        {
            if (Status != StudyProgramStatus.Active)
                throw new InvalidStateTransitionException();

            Status = StudyProgramStatus.InProgress;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void MarkAsCompleted()
        {
            if (Status != StudyProgramStatus.InProgress)
                throw new InvalidStateTransitionException();

            Status = StudyProgramStatus.Completed;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void Delete()
        {
            if (Status == StudyProgramStatus.InProgress)
                throw new StudyProgramDeletionNotAllowedException();

            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void UpdateSchedule(StudyProgramDailyStudyTarget dailyStudyTarget, StudyProgramDaysPerWeek daysPerWeek, StudyProgramDurationInWeeks durationInWeeks)
        {
            if (Status != StudyProgramStatus.Draft)
                throw new StudyProgramUpdateNotAllowedException();

            DailyStudyTarget = dailyStudyTarget;
            DaysPerWeek = daysPerWeek;
            DurationInWeeks = durationInWeeks;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdatePrice(StudyProgramMoney price)
        {
            if (Status != StudyProgramStatus.Draft)
                throw new StudyProgramUpdateNotAllowedException();

            Price = price;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdateTitle(StudyProgramTitle title)
        {
            if (Status != StudyProgramStatus.Draft)
                throw new StudyProgramUpdateNotAllowedException();

            Title = title;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdateDescription(StudyProgramDescription description)
        {
            if (Status != StudyProgramStatus.Draft)
                throw new StudyProgramUpdateNotAllowedException();

            Description = description;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }


        public void UpdateCapacity(StudyProgramCapacity capacity)
        {
            if (Status != StudyProgramStatus.Draft)
                throw new StudyProgramUpdateNotAllowedException();

            Capacity = capacity;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void IncreaseCapacity(int increment)
        {
            if (Status != StudyProgramStatus.Active)
                throw new StudyProgramUpdateNotAllowedException();

            Capacity += increment;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}
