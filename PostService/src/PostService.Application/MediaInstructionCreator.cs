using Media.Models;

namespace PostService.Application
{
    internal static class MediaInstructionCreator
    {
        public static MediaInstruction Create() =>
            new (){
                MetadataInstruction = new()
                {
                    Constraints = new()
                    {
                        MaxDuration = 180
                    }
                },
                ModerationInstruction = new()
                {
                    Constraints = new()
                    {
                        MaxSexual = 0
                    }
                },
                ThumbnailInstructions = [
                    new(720,false),
                    new(360,true)
                ],
                TranscodingInstructions = [
                    new(720)
                ]
            };
    }
}
