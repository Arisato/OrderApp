using OrderApp.Helpers.Structs;

namespace OrderApp.Helpers
{
    public static class DiscountHelper
    {
        public static decimal CalculateDiscount(decimal price, int quantity)
        {
            if (quantity < 20)
            {
                return Calculate(price, quantity, DiscountBracket.Five);
            }
            if (quantity < 31)
            {
                return Calculate(price, quantity, DiscountBracket.Ten);
            }
            
            return Calculate(price, 30, DiscountBracket.Fifteen) + Calculate(price, quantity - 30, DiscountBracket.Twenty);
        }

        private static decimal Calculate(decimal price, int quantity, decimal discount) 
        {
            var totalPrice = Decimal.Multiply(price, quantity);
            var DiscountAmount = Decimal.Multiply(totalPrice, discount);

            return totalPrice - DiscountAmount;
        }
    }
}
