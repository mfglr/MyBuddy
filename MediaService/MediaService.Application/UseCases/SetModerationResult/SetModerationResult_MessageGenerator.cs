using MediaService.Domain;
using Shared.Events.MediaService;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetModerationResult
{
    internal class SetModerationResult_MessageGenerator
    {
        private readonly Func<Media, List<object>>[,] _funcs = new Func<Media, List<object>>[
            Enum.GetValues<MetadataState>().Length,
            Enum.GetValues<ModerationState>().Length
        ];

        public SetModerationResult_MessageGenerator()
        {
            _funcs[(int)MetadataState.ShouldNotCalculate, (int)ModerationState.ShouldNotCalculate] = Func00;
            _funcs[(int)MetadataState.ShouldNotCalculate, (int)ModerationState.ShouldCalculateAndNotValidate] = Func01;
            _funcs[(int)MetadataState.ShouldNotCalculate, (int)ModerationState.ShouldCalculateAndValidate] = Func02;
            _funcs[(int)MetadataState.ShouldCalculateAndNotValidate, (int)ModerationState.ShouldNotCalculate] = Func10;
            _funcs[(int)MetadataState.ShouldCalculateAndNotValidate, (int)ModerationState.ShouldCalculateAndNotValidate] = Func11;
            _funcs[(int)MetadataState.ShouldCalculateAndNotValidate, (int)ModerationState.ShouldCalculateAndValidate] = Func12;
            _funcs[(int)MetadataState.ShouldCalculateAndValidate, (int)ModerationState.ShouldNotCalculate] = Func20;
            _funcs[(int)MetadataState.ShouldCalculateAndValidate, (int)ModerationState.ShouldCalculateAndNotValidate] = Func21;
            _funcs[(int)MetadataState.ShouldCalculateAndValidate, (int)ModerationState.ShouldCalculateAndValidate] = Func22;
        }

        public List<object> GenerateMessages(Media media) => _funcs[(int)media.Instruction.MetadataState, (int)media.Instruction.ModerationState](media);

        private static ExtractMediaMetadataMessage GenerateMetadataExtractionMessage(Media media) =>
            new (media.ContainerName, media.BlobName);

        private static List<object> GenerateThumbnailAndTranscodingMessages(Media media) =>
            [
                .. media.Instruction.ThumbnailInstructions.Select(x => new GenerateThumbnailMessage(media.ContainerName, media.BlobName, x)),
                .. media.Type == MediaType.Video
                    ? media.Instruction.TranscodingInstructions.Select(x => new TranscodeVideoMessage(media.ContainerName, media.BlobName, x))
                    : []
            ];

        //Metadata State => Should Not Calculate
        //Moderation State => Should Not Calculate
        private static List<object> Func00(Media media) => [];

        //Metadata State => Should Not Calculate
        //Moderation State => Should Calculate And Not Validate
        private static List<object> Func01(Media media) => [];

        //Metadata State => Should Not Calculate
        //Moderation State => Should Calculate And Validate
        private static List<object> Func02(Media media) =>
            media.Instruction.IsValidModerationResult(media.ModerationResult!)
                ? [ .. GenerateThumbnailAndTranscodingMessages(media)]
                : [];

        //Metadata State => Should Calculate And Not Validate
        //Moderation State => Should Not Calculate
        private static List<object> Func10(Media media) => [];

        //Metadata State => Should Calculate And Not Validate
        //Moderation State => Should Calculate And Not Validate
        private static List<object> Func11(Media media) => [];

        //Metadata State => Should Calculate And Not Validate
        //Moderation State => Should Calculate And Validate
        private static List<object> Func12(Media media) => 
            media.Instruction.IsValidModerationResult(media.ModerationResult!)
                ? [
                    GenerateMetadataExtractionMessage(media),
                     .. GenerateThumbnailAndTranscodingMessages(media)
                ]
                : [];

        //Metadata State => Should Calculate And Validate
        //Moderation State => Should Not Calculate
        private static List<object> Func20(Media media) => [];

        //Metadata State => Should Calculate And Validate
        //Moderation State => Should Calculate And Not Validate
        private static List<object> Func21(Media media) => [];

        //Metadata State => Should Calculate And Validate
        //Moderation State => Should Calculate And Validate
        private static List<object> Func22(Media media) =>
            media.Instruction.IsValidModerationResult(media.ModerationResult!)
            ? [ .. GenerateThumbnailAndTranscodingMessages(media) ]
            : [];
    }
}
