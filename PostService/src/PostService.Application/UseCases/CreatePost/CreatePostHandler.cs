using AutoMapper;
using MassTransit;
using MediatR;
using Orleans;
using PostService.Domain;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.CreatePost
{
    internal class CreatePostHandler(IGrainFactory grainFactory, IBlobService blobService, IMapper mapper, IIdentityService identityService, IPublishEndpoint publishEndpoint) : IRequestHandler<CreatePostRequest, CreatePostResponse>
    {
        public async Task<CreatePostResponse> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var types = CreatePostHelpers.GetMediaTypes(request.Media);
            var content = new Content(request.Content);
            var blobNames = await blobService.UploadAsync(Post.MediaContainerName, request.Media, cancellationToken);
            var media = CreatePostHelpers.GenerateMedia(types, blobNames);
            try
            {
                var postId = Guid.CreateVersion7();
                var posGrain = grainFactory.GetGrain<IPostGrain>(postId);

                await posGrain.Create(userId,content, media);

                var post = await posGrain.Get();
                var @event = mapper.Map<Post, PostCreatedEvent>(post);
                await publishEndpoint.Publish(@event, cancellationToken);
                await publishEndpoint.PublishBatch(
                    media.Select(m => new PostMediaCreatedEvent(postId,m.ContainerName,m.BlobName,(Shared.Objects.MediaType)m.Type)),
                    cancellationToken
                );
                return new(post.Id);
            }
            catch (Exception)
            {
                await blobService.DeleteAsync(Post.MediaContainerName, blobNames, cancellationToken);
                throw;
            }
        }
    }
}
