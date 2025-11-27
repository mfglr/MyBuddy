namespace ContentModerator.Application
{
    public class ModerationResult(int hate, int selfHarm, int sexual, int violence)
    {
        public int Hate { get; private set; } = hate;
        public int SelfHarm { get; private set; } = selfHarm;
        public int Sexual { get; private set; } = sexual;
        public int Violence { get; private set; } = violence;

        public static ModerationResult Max(IEnumerable<ModerationResult> results)
        {
            int maxHate = 0, maxSelfHarm = 0, maxSexual = 0, maxViolence = 0;
            foreach (var result in results)
            {
                if (result.Hate > maxHate)
                    maxHate = result.Hate;
                if (result.SelfHarm > maxSelfHarm)
                    maxSelfHarm = result.SelfHarm;
                if (result.Sexual > maxSexual)
                    maxSexual = result.Sexual;
                if (result.Violence > maxViolence)
                    maxViolence = result.Violence;
            }
            return new(maxHate, maxSelfHarm, maxSexual, maxViolence);
        }
    }

    public interface IModerator
    {
        Task<ModerationResult> ClassifyImageAsync(string inputPath, CancellationToken cancellationToken);
        Task<ModerationResult> ClassifyTextAsync(string text, CancellationToken cancellationToken);
    }
}
