using AutoMapper;
using MediatR;
using PostQueryService.Domain.UserDomain;

namespace PostQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpsertUserRequest>
    {
        public async Task Handle(UpsertUserRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id,cancellationToken);
            if (user != null && request.Version <= user.Version) return;
            if (user == null && request.IsDeleted) return;
            if (user != null && request.IsDeleted)
            {
                userRepository.Delete(user);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            var activeMedia = request.Media.FirstOrDefault(x => x.IsActive);
            var media = activeMedia != null ? mapper.Map<UpsertUserRequest_Media, UserMedia>(activeMedia) : null;
            if (user != null)
                user.Set(request.Version, request.Name,request.UserName,media);
            else
            {
                user = new User(request.Id, request.Version, request.Name, request.UserName, media);
                await userRepository.CreateAsync(user, cancellationToken);
            }
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
