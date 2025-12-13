using AutoMapper;
using CommentService.Application.UseCases.RestoreCommentReplies;
using Shared.Events.Comment;

namespace CommetService.Workers.Consumers.RestoreRepliesOnCommentRestored
{
    internal class RestoreRepliesOnCommentRestoredMapper : Profile
    {
        public RestoreRepliesOnCommentRestoredMapper()
        {
            CreateMap<RestoreCommentRepliesResponse_Content, CommentRestoredEvent_Content>();
            CreateMap<RestoreCommentRepliesResponse_Comment, CommentRestoredEvent>();
        }
    }
}
