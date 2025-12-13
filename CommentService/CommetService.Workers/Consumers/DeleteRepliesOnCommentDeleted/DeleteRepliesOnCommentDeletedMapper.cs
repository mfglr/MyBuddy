using AutoMapper;
using CommentService.Application.UseCases.DeleteComentReplies;
using Shared.Events.Comment;

namespace CommetService.Workers.Consumers.DeleteRepliesOnCommentDeleted
{
    internal class DeleteRepliesOnCommentDeletedMapper : Profile
    {
        public DeleteRepliesOnCommentDeletedMapper()
        {
            CreateMap<DeleteCommentRepliesResponse_Content, CommentDeletedEvent_Content>();
            CreateMap<DeleteCommentRepliesResponse_Comment, CommentDeletedEvent>();
        }

    }
}
