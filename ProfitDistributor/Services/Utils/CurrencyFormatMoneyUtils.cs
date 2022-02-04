using System.Globalization;

namespace ProfitDistributor.Domain.Utils
{
    public static class CurrencyFormatMoneyUtils
    {
        // treating special currency formats
        private const string CURRENCY_SPECIFIER = "C";

        private const string PT_BR = "pt-BR";

        public static string SetMoneyTextFromDecimal(decimal value) => value.ToString(CURRENCY_SPECIFIER, CultureInfo.CreateSpecificCulture(PT_BR));

        public static decimal SetDecimalFromString(string money) => decimal.Parse(money, NumberStyles.Currency, CultureInfo.CreateSpecificCulture(PT_BR));
    }
}