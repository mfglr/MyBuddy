namespace MediaService.Application.UseCases.SetMediaModerationResult
{
    public record SetMediaModerationResultRequest(Guid Id, int Hate, int SelfHarm, int Sexual, int Violance);
}
