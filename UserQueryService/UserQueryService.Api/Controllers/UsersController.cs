using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserQueryService.Shared.Dto;
using UserQueryService.Shared.Exceptions;
using UserQueryService.Shared.Model;

namespace UserQueryService.Api.Controllers
{
    [Authorize("user_query")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UsersController(IUserRepository userRepository) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<User?> GetById(Guid id, CancellationToken cancellationToken) =>
            await userRepository.GetByIdAsync(id, cancellationToken) ?? throw new UserNotFoundException();

        [HttpGet]
        public Task<List<User>> Search([FromQuery] SearchRequest request, CancellationToken cancellationToken) =>
            userRepository.SearchAsync(request.Key.ToLower().Trim(), request.Cursor, request.PageSize, cancellationToken);
    }
}
