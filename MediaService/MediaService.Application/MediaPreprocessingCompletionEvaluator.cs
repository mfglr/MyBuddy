using Media.Models;

namespace MediaService.Application
{
    public class MediaPreprocessingCompletionEvaluator
    {
        private Func<Domain.Media,bool>[,] _funcs = new Func<Domain.Media,bool>[
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

        public bool IsPreprocessingCompleted(Domain.Media media) => 
            _funcs[(int)media.Instruction.MetadataState, (int)media.Instruction.ModerationState](media);

        private static bool IsValidMetadata(Domain.Media media) =>
            media.Metadata != null &&
            media.Instruction.IsValidMetadata(media.Metadata);

        private static bool IsNotValidMetadata(Domain.Media media) =>
            media.Metadata != null &&
            !media.Instruction.IsValidMetadata(media.Metadata);

        private static bool IsValidModerationResult(Domain.Media media) =>
            media.ModerationResult != null &&
            media.Instruction.IsValidModerationResult(media.ModerationResult);

        private static bool IsNotValidModerationResult(Domain.Media media) =>
            media.ModerationResult != null &&
            !media.Instruction.IsValidModerationResult(media.ModerationResult);

        private static bool IsThumbnailsAndTranscodingsPreprocessingCompleted(Domain.Media media) =>
            media.Instruction.ThumbnailInstructions.Count == media.Thumbnails.Count &&
            (
                media.Type == MediaType.Image ||
                media.Instruction.TranscodingInstructions.Count == media.Transcodings.Count
            );

        //metadata state => Should Not Calculate
        //moderation state => Should Not Calculate
        private static bool Func00(Domain.Media media) =>
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Not Calculate
        //moderation state => Should Calculate And Not Validate
        private static bool Func01(Domain.Media media) =>
            media.ModerationResult != null &&
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Not Calculate
        //moderation state => Should Calculate And Validate
        private static bool Func02(Domain.Media media) =>
            IsNotValidModerationResult(media) ||
            (
                IsValidModerationResult(media) &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Not Validate
        //moderation state => Should Not Calculate
        private static bool Func10(Domain.Media media) =>
            media.Metadata != null &&
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Calculate And Not Validate
        //moderation state => Should Calculate Not Validate
        private static bool Func11(Domain.Media media) =>
            media.Metadata != null &&
            media.ModerationResult != null &&
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Calculate And Not Validate
        //moderation state => Should Calculate And Validate
        private static bool Func12(Domain.Media media) =>
            IsNotValidModerationResult(media)||
            (
                media.Metadata != null &&
                IsValidModerationResult(media) &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Validate
        //moderation state => Should Not Calculate
        private static bool Func20(Domain.Media media) =>
            IsNotValidMetadata(media)||
            (
                IsValidMetadata(media) &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Validate
        //moderation state => Should Calculate And Not Validate
        private static bool Func21(Domain.Media media) =>
            IsNotValidMetadata(media) ||
            (
                IsValidMetadata(media) &&
                media.ModerationResult != null &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Validate
        //moderation state => Should Calculate And Validate
        private static bool Func22(Domain.Media media) =>
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
