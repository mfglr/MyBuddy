namespace StudyProgramService.Domain
{
    public class StudyProgram(Guid userId, Title title, Description description, Schedule studySchedule, Money price, Capacity capacity)
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt {  get; private set; }
        public int Version { get; private set; }
        public bool IsDeleted { get; private set; }
        public Guid UserId { get; private set; } = userId;
        public Title Title { get; private set; } = title;
        public Description Description { get; private set; } = description;
        public Schedule Schedule { get; private set; } = studySchedule;
        public Status Status { get; private set; } = null!;
        public Money Price { get; private set; } = price;
        public Capacity Capacity { get; private set; } = capacity;

        public void Create()
        {
            Id = Guid.CreateVersion7();
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            IsDeleted = false;
            Status = Status.Draft();
        }
        public void MarkAsDraft()
        {
            if (IsDeleted)
                throw new StudyProgramNotFoundException();

            if (Status != Status.Active())
                throw new InvalidStateTransitionException();

            Status = Status.Draft();
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void MarkAsActive()
        {
            if (IsDeleted)
                throw new StudyProgramNotFoundException();

            if (Status != Status.Draft())
                throw new InvalidStateTransitionException();

            Status = Status.Active();
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void MarkAsInProgress()
        {
            if (IsDeleted)
                throw new StudyProgramNotFoundException();

            if (Status != Status.Active())
                throw new InvalidStateTransitionException();

            Status = Status.InProgress();
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void MarkAsCompleted()
        {
            if (IsDeleted)
                throw new StudyProgramNotFoundException();

            if (Status != Status.InProgress())
                throw new InvalidStateTransitionException();

            Status = Status.Completed();
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void Delete()
        {
            if (IsDeleted)
                throw new StudyProgramNotFoundException();

            if (Status == Status.InProgress())
                throw new StudyProgramDeletionNotAllowed();

            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void UpdateSchedule(Schedule schedule)
        {
            if (IsDeleted)
                throw new StudyProgramNotFoundException();

            if (Status != Status.Draft())
                throw new StudyProgramUpdateNotAllowedException();

            Schedule = schedule;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdatePrice(Money price)
        {
            if (IsDeleted)
                throw new StudyProgramNotFoundException();

            if (Status != Status.Draft())
                throw new StudyProgramUpdateNotAllowedException();

            Price = price;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdateTitle(Title title)
        {
            if (IsDeleted)
                throw new StudyProgramNotFoundException();

            if (Status != Status.Draft())
                throw new StudyProgramUpdateNotAllowedException();

            Title = title;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdateDescription(Description description)
        {
            if (IsDeleted)
                throw new StudyProgramNotFoundException();

            if (Status != Status.Draft())
                throw new StudyProgramUpdateNotAllowedException();

            Description = description;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdateCapacity(Capacity capacity)
        {
            if (IsDeleted)
                throw new StudyProgramNotFoundException();

            if (Status != Status.Draft())
                throw new StudyProgramUpdateNotAllowedException();

            Capacity = capacity;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}
