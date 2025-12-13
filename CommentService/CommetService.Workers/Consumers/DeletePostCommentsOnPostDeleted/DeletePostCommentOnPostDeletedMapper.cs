using AutoMapper;
using CommentService.Application.UseCases.DeletePostComments;
using Shared.Events.Comment;

namespace CommetService.Workers.Consumers.DeletePostCommentsOnPostDeleted
{
    internal class DeletePostCommentOnPostDeletedMapper : Profile
    {
        public DeletePostCommentOnPostDeletedMapper()
        {
            CreateMap<DeletePostCommentsResponse_Content, CommentDeletedEvent_Content>();
            CreateMap<DeletePostCommentsResponse_Comment, CommentDeletedEvent>();
        }
    }
}
