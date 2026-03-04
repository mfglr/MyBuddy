using MediatR;

namespace MediaService.Application
{
    internal class UnitOfWorkPipelineBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            await unitOfWork.CreateTransactionAsync(cancellationToken);
            var response = await next(cancellationToken);
            await unitOfWork.CommitTransactionAsync(cancellationToken);
            return response;
        }
    }
}
