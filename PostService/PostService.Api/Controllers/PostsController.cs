using AutoMapper;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using PostService.Application.UseCases.CreatePost;
using PostService.Application.UseCases.DeletePostMedia;
using Shared.Events.PostService;

namespace PostService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostsController(IMediator mediator, IPublishEndpoint publishEndpoint, IMapper mapper) : ControllerBase
    {

        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        [HttpPost]
        public async Task<Guid> Create([FromForm] string content, [FromForm] IFormFileCollection media, CancellationToken cancellationToken)
        {
            var client = _mediator.CreateRequestClient<CreatePostRequest>();
            var response = await client.GetResponse<CreatePostResponse>(new(content, media), cancellationToken);

            await _publishEndpoint.Publish(
                _mapper.Map<CreatePostResponse,PostCreatedEvent>(response.Message),
                cancellationToken
            );
            return response.Message.Id;
        }


        [HttpPut]
        public async Task DeleteMedia(DeletePostMediaRequest request, CancellationToken cancellationToken)
        {
            var client = _mediator.CreateRequestClient<DeletePostMediaRequest>();
            var response = await client.GetResponse<DeletePostMediaResponse>(request, cancellationToken);
            
            await _publishEndpoint.Publish(
                _mapper.Map<DeletePostMediaResponse, PostMediaDeletedEvent>(response.Message),
                cancellationToken
            );
        }
    }
}
