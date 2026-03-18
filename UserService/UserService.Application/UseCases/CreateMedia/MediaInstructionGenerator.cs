using Media.Models;

namespace UserService.Application.UseCases.CreateMedia
{
    internal class MediaInstructionGenerator
    {
        public MediaInstruction Generate() =>
            new() {
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
                    new (1080,false),
                    new (120, true),
                    new (240, true)
                ],
                TranscodingInstructions = [
                    new(720)
                ]
            };
    }
}
