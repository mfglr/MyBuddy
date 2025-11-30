using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using PostService.Application.UseCases.CreatePost;
using PostService.Application.UseCases.DeleteMedia;
using Shared.Events.Media;
using Shared.Events.PostService;

namespace PostService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostsController(IMediator mediator, IPublishEndpoint publishEndpoint) : ControllerBase
    {

        private readonly IMediator _mediator = mediator;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        [HttpPost]
        public async Task<Guid> Create([FromForm] string content, [FromForm] IFormFileCollection media, CancellationToken cancellationToken)
        {
            var client = _mediator.CreateRequestClient<CreatePostRequest>();
            var response = await client.GetResponse<CreatePostResponse>(new(content, media), cancellationToken);
            
            await _publishEndpoint.Publish(
                new PostCreatedEvent(
                    response.Message.Id,
                    response.Message.Content,
                    [..
                        response.Message.Media.Select(x => new PostCreatedEvent_Media(
                            x.ContainerName,
                            x.BlobName,
                            x.Type
                        ))
                    ]
                ),
                cancellationToken
            );   
            return response.Message.Id;
        }


        [HttpPut]
        public async Task DeleteMedia(DeleteMediaRequest request, CancellationToken cancellationToken)
        {
            var client = _mediator.CreateRequestClient<DeleteMediaRequest>();
            var response = await client.GetResponse<DeleteMediaResponse>(request, cancellationToken);
            await _publishEndpoint.Publish(
                new MediaDeletedEvent(
                    response.Message.ContainerName,
                    response.Message.BlobNames
                ),
                cancellationToken
            );
        }
    }
}
