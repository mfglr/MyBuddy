using AutoMapper;
using CommentService.Domain;

namespace CommentService.Application.UseCases.DeleteComentReplies
{
    internal class DeleCommentRepliesMapper : Profile
    {
        public DeleCommentRepliesMapper()
        {
            CreateMap<Content, DeleteCommentRepliesResponse_Content>();
            CreateMap<Comment, DeleteCommentRepliesResponse_Comment>();
        }
    }
}
