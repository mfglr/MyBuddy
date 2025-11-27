namespace PostService.Application.UseCases.SetContentModerationResult
{
    public record SetContentModerationResultRequest(Guid Id, int Hate, int SelfHarm, int Sexual, int Violence);
}
