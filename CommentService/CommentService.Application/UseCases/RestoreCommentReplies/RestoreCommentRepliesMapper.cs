using AutoMapper;
using CommentService.Domain;

namespace CommentService.Application.UseCases.RestoreCommentReplies
{
    internal class RestoreCommentRepliesMapper : Profile
    {
        public RestoreCommentRepliesMapper()
        {
            CreateMap<Content, RestoreCommentRepliesResponse_Content>();
            CreateMap<Comment, RestoreCommentRepliesResponse_Comment>();
        }
    }
}
