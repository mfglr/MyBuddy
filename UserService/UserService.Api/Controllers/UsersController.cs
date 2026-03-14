using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.UseCases.CreateMedia;
using UserService.Application.UseCases.CreateUser;
using UserService.Application.UseCases.DeleteMedia;
using UserService.Application.UseCases.UpdateGender;
using UserService.Application.UseCases.UpdateName;
using UserService.Application.UseCases.UpdateUserName;

namespace UserService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UsersController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public Task Create(CreateUserRequest request, CancellationToken cancellationToken)
            => _sender.Send(request, cancellationToken);

        [HttpPut]
        public Task CreateMedia([FromForm]CreateMediaRequest request ,CancellationToken cancellationToken) =>
            _sender.Send(request, cancellationToken);

        [HttpPut]
        public Task DeleteMedia(DeleteMediaRequest request, CancellationToken cancellationToken) =>
            _sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdateName(UpdateNameRequest request, CancellationToken cancellationToken) =>
            _sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdateUserName(UpdateUserNameRequest request, CancellationToken cancellationToken) =>
            _sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdateGender(UpdateGenderRequest request, CancellationToken cancellationToken) =>
            _sender.Send(request, cancellationToken);
    }
}
