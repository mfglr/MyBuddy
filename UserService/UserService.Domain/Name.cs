namespace UserService.Domain
{
    public class Name
    {
        public readonly static int MaxLenght = 256;
        public string Value { get; private set; }

        public Name(string value)
        {
            if (IsNotValid(value))
                throw new InvalidNameException();
            Value = value;
        }

        public static bool IsNotValid(string value) =>
            string.IsNullOrEmpty(value) ||
            value.Length > MaxLenght;
    }
}
