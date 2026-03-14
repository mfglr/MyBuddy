using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace UserService.Domain
{
    public class UserName
    {
        /*
            | value      | Result  |
            | ---------- | ------- |
            | .username  | invalid |
            | username.  | invalid |
            | user..name | invalid |
            
            accepted characters
            lowercase letters → a-z
            numbers → 0-9
            dot → .
            underscore → _

            accepted minimum and maximum character lengths → Min: 1, Max: 50
        */
        private readonly static string _pattern = @"^(?!.*\.\.)(?!\.)(?!.*\.$)[a-z0-9._]{1,50}$";

        public string Value { get; private set; }

        public UserName(string value)
        {
            if (IsNotValid(value))
                throw new InvalidUsernameException();
            Value = value;
        }

        public static UserName GenerateRandom() => new($"user_{Guid.NewGuid().ToString().Replace("-", "")}");

        public static bool IsNotValid(string value) =>
            string.IsNullOrEmpty(value) ||
            !Regex.IsMatch(value, _pattern);
    }
}

