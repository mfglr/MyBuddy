using Media.Models;

namespace PostService.Application.UseCases.CreatePost
{
    internal class MediaInstructionCreator
    {
        public MediaInstruction Create() =>
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
                    new(1080, false),
                    new(720, false),
                    new(360, true),
                    new(240, true),
                    new(120, true),
                    new(60, true),
                ],
                TranscodingInstructions = [
                    new(720)
                ]
            };
    }
}
