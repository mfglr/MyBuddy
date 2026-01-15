using AutoMapper;
using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.SetCommentContentModerationResult
{
    internal class SetCommentContentModerationResultMapper : Profile
    {
        public SetCommentContentModerationResultMapper()
        {
            CreateMap<Content, CommentContentModerationResultSetEvent_Content>();
            CreateMap<Comment, CommentContentModerationResultSetEvent>();
        }
    }
}
