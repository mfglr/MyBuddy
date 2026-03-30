using MediatR;
using PostQueryService.Domain;

namespace PostQueryService.Application.UseCases.CreatePost
{
    public record CreatePostRequest(string Id, Post Post, User User) : IRequest;
}
