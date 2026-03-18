using Media.Models;
using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.SetMetadata
{
    internal class SetMetadata_MessageGenerator
    {
        private readonly Func<Domain.Media, List<object>>[,] _funcs = new Func<Domain.Media, List<object>>[
            Enum.GetValues<MetadataState>().Length,
            Enum.GetValues<ModerationState>().Length
        ];

        public SetMetadata_MessageGenerator()
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

        public List<object> GenerateMessages(Domain.Media media) => _funcs[(int)media.Instruction.MetadataState, (int)media.Instruction.ModerationState](media);

        private static ClassifyMediaMessage GenerateModerationMessage(Domain.Media media) =>
            new (media.ContainerName, media.BlobName, media.Type, media.Instruction.ModerationInstruction!);

        private static List<object> GenerateThumbnailAndTranscodingMessages(Domain.Media media) =>
            [
                .. media.Instruction.ThumbnailInstructions.Select(x => new GenerateThumbnailMessage(media.ContainerName, media.BlobName, x)),
                .. media.Type == MediaType.Video
                    ? media.Instruction.TranscodingInstructions.Select(x => new TranscodeVideoMessage(media.ContainerName, media.BlobName, x))
                    : []
            ];

        //Metadata State => Should Not Calculate
        //Moderation State => Should Not Calculate
        private static List<object> Func00(Domain.Media media) => [];

        //Metadata State => Should Not Calculate
        //Moderation State => Should Calculate And Not Validate
        private static List<object> Func01(Domain.Media media) => [];

        //Metadata State => Should Not Calculate
        //Moderation State => Should Calculate And Validate
        private static List<object> Func02(Domain.Media media) => [];

        //Metadata State => Should Calculate And Not Validate
        //Moderation State => Should Not Calculate
        private static List<object> Func10(Domain.Media media) => [];

        //Metadata State => Should Calculate And Not Validate
        //Moderation State => Should Calculate And Not Validate
        private static List<object> Func11(Domain.Media media) => [];

        //Metadata State => Should Calculate And Not Validate
        //Moderation State => Should Calculate And Validate
        private static List<object> Func12(Domain.Media media) => [];

        //Metadata State => Should Calculate And Validate
        //Moderation State => Should Not Calculate
        private static List<object> Func20(Domain.Media media) =>
            media.Instruction.IsValidMetadata(media.Metadata!)
                ? [ ..GenerateThumbnailAndTranscodingMessages(media)]
                : [];

        //Metadata State => Should Calculate And Validate
        //Moderation State => Should Calculate And Not Validate
        private static List<object> Func21(Domain.Media media) =>
            media.Instruction.IsValidMetadata(media.Metadata!)
                ? [
                    GenerateModerationMessage(media),
                    .. GenerateThumbnailAndTranscodingMessages(media)
                ]
                : [];
        
        //Metadata State => Should Calculate And Validate
        //Moderation State => Should Calculate And Validate
        private static List<object> Func22(Domain.Media media) =>
            media.Instruction.IsValidMetadata(media.Metadata!)
            ? [GenerateModerationMessage(media)]
            : [];
    }
}
