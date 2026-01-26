using AutoMapper;
using MassTransit;
using MediatR;
using Shared.Events.UserService;
using Shared.Objects;
using UserService.Domain;

namespace UserService.Application.UseCases.CreateMedia
{
    internal class CreateMediaHandler(IMapper mapper, IBlobService blobService, IUserRepository userRepository, IPublishEndpoint publishEndpoint, MediaTypeExtractor mediaTypeExtractor, IIdentityService idendityService) : IRequestHandler<CreateMediaRequest>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBlobService _blobService = blobService;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly IIdentityService _idendityService = idendityService;
        private readonly MediaTypeExtractor _mediaTypeExtractor = mediaTypeExtractor;

        public async Task Handle(CreateMediaRequest request, CancellationToken cancellationToken)
        {
            var userId = _idendityService.UserId;
            var user = 
                await _userRepository.GetByIdAsync(userId, cancellationToken) ??
                throw new UserNotFoundException();
            string? blobName = null;
            try
            {
                var type = _mediaTypeExtractor.Extract(request.Media);
                blobName = await _blobService.UploadAsync(User.MediaContainerName, request.Media, cancellationToken);
                var media = new Media(User.MediaContainerName, blobName, type);

                user.AddMedia(media);
                await _userRepository.UpdateAsync(user, cancellationToken);

                var @event = _mapper.Map<User,UserMediaCreatedEvent>(user);
                await _publishEndpoint.Publish(@event, cancellationToken);
            }
            catch (Exception)
            {
                if(blobName != null)
                    await _blobService.DeleteAsync(User.MediaContainerName, blobName, cancellationToken);
                throw;
            }
        }
    }
}
