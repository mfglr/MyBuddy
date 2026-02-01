using AutoMapper;
using MediatR;
using PostQueryService.Domain.PostDomain;

namespace PostQueryService.Application.UseCases.UpsertPost
{
    internal class UpsertPostHandler(IPostRepository postRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpsertPostRequest>
    {
        public async Task Handle(UpsertPostRequest request, CancellationToken cancellationToken)
        {
            var post = await postRepository.GetByIdAsync(request.Id, cancellationToken);
            if (post != null && request.Version <= post.Version) return;
            if (post == null && request.IsDeleted) return;
            if(post != null && request.IsDeleted)
            {
                postRepository.Delete(post);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            var content = mapper.Map<UpsertPostRequest_Content, Content>(request.Content);
            var media = mapper.Map<IEnumerable<UpsertPostRequest_Media>, IEnumerable<PostMedia>>(request.Media);
            if (post != null)
                post.Set(request.UpdatedAt, request.Version, content, media);
            else
            {
                post = new Post(request.Id, request.CreatedAt, request.UpdatedAt, request.Version, request.UserId, content, media);
                await postRepository.CreateAsync(post, cancellationToken);
            }
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
