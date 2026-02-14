namespace UserService.Application.UseCases.UpdateGender
{
    public record UpdateGenderRequest(string Gender) : MediatR.IRequest;
}
