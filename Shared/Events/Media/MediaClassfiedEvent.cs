namespace Shared.Events.Media
{
    public record MediaClassfiedEvent(Guid Id, int Hate, int SelfHarm, int Sexual, int Violence);
}
