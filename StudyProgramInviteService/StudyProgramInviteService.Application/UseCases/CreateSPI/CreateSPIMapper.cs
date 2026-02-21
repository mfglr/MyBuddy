using Shared.Events.StudyProgramService.StudyProgramInvite;
using StudyProgramInviteService.Domain;

namespace StudyProgramInviteService.Application.UseCases.CreateSPI
{
    internal class CreateSPIMapper
    {
        public SPICreatedEvent Map(SPI spi) =>
            new(
                spi.StudyProgramId,
                spi.UserId,
                spi.CreatedAt,
                spi.UpdatedAt,
                spi.IsDeleted,
                spi.Version,
                spi.StudyProgramOwnerId
            );
    }
}
