namespace MediaService.Application.UseCases.SetMediaThumbnail
{
    public record SetMediaThumbnailRequest(Guid Id, string BlobName, double Resulation, bool IsSquare);
}
