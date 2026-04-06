using MediatR;
using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Application.UseCases.UpdatePostUser
{
    internal class UpdatePostUserHandler(
        IPostProjectionRepository repository,
        UpdatePostUserMapper mapper
        
    ) : IRequestHandler<UpdatePostUserRequest>
    {
        public async Task Handle(UpdatePostUserRequest request, CancellationToken cancellationToken)
        {
            var user = mapper.Map(request);
            var tuples = await repository.GetPostByUserAsync(request.Id.ToString(), request.Version, null, 250, cancellationToken);

            var tuplesUpdated = new List<(PostProjection pp, long? pt, long? sn)>(); 
            foreach(var tuple in tuples)
                if(tuple.postProjection.TryUpdateUser(user))
                    tuplesUpdated.Add(tuple);

            await repository.UpdateManyAsync(tuplesUpdated, cancellationToken);
        }
    }
}
