namespace StudyProgramService.Domain
{
    public class Currency
    {

        private class Values
        {
            public readonly static string TRY = "TRY";
            public readonly static string USD = "USD";
            public readonly static string EUR = "EUR";

            public static bool IsValid(string value)
            {
                string v = value.Trim().ToUpper();
                return
                    v == TRY ||
                    v == USD ||
                    v == EUR;
            }
        }

        public string Value { get; private set; }

        public Currency(string value)
        {
            if (!Values.IsValid(value))
                throw new InvalidCurrencyException();
            Value = value;
        }

        public static Currency TL() => new (Values.TRY);

        public static bool operator==(Currency x, Currency y) => x.Value == y.Value;
        public static bool operator !=(Currency x, Currency y) => x.Value != y.Value;
    }
}
