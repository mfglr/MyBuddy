using Media.Models;
using MediaService.Domain;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MediaService.Infrastructure.PostgreSql
{
    internal class MediaRepository(SqlContext context) : IMediaRepository
    {
        public Task<Domain.Media?> GetByIdAsync(string containerName, string blobName, CancellationToken cancellationToken) =>
            context.Media.FirstOrDefaultAsync(x => x.ContainerName == containerName && x.BlobName == blobName, cancellationToken);

        public void Delete(Domain.Media media) =>
            context.Media.Remove(media);

        public Task CreateAsync(IEnumerable<Domain.Media> media, CancellationToken cancellationToken) =>
            context.Media.AddRangeAsync(media, cancellationToken);

        public async Task<Domain.Media?> SetMetadata(string containerName, string blobName, Metadata metadata, CancellationToken cancellationToken)
        {
            var metadataValue = JsonSerializer.Serialize(metadata);
            var sql = FormattableStringFactory.Create(@"
                    UPDATE ""Media""
                    SET ""Context.Metadata"" = {0}::jsonb
                    WHERE ""ContainerName"" = {1} and ""BlobName"" = {2}
                    RETURNING *",
                    metadataValue,
                    containerName,
                    blobName
            );
            return (await context.Media.FromSqlInterpolated(sql).AsNoTracking().ToListAsync(cancellationToken)).FirstOrDefault();
        }

        public async Task<Domain.Media?> SetModerationResult(string containerName, string blobName, ModerationResult moderationResult, CancellationToken cancellationToken)
        {
            var moderationResultValue = JsonSerializer.Serialize(moderationResult);
            var sql = FormattableStringFactory.Create(@"
                    UPDATE ""Media""
                    SET ""Context.ModerationResult"" = {0}::jsonb
                    WHERE ""ContainerName"" = {1} and ""BlobName"" = {2}
                    RETURNING *",
                    moderationResultValue,
                    containerName,
                    blobName
            );
            return (await context.Media.FromSqlInterpolated(sql).AsNoTracking().ToListAsync(cancellationToken)).FirstOrDefault();
        }

        public async Task<Domain.Media?> AddThumbnail(string containerName, string blobName, Thumbnail thumbnail, CancellationToken cancellationToken)
        {
            var thumbnailValue = JsonSerializer.Serialize(thumbnail);
            var sql = FormattableStringFactory.Create(@"
                    UPDATE ""Media""
                    SET ""Context.Thumbnails"" = ""Thumbnails"" || {0}::jsonb
                    WHERE ""ContainerName"" = {1} and ""BlobName"" = {2}
                    RETURNING *",
                    thumbnailValue,
                    containerName,
                    blobName
            );
            return (await context.Media.FromSqlInterpolated(sql).AsNoTracking().ToListAsync(cancellationToken)).FirstOrDefault();
        }

        public async Task<Domain.Media?> AddTranscoding(string containerName, string blobName, Transcoding transcoding, CancellationToken cancellationToken)
        {
            var transcodingValue = JsonSerializer.Serialize(transcoding);
            var sql = FormattableStringFactory.Create(@"
                    UPDATE ""Media""
                    SET ""Context.Transcodings"" = ""Transcodings"" || {0}::jsonb
                    WHERE ""ContainerName"" = {1} and ""BlobName"" = {2}
                    RETURNING *",
                    transcodingValue,
                    containerName,
                    blobName
            );
            return (await context.Media.FromSqlInterpolated(sql).AsNoTracking().ToListAsync(cancellationToken)).FirstOrDefault();
        }

        public async Task<Domain.Media?> GetForUpdateByIdAsync(string containerName, string blobName, CancellationToken cancellationToken)
        {
            var sql = FormattableStringFactory.Create(
                @"
                    SELECT * FROM ""Media""
                    WHERE ""ContainerName"" = {0} and ""BlobName"" = {1}
                    FOR UPDATE;
                ",
                containerName,
                blobName
            );
            return (await context.Media.FromSqlInterpolated(sql).AsTracking().ToListAsync(cancellationToken)).FirstOrDefault();
        }
    }
}
