using AutoMapper;
using MediatR;
using UserQueryService.Application.Exceptions;
using UserQueryService.Domain;

namespace UserQueryService.Application.UseCases.GetById
{
    internal class GetByIdHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetByIdRequest, GetByIdResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GetByIdResponse> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            var userVersion = 
                await _userRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new UserNotFoundException();
            return _mapper.Map<User, GetByIdResponse>(userVersion.User);
        }
    }
}
