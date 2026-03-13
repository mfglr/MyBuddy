
namespace AuthServer.Domain
{
    public class UserName
    {
        private static readonly string _validCharacters = "0123456789abcdefghijklmnopqrstuvwxyz_.-";
        public string Value { get; private set; }

        public UserName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidUserNameException();

            foreach (char c in value)
                if (!_validCharacters.Contains(c))
                    throw new InvalidUserNameException();

            Value = value;
        }

        public static UserName GenerateUserName() => new($"user_{new string([.. Guid.NewGuid().ToString().Replace("-", "").Take(8)])}");
    }
}
