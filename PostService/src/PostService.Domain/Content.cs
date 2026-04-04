using Media.Models;
using PostService.Domain.Exceptions;

namespace PostService.Domain
{
    public class Content
    {
        public readonly static int MinLength = 2;
        public readonly static int MaxLength = 1024;

        public string Value { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }

        private Content(string value, ModerationResult? moderationResult)
        {
            Value = value;
            ModerationResult = moderationResult;
        }

        public Content(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new PostContentException("Post content cannot be empty!");

            if (value.Length < MinLength || value.Length > MaxLength)
                throw new PostContentException($"Value length must be between {MinLength} and {MaxLength}.");

            Value = value;
            ModerationResult = null;
        }

        public Content SetModerationResult(ModerationResult result) => new (Value, result);
    }
}
