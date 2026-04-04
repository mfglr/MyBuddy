using AuthServer.Domain;

namespace AuthServer.Application.UseCases.GetById
{
    internal class GetByIdMapper
    {
        public GetByIdReponse Map(Account account) =>
            new(
                Guid.Parse(account.Id),
                account.DeletedAt,
                account.IsDeleted,
                account.Version,
                account.Name?.Value,
                account.UserName!,
                account.Media.FirstOrDefault()
            );
    }
}
