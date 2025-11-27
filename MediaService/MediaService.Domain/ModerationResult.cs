using System.Text.Json.Serialization;

namespace MediaService.Domain
{
    [method: JsonConstructor]
    public class ModerationResult(int hate, int selfHarm, int sexual, int violence)
    {
        public int Hate { get; private set; } = hate;
        public int SelfHarm { get; private set; } = selfHarm;
        public int Sexual { get; private set; } = sexual;
        public int Violence { get; private set; } = violence;
    }
}
