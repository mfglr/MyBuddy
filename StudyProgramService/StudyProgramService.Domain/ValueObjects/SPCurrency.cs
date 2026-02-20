using StudyProgramService.Domain.Exceptions;

namespace StudyProgramService.Domain.ValueObjects
{
    public class SPCurrency
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

        public SPCurrency(string value)
        {
            if (!Values.IsValid(value))
                throw new InvalidSPCurrencyValueException();
            Value = value;
        }

        public static SPCurrency TRY() => new (Values.TRY);

        public static bool operator ==(SPCurrency x, SPCurrency y) => x.Value == y.Value;
        public static bool operator !=(SPCurrency x, SPCurrency y) => x.Value != y.Value;
    }
}
