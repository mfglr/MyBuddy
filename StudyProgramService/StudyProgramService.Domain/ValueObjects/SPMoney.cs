using StudyProgramService.Domain.Exceptions;

namespace StudyProgramService.Domain.ValueObjects
{
    public class SPMoney
    {
        public decimal Value { get; private set; }
        public SPCurrency Currency { get; private set; }

        private SPMoney(){ }

        public SPMoney(decimal value, SPCurrency currency)
        {
            if (value < 0)
                throw new InvalidSPMoneyValueException();

            Value = value;
            Currency = currency;
        }

        public static SPMoney TRY(decimal value) => new(value, SPCurrency.TRY());

        public static bool operator==(SPMoney x, SPMoney y) => x.Value == y.Value && x.Currency == y.Currency;
        public static bool operator!=(SPMoney x, SPMoney y) => x.Value != y.Value || x.Currency != y.Currency;

        public static SPMoney operator +(SPMoney x, SPMoney y)
        {
            if (x.Currency != y.Currency)
                throw new SPCurrenciesNotMatchException();
            return new(x.Value + y.Value, x.Currency);
        }
        public static SPMoney operator -(SPMoney x, SPMoney y)
        {
            if (x.Currency != y.Currency)
                throw new SPCurrenciesNotMatchException();
            return new(x.Value - y.Value, x.Currency);
        }
        public void operator +=(SPMoney x)
        {
            if (x.Currency != Currency)
                throw new SPCurrenciesNotMatchException();
            Value += x.Value;
        }
        public void operator -=(SPMoney x)
        {
            if (x.Currency != Currency)
                throw new SPCurrenciesNotMatchException();

            var value = Value - x.Value;
            if (value < 0)
                throw new InvalidSPMoneyValueException();
            
            Value = value;
        }

        public static bool operator ==(int x, SPMoney y) => x == y.Value;
        public static bool operator !=(int x, SPMoney y) => x != y.Value;
        public static bool operator ==(SPMoney x, int y) => x.Value == y;
        public static bool operator !=(SPMoney x, int y) => x.Value != y;
    }
}
