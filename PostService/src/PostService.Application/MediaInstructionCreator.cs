using Shared.Events.SharedObjects;

namespace PostService.Application
{
    internal static class MediaInstructionCreator
    {
        public static MediaInstruction Create() =>
            new(new(180))
            {
                ModerationInstruction = new(
                    720,
                    1,
                    MaxSexual: 0
                ),
                ThumbnailInstructions = [
                    new(720,false),
                    new(360,true)
                ],
                TranscodingInstruction = new(720)
            };
    }
}
