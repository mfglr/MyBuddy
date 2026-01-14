using MediatR;

namespace UserService.Application.UseCases.SendEmailVerificationMail
{
    public class SendEmailVerificationMailHandler(IAuthService authService, IIdentityService identityService) : IRequestHandler<SendEmailVeificationMailRequest>
    {
        private readonly IAuthService _authService = authService;
        private readonly IIdentityService _identityService = identityService;

        public async Task Handle(SendEmailVeificationMailRequest request, CancellationToken cancellationToken)
        {
            if (_identityService.IsEmailVerified())
                throw new Exception("Your email has been already verified before!");
            var userId = _identityService.UserId;
            await _authService.SendEmailVerficationMailAsync(userId, cancellationToken);
        }
    }
}
