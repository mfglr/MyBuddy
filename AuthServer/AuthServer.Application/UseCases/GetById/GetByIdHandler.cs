using AuthServer.Domain;
using MediatR;

namespace AuthServer.Application.UseCases.GetById
{
    internal class GetByIdHandler(IAccountRepository accountRepository, GetByIdMapper mapper) : IRequestHandler<GetByIdRequest, GetByIdReponse>
    {
        public async Task<GetByIdReponse> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            var account =
                await accountRepository.GetByIdAsync(request.Id) ??
                throw new AccountNotFoundException();
            return mapper.Map(account);
        }
    }
}
