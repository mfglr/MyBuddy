using AutoMapper;
using QueryService.Application.UseCases.CommentUseCases.UpdateComent;
using Shared.Events.Comment;

namespace QueryService.Workers.Consumers.CommentDomain.RestoreComment
{
    internal class RestoreCommentMapper : Profile
    {
        public RestoreCommentMapper()
        {
            CreateMap<CommentRestoredEvent_Content, UpdateCommentRequest_Content>();
            CreateMap<CommentRestoredEvent, UpdateCommentRequest>();
        }
    }
}
