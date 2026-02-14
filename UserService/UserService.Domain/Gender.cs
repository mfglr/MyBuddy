using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UserService.Domain
{
    [GenerateSerializer]
    [Alias("UserService.Domain.Gender")]
    public class Gender
    {
        private static class GenderNames
        {
            public readonly static string Unknown = "unkown";
            public readonly static string Male = "male";
            public readonly static string Female = "female";

            public static bool IsValid(string value)
            {
                var formattedValue = value.Trim().ToLower();

                return 
                    formattedValue == Unknown ||
                    formattedValue == Male ||
                    formattedValue == Female;
            }
                
        }

        [Id(0)]
        public string Value { get; private set; }

        [JsonConstructor]
        public Gender(string value)
        {
            if (!GenderNames.IsValid(value))
                throw new InvalidGenderNameException();
            Value = value;
        }

        public static Gender Unknown() => new(GenderNames.Unknown);
        public static Gender Male() => new(GenderNames.Male);
        public static Gender Female() => new(GenderNames.Female);

        public static bool operator ==(Gender x, Gender y) => x.Value == y.Value;
        public static bool operator !=(Gender x, Gender y) => x.Value != y.Value;

        public override bool Equals(object? obj) =>
            ReferenceEquals(this, obj) || (obj is not null && obj is Gender other && Value == other.Value);

        public override int GetHashCode() => Value.GetHashCode();
    }
}
