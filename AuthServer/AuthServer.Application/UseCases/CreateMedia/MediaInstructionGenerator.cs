using Media.Models;

namespace AuthServer.Application.UseCases.CreateMedia
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
                    new (240, true),
                    new (120, true),
                    new (60, true),
                ],
                TranscodingInstructions = [
                    new(720)
                ]
            };
    }
}
