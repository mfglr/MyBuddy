using Shared.Events.SharedObjects;

namespace UserService.Application.UseCases.CreateMedia
{
    internal class MediaInstructionGenerator
    {
        public MediaInstruction Generate() =>
            new(
                new(1)
            )
            {
                ModerationInstruction = new ModerationInstruction(
                    720,
                    1,
                    MaxSexual: 0
                ),
                ThumbnailInstructions = [
                    new ThumbnailInstruction(1080,false),
                    new ThumbnailInstruction(120,true),
                    new ThumbnailInstruction(240,true)
                ]
            };
    }
}
