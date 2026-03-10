using MediaService.Domain;
using Microsoft.EntityFrameworkCore;
using Shared.Events.SharedObjects;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MediaService.Infrastructure.PostgreSql
{
    internal class MediaRepository(SqlContext context) : IMediaRepository
    {
        public Task<Media?> GetByIdAsync(string containerName, string blobName, CancellationToken cancellationToken) =>
            context.Media.FirstOrDefaultAsync(x => x.ContainerName == containerName && x.BlobName == blobName, cancellationToken);

        public void Delete(Media media) =>
            context.Media.Remove(media);

        public Task CreateAsync(IEnumerable<Media> media, CancellationToken cancellationToken) =>
            context.Media.AddRangeAsync(media, cancellationToken);

        public async Task<Media?> SetMetadata(string containerName, string blobName, Metadata metadata, CancellationToken cancellationToken)
        {
            var metadataValue = JsonSerializer.Serialize(metadata);
            var sql = FormattableStringFactory.Create(@"
                    UPDATE ""Media""
                    SET ""Metadata"" = {0}::jsonb
                    WHERE ""ContainerName"" = {1} and ""BlobName"" = {2}
                    RETURNING *",
                    metadataValue,
                    containerName,
                    blobName
            );
            return (await context.Media.FromSqlInterpolated(sql).AsNoTracking().ToListAsync(cancellationToken)).FirstOrDefault();
        }

        public async Task<Media?> SetModerationResult(string containerName, string blobName, ModerationResult moderationResult, CancellationToken cancellationToken)
        {
            var moderationResultValue = JsonSerializer.Serialize(moderationResult);
            var sql = FormattableStringFactory.Create(@"
                    UPDATE ""Media""
                    SET ""ModerationResult"" = {0}::jsonb
                    WHERE ""ContainerName"" = {1} and ""BlobName"" = {2}
                    RETURNING *",
                    moderationResultValue,
                    containerName,
                    blobName
            );
            return (await context.Media.FromSqlInterpolated(sql).AsNoTracking().ToListAsync(cancellationToken)).FirstOrDefault();
        }

        public async Task<Media?> AddThumbnail(string containerName, string blobName, Thumbnail thumbnail, CancellationToken cancellationToken)
        {
            var thumbnailValue = JsonSerializer.Serialize(thumbnail);
            var sql = FormattableStringFactory.Create(@"
                    UPDATE ""Media""
                    SET ""Thumbnails"" = ""Thumbnails"" || {0}::jsonb
                    WHERE ""ContainerName"" = {1} and ""BlobName"" = {2}
                    RETURNING *",
                    thumbnailValue,
                    containerName,
                    blobName
            );
            return (await context.Media.FromSqlInterpolated(sql).AsNoTracking().ToListAsync(cancellationToken)).FirstOrDefault();
        }

        public async Task<Media?> AddTranscoding(string containerName, string blobName, Transcoding transcoding, CancellationToken cancellationToken)
        {
            var transcodingValue = JsonSerializer.Serialize(transcoding);
            var sql = FormattableStringFactory.Create(@"
                    UPDATE ""Media""
                    SET ""Transcodings"" = ""Transcodings"" || {0}::jsonb
                    WHERE ""ContainerName"" = {1} and ""BlobName"" = {2}
                    RETURNING *",
                    transcodingValue,
                    containerName,
                    blobName
            );
            return (await context.Media.FromSqlInterpolated(sql).AsNoTracking().ToListAsync(cancellationToken)).FirstOrDefault();
        }
    }
}
