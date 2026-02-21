using Shared.Events.StudyProgramService.StudyProgramInvite;

namespace StudyProgramInviteService.Domain
{
    public class SPI
    {
        public Guid StudyProgramId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public int Version { get; private set; }
        public Guid StudyProgramOwnerId { get; private set; }

        internal SPI(Guid studyProgramId, Guid userId, Guid studyProgramOwnerId)
        {
            StudyProgramId = studyProgramId;
            UserId = userId;
            StudyProgramOwnerId = studyProgramOwnerId;
        }
        internal void Create()
        {
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
            Version = 1;
            _states.Add(SPIState.CreationValidating());
        }
        private void Update()
        {
            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Delete()
        {
            IsDeleted = true;
            Update();
        }
        public void Restore()
        {
            if (!IsDeleted)
                throw new CannotRestoreActiveEntityException();
            IsDeleted = false;
            Update();
        }


        
        private readonly List<SPIState> _states = [];
        public IReadOnlyCollection<SPIState> States => _states;
        public bool IsCreationValidationCompleted => _states.Count(x => x.StateValue == SPIStateValue.CreationValidating) == 3;
        public void ValidateCreation()
        {
            _states.Add(SPIState.CreationValidated());
            Update();
        }
        public void InvalidaCreation(SPIInvalidationReason invalidationReason)
        {
            _states.Add(SPIState.CreationInvalidated(invalidationReason));
            Update();
        }
    }
}
