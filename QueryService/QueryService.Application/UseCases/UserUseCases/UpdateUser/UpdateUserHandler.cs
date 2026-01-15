using MediatR;
using QueryService.Domain.UserDomain;

namespace QueryService.Application.UseCases.UserUseCases.UpdateUser
{
    internal class UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : IRequestHandler<UpdateUserRequest>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var prev = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (prev != null && request.Version <= prev.Version)
                return;

            if (prev == null && request.IsDeleted)
                return;

            if (prev != null && request.IsDeleted)
            {
                _userRepository.Delete(prev);
                await _unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            var media = request.Media.Where(x => !x.IsDeleted);

            if (prev != null)
            {
                prev.Set(
                    request.UpdatedAt,
                    request.Version,
                    request.IsDeleted,
                    request.Name,
                    request.Username,
                    request.Gender,
                    media
                );
                await _unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            var next = new User(
                request.Id,
                request.CreatedAt,
                request.UpdatedAt,
                request.Version,
                request.IsDeleted,
                request.Name,
                request.Username,
                request.Gender,
                media
            );
            await _userRepository.CreateAsync(next, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
