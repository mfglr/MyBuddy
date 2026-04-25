using AuthServer.Domain;

namespace AuthServer.Application.UseCases.GetById
{
    internal class GetByIdMapper
    {
        public GetByIdReponse_Media Map(AccountMedia media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public GetByIdReponse Map(Account account) =>
            new(
                Guid.Parse(account.Id),
                account.Version,
                account.Name?.Value,
                account.UserName!,
                account.Media.Select(Map).FirstOrDefault()
            );
    }
}
