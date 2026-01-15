using AutoMapper;
using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.RestoreCommentReplies
{
    internal class RestoreCommentRepliesMapper : Profile
    {
        public RestoreCommentRepliesMapper()
        {
            CreateMap<Content, CommentRestoredEvent_Content>();
            CreateMap<Comment, CommentRestoredEvent>();
        }
    }
}
