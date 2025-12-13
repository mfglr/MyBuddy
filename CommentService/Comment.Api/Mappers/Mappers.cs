using AutoMapper;
using CommentService.Application.UseCases.CreateComment;
using CommentService.Application.UseCases.DeleteComment;
using CommentService.Application.UseCases.RestoreComment;
using CommentService.Application.UseCases.UpdateCommentContent;
using Shared.Events.Comment;

namespace Comment.Api.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<CreateCommentResponse_Content, CommentCreatedEvent_Content>();
            CreateMap<CreateCommentResponse, CommentCreatedEvent>();

            CreateMap<UpdateCommentContentResponse_Content, CommentContentUpdatedEvent_Content>();
            CreateMap<UpdateCommentContentResponse, CommentContentUpdatedEvent>();

            CreateMap<DeleteCommentResponse_Content, CommentDeletedEvent_Content>();
            CreateMap<DeleteCommentResponse, CommentDeletedEvent>();

            CreateMap<RestoreCommentResponse_Content, CommentRestoredEvent_Content>();
            CreateMap<RestoreCommentResponse, CommentRestoredEvent>();
        }
    }
}
