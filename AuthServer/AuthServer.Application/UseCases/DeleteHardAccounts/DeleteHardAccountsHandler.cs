using AuthServer.Domain;
using MediatR;

namespace AuthServer.Application.UseCases.DeleteHardAccounts
{
    internal class DeleteHardAccountsHandler(IAccountRepository accountRepository) : IRequestHandler<DeleteHardAccountsRequest>
    {
        public async Task Handle(DeleteHardAccountsRequest request, CancellationToken cancellationToken)
        {
            var deletedAccounts = await accountRepository.GetDeletedAccounts(request.TimeSpan, cancellationToken);
            if (deletedAccounts.Count == 0) return;
            
            accountRepository.Delete(deletedAccounts);
        }
    }
}
