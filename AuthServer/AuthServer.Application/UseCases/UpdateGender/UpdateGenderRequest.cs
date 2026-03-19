using MediatR;

namespace AuthServer.Application.UseCases.UpdateGender
{
    public record UpdateGenderRequest(string Gender) : IRequest;
}
