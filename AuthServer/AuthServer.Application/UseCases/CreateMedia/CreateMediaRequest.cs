using MediatR;
using Microsoft.AspNetCore.Http;

namespace AuthServer.Application.UseCases.CreateMedia
{
    public record CreateMediaRequest(IFormFile Media) : IRequest;
}
