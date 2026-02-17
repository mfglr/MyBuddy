namespace StudyProgramApplicationService.Application
{
    internal class WorkerIdProvider
    {
        public Guid WorkerId = default;

        public void Validate(Guid workerId)
        {
            if (WorkerId != workerId)
                throw new UnauthorizedException();
        }
    }
}
