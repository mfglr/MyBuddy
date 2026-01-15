using AutoMapper;
using MediatR;
using QueryService.Domain.CommentDomain;

namespace QueryService.Application.UseCases.CommentUseCases.UpdateComent
{
    internal class UpdateCommentHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateCommentRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
       
        public async Task Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
            var prev = await _commentRepository.GetByIdAsync(request.Id, cancellationToken);

            if (prev != null && request.Version <= prev.Version)
                return;

            if (prev == null && request.IsDeleted)
                return;

            if (prev != null && request.IsDeleted)
            {
                _commentRepository.Delete(prev);
                await _unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            if (prev != null)
            {
                var content = _mapper.Map<UpdateCommentRequest_Content, CommentContent>(request.Content);
                prev.Set(request.UpdatedAt, request.Version, content);
                await _unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            var next = _mapper.Map<UpdateCommentRequest, Comment>(request);
            await _commentRepository.CreateAsync(next, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
