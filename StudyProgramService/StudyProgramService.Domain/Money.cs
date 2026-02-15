namespace StudyProgramService.Domain
{
    public class Money
    {
        public decimal Value { get; private set; }
        public Currency Currency { get; private set; }

        public Money(decimal value, Currency currency)
        {
            if (value < 0)
                throw new InvalidMoneyValueException();

            Value = value;
            Currency = currency;
        }

        public static Money TL(decimal value) => new(value, Currency.TL());

        public static bool operator==(Money x, Money y) => x.Value == y.Value && x.Currency == y.Currency;
        public static bool operator!=(Money x, Money y) => x.Value != y.Value || x.Currency != y.Currency;

        public static Money operator +(Money x, Money y)
        {
            if (x.Currency != y.Currency)
                throw new CurrenciesNotMatchException();
            return new(x.Value + y.Value, x.Currency);
        }
        public static Money operator -(Money x, Money y)
        {
            if (x.Currency != y.Currency)
                throw new CurrenciesNotMatchException();
            return new(x.Value - y.Value, x.Currency);
        }
        public void operator +=(Money x)
        {
            if (x.Currency != Currency)
                throw new CurrenciesNotMatchException();
            Value += x.Value;
        }
        public void operator -=(Money x)
        {
            if (x.Currency != Currency)
                throw new CurrenciesNotMatchException();

            var value = Value - x.Value;
            if (value < 0)
                throw new InvalidMoneyValueException();
            
            Value = value;
        }
    }
}
