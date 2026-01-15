using AutoMapper;
using MediatR;
using QueryService.Domain.PostDomain;

namespace QueryService.Application.UseCases.PostUseCases.GetPostById
{
    public class GetPostByIdHandler(IPostRepository postRepository, IMapper mapper) : IRequestHandler<GetPostByIdRequest, GetPostByIdResponse>
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GetPostByIdResponse> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
        {
            var post =
               await _postRepository.GetAsNoTrackingByIdAsync(request.Id, cancellationToken) ??
               throw new Exception("Post not found exception");
            return _mapper.Map<Post, GetPostByIdResponse>(post);
        }
    }
}
