using OrderApp.Helpers;
using OrderApp.Helpers.Structs;

namespace OrderAppTests.Helpers
{
    public class DiscountHelperTests
    {
        [Fact]
        public void CalculateDiscount_5Percent_DiscountAppliedOnQuantitiesLessThan20() 
        {
            //Arrange
            var price = 2;
            var quantity = 14;

            //Act
            var result = DiscountHelper.CalculateDiscount(price, quantity);

            //Assert
            Assert.Equal((price * quantity) - (price * quantity * DiscountBracket.Five), result);
        }

        [Fact]
        public void CalculateDiscount_10Percent_DiscountApplied_OnQuantitiesBetween20And30()
        {
            //Arrange
            var price = 2;
            var quantity = 25;

            //Act
            var result = DiscountHelper.CalculateDiscount(price, quantity);

            //Assert
            Assert.Equal((price * quantity) - (price * quantity * DiscountBracket.Ten), result);
        }

        [Fact]
        public void CalculateDiscount_15And20Percent_DiscountApplied_OnQuantitiesAbove30()
        {
            //Arrange
            var price = 2;
            var quantity = 31;

            //Act
            var result = DiscountHelper.CalculateDiscount(price, quantity);

            //Assert
            Assert.Equal((price * quantity) - ((price * 30 * DiscountBracket.Fifteen) + (price * (quantity - 30) * DiscountBracket.Twenty)), result);
        }
    }
}
