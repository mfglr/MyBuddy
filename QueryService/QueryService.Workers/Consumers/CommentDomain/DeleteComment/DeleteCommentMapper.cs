using AutoMapper;
using QueryService.Application.UseCases.CommentUseCases.UpdateComent;
using Shared.Events.Comment;

namespace QueryService.Workers.Consumers.CommentDomain.DeleteComment
{
    internal class DeleteCommentMapper : Profile
    {
        public DeleteCommentMapper()
        {
            CreateMap<CommentDeletedEvent_Content, UpdateCommentRequest_Content>();
            CreateMap<CommentDeletedEvent, UpdateCommentRequest>();
        }
    }
}
