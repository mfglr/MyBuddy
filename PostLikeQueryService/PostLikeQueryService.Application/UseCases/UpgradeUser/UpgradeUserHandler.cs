using AutoMapper;
using MediatR;
using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Application.UseCases.UpgradeUser
{
    internal class UpgradeUserHandler(IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository) : IRequestHandler<UpgradeUserRequest>
    {
        public async Task Handle(UpgradeUserRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user != null && request.Version <= user.Version) return;
            if (user == null && request.IsDeleted) return;
            if(user != null && request.IsDeleted)
            {
                userRepository.Delete(user);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            var media = request.Media != null
                ? mapper.Map<UpgradeUserRequest_Media, Media>(request.Media)
                : null;
            if (user != null)
            {
                user.Upgrade(request.Version, request.Name, request.UserName, media);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }
            
            user = new User(request.Id, request.Version, request.Name, request.UserName, media);
            await userRepository.CreateAsync(user, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
