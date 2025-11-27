namespace Shared.Events.PostService
{
    public record PostContentClassifiedEvent(Guid Id, int Hate, int SelfHarm, int Sexual, int Violence);
}
