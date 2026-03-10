using MediaService.Domain;
using Shared.Events.SharedObjects;

namespace MediaService.Application
{
    public class MediaPreprocessingCompletionEvaluator
    {
        private Func<Media,bool>[,] _funcs = new Func<Media,bool>[
            Enum.GetValues<MetadataState>().Length,
            Enum.GetValues<ModerationState>().Length
        ];

        public MediaPreprocessingCompletionEvaluator()
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

        public bool IsPreprocessingCompleted(Media media) => 
            _funcs[(int)media.Instruction.MetadataState, (int)media.Instruction.ModerationState](media);

        private static bool IsValidMetadata(Media media) =>
            media.Metadata != null &&
            media.Instruction.IsValidMetadata(media.Metadata);

        private static bool IsNotValidMetadata(Media media) =>
            media.Metadata != null &&
            !media.Instruction.IsValidMetadata(media.Metadata);

        private static bool IsValidModerationResult(Media media) =>
            media.ModerationResult != null &&
            media.Instruction.IsValidModerationResult(media.ModerationResult);

        private static bool IsNotValidModerationResult(Media media) =>
            media.ModerationResult != null &&
            !media.Instruction.IsValidModerationResult(media.ModerationResult);

        private static bool IsThumbnailsAndTranscodingsPreprocessingCompleted(Media media) =>
            media.Instruction.ThumbnailInstructions.Count == media.Thumbnails.Count &&
            (
                media.Type == MediaType.Image ||
                media.Instruction.TranscodingInstructions.Count == media.Transcodings.Count
            );

        //metadata state => Should Not Calculate
        //moderation state => Should Not Calculate
        private static bool Func00(Media media) =>
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Not Calculate
        //moderation state => Should Calculate And Not Validate
        private static bool Func01(Media media) =>
            media.ModerationResult != null &&
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Not Calculate
        //moderation state => Should Calculate And Validate
        private static bool Func02(Media media) =>
            IsNotValidModerationResult(media) ||
            (
                IsValidModerationResult(media) &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Not Validate
        //moderation state => Should Not Calculate
        private static bool Func10(Media media) =>
            media.Metadata != null &&
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Calculate And Not Validate
        //moderation state => Should Calculate Not Validate
        private static bool Func11(Media media) =>
            media.Metadata != null &&
            media.ModerationResult != null &&
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Calculate And Not Validate
        //moderation state => Should Calculate And Validate
        private static bool Func12(Media media) =>
            IsNotValidModerationResult(media)||
            (
                media.Metadata != null &&
                IsValidModerationResult(media) &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Validate
        //moderation state => Should Not Calculate
        private static bool Func20(Media media) =>
            IsNotValidMetadata(media)||
            (
                IsValidMetadata(media) &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Validate
        //moderation state => Should Calculate And Not Validate
        private static bool Func21(Media media) =>
            IsNotValidMetadata(media) ||
            (
                IsValidMetadata(media) &&
                media.ModerationResult != null &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Validate
        //moderation state => Should Calculate And Validate
        private static bool Func22(Media media) =>
            IsNotValidMetadata(media) ||
            (
                (
                    IsValidMetadata(media) && 
                    IsNotValidModerationResult(media)
                ) ||
                (
                    IsValidMetadata(media) &&
                    IsValidModerationResult(media) &&
                    IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
                )
            );

    }
}
