using AutoMapper;
using MediatR;
using QueryService.Domain.PostDomain;

namespace QueryService.Application.UseCases.PostUseCases.UpdatePost
{
    internal class UpdatePostHandler(IPostRepository postRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdatePostRequest>
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(UpdatePostRequest request, CancellationToken cancellationToken)
        {
            if (!request.IsValidVersion)
                return;

            var prev = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

            if (prev != null && request.Version <= prev.Version)
                return;

            if (prev == null && request.IsDeleted)
                return;

            if (prev != null && request.IsDeleted)
            {
                _postRepository.Delete(prev);
                await _unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            var content = request.Content != null
                ? _mapper.Map<UpdatePostRequest_Content, PostContent>(request.Content)
                : null;
            var media = request.Media.Where(x => !x.IsDeleted);
            if (prev != null)
            {
                prev.Set(request.Version, request.UpdatedAt, content, media);
                await _unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            var next = new Post(
                request.Id,
                request.CreatedAt,
                request.UpdatedAt,
                request.UserId,
                request.Version,
                content,
                media
            );
            await _postRepository.CreateAsync(next, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
