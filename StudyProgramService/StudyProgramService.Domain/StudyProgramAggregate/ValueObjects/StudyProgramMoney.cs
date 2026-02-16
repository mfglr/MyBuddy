using StudyProgramService.Domain.StudyProgramAggregate.Exceptions;

namespace StudyProgramService.Domain.StudyProgramAggregate.ValueObjects
{
    public class StudyProgramMoney
    {
        public decimal Value { get; private set; }
        public StudyProgramCurrency Currency { get; private set; }

        public StudyProgramMoney(decimal value, StudyProgramCurrency currency)
        {
            if (value < 0)
                throw new InvalidMoneyValueException();

            Value = value;
            Currency = currency;
        }

        public static StudyProgramMoney TRY(decimal value) => new(value, StudyProgramCurrency.TRY());

        public static bool operator==(StudyProgramMoney x, StudyProgramMoney y) => x.Value == y.Value && x.Currency == y.Currency;
        public static bool operator!=(StudyProgramMoney x, StudyProgramMoney y) => x.Value != y.Value || x.Currency != y.Currency;

        public static StudyProgramMoney operator +(StudyProgramMoney x, StudyProgramMoney y)
        {
            if (x.Currency != y.Currency)
                throw new CurrenciesNotMatchException();
            return new(x.Value + y.Value, x.Currency);
        }
        public static StudyProgramMoney operator -(StudyProgramMoney x, StudyProgramMoney y)
        {
            if (x.Currency != y.Currency)
                throw new CurrenciesNotMatchException();
            return new(x.Value - y.Value, x.Currency);
        }
        public void operator +=(StudyProgramMoney x)
        {
            if (x.Currency != Currency)
                throw new CurrenciesNotMatchException();
            Value += x.Value;
        }
        public void operator -=(StudyProgramMoney x)
        {
            if (x.Currency != Currency)
                throw new CurrenciesNotMatchException();

            var value = Value - x.Value;
            if (value < 0)
                throw new InvalidMoneyValueException();
            
            Value = value;
        }

        public static bool operator ==(int x, StudyProgramMoney y) => x == y.Value;
        public static bool operator !=(int x, StudyProgramMoney y) => x != y.Value;
        public static bool operator ==(StudyProgramMoney x, int y) => x.Value == y;
        public static bool operator !=(StudyProgramMoney x, int y) => x.Value != y;
    }
}
