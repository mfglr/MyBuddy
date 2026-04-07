namespace Media.Models
{
    public class MediaProcessingCompletionEvaluator
    {
        private Func<MediaProcessingContext,bool>[,] _funcs = new Func<MediaProcessingContext,bool>[
            Enum.GetValues<MetadataState>().Length,
            Enum.GetValues<ModerationState>().Length
        ];

        public MediaProcessingCompletionEvaluator()
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

        public bool IsProcessingCompleted(MediaProcessingContext media) => 
            _funcs[(int)media.Instruction.MetadataState, (int)media.Instruction.ModerationState](media);

        private static bool IsValidMetadata(MediaProcessingContext media) =>
            media.Metadata != null &&
            media.Instruction.IsValidMetadata(media.Metadata);

        private static bool IsNotValidMetadata(MediaProcessingContext media) =>
            media.Metadata != null &&
            !media.Instruction.IsValidMetadata(media.Metadata);

        private static bool IsValidModerationResult(MediaProcessingContext media) =>
            media.ModerationResult != null &&
            media.Instruction.IsValidModerationResult(media.ModerationResult);

        private static bool IsNotValidModerationResult(MediaProcessingContext media) =>
            media.ModerationResult != null &&
            !media.Instruction.IsValidModerationResult(media.ModerationResult);

        private static bool IsThumbnailsAndTranscodingsPreprocessingCompleted(MediaProcessingContext media) =>
            media.Instruction.ThumbnailInstructions.Count == media.Thumbnails.Count() &&
            (
                media.Type == MediaType.Image ||
                media.Instruction.TranscodingInstructions.Count == media.Transcodings.Count()
            );

        //metadata state => Should Not Calculate
        //moderation state => Should Not Calculate
        private static bool Func00(MediaProcessingContext media) =>
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Not Calculate
        //moderation state => Should Calculate And Not Validate
        private static bool Func01(MediaProcessingContext media) =>
            media.ModerationResult != null &&
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Not Calculate
        //moderation state => Should Calculate And Validate
        private static bool Func02(MediaProcessingContext media) =>
            IsNotValidModerationResult(media) ||
            (
                IsValidModerationResult(media) &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Not Validate
        //moderation state => Should Not Calculate
        private static bool Func10(MediaProcessingContext media) =>
            media.Metadata != null &&
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Calculate And Not Validate
        //moderation state => Should Calculate Not Validate
        private static bool Func11(MediaProcessingContext media) =>
            media.Metadata != null &&
            media.ModerationResult != null &&
            IsThumbnailsAndTranscodingsPreprocessingCompleted(media);

        //metadata state => Should Calculate And Not Validate
        //moderation state => Should Calculate And Validate
        private static bool Func12(MediaProcessingContext media) =>
            IsNotValidModerationResult(media)||
            (
                media.Metadata != null &&
                IsValidModerationResult(media) &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Validate
        //moderation state => Should Not Calculate
        private static bool Func20(MediaProcessingContext media) =>
            IsNotValidMetadata(media)||
            (
                IsValidMetadata(media) &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Validate
        //moderation state => Should Calculate And Not Validate
        private static bool Func21(MediaProcessingContext media) =>
            IsNotValidMetadata(media) ||
            (
                IsValidMetadata(media) &&
                media.ModerationResult != null &&
                IsThumbnailsAndTranscodingsPreprocessingCompleted(media)
            );

        //metadata state => Should Calculate And Validate
        //moderation state => Should Calculate And Validate
        private static bool Func22(MediaProcessingContext media) =>
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
