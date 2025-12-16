using AutoMapper;
using CommentService.Domain;

namespace CommentService.Application.UseCases.DeleteComentReplies
{
    internal class DeleteCommentRepliesMapper : Profile
    {
        public DeleteCommentRepliesMapper()
        {
            CreateMap<Content, DeleteCommentRepliesResponse_Content>();
            CreateMap<Comment, DeleteCommentRepliesResponse_Comment>();
        }
    }
}
