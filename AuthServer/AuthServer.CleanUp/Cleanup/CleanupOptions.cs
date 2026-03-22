namespace AuthServer.CleanUp.Cleanup
{
    public class CleanupOptions(int cleanupInterval, int retentionPeriod)
    {
        public int CleanupInterval { get; private set; } = cleanupInterval;
        public int RetentionPeriod { get; private set; } = retentionPeriod;
    }
}
