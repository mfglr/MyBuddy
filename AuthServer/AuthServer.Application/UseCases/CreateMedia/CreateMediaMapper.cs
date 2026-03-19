using AuthServer.Domain;
using Shared.Events.Account;

namespace AuthServer.Application.UseCases.CreateMedia
{
    internal class CreateMediaMapper
    {
        public AccountMediaCreatedEvent Map(Account account, Media.Models.Media mediaCreated) =>
            new(
                Guid.Parse(account.Id),
                account.CreatedAt,
                account.UpdatedAt,
                account.DeletedAt,
                account.IsDeleted,
                account.Version,
                account.UserName!,
                account.Name?.Value,
                account.Gender.Value,
                account.Media,
                mediaCreated
            );
    }
}
