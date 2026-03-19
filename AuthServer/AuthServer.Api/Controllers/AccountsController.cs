using AuthServer.Application.UseCases.CreateAccount;
using AuthServer.Application.UseCases.DeleteAccount;
using AuthServer.Application.UseCases.UpdateEmail;
using AuthServer.Application.UseCases.UpdateName;
using AuthServer.Application.UseCases.UpdateUserName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class AccountsController(ISender sender) : ControllerBase
    {
        [Authorize("account")]
        [HttpPost]
        public Task<CreateAccountResponse> Create(CreateAccountRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [Authorize(Policy = "account", Roles = "user")]
        [HttpPut]
        public Task UpdateEmail(UpdateEmailRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [Authorize(Policy = "account", Roles = "user")]
        [HttpPut]
        public Task UpdateUserName(UpdateUserNameRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [Authorize(Policy = "account", Roles = "user")]
        [HttpPut]
        public Task UpdateName(UpdateNameRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [Authorize(Policy = "account", Roles = "user")]
        [HttpDelete]
        public Task Delete(DeleteAccountRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
