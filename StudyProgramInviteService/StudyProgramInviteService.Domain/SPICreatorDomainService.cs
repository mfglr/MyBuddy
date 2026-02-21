namespace StudyProgramInviteService.Domain
{
    public class SPICreatorDomainService(ISPIRepository spiRepository)
    {
        public async Task<SPI> CreateAsync(Guid studyProgramId, Guid userId, Guid studyProgramOwnerId, CancellationToken cancellationToken)
        {
            if (await spiRepository.ExistAsync(studyProgramId, userId, cancellationToken))
                throw new DublicateSPIException();
            
            var spi = new SPI(studyProgramId, userId, studyProgramOwnerId);
            spi.Create();
            
            return spi;
        }
    }
}
