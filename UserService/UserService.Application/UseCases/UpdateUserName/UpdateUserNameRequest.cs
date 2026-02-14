namespace UserService.Application.UseCases.UpdateUserName
{
    public record UpdateUserNameRequest(string UserName) : MediatR.IRequest;
}
