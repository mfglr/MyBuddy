using MediatR;

namespace AuthServer.Application.UseCases.DeleteHardAccounts
{
    public record DeleteHardAccountsRequest(TimeSpan TimeSpan) : IRequest;
}
