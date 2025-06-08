using Xunit;
using VendingMachineApp;

namespace VendingMachineApp.tests
{
    public class VendingMachineHelperTest
    {
        [Fact]
        public void InsertCoin_ValidCoin_UpdatesAmount()
        {
            // Arrange
            var helper = new VendingMachineHelper();

            // Act
            helper.InsertCoin("quarter");

            // Assert
            Assert.Equal(0.25m, helper.CurrentAmount);
        }

        [Fact]
        public void InsertCoin_InvalidCoin_DoesNotUpdateAmount()
        {
            // Arrange
            var helper = new VendingMachineHelper();

            // Act
            helper.InsertCoin("invalid");

            // Assert
            Assert.Equal(0.00m, helper.CurrentAmount);
        }

        [Fact]
        public void IdentifyCoin_ValidCoin_ReturnsCorrectEnum()
        {
            var helper = new VendingMachineHelper();

            var result = helper.IdentifyCoin("dime");

            Assert.Equal(GlobalConstants.CoinType.Dime, result);
        }

        [Fact]
        public void IdentifyCoin_InvalidCoin_ReturnsInvalid()
        {
            var helper = new VendingMachineHelper();

            var result = helper.IdentifyCoin("euro");

            Assert.Equal(GlobalConstants.CoinType.InvalidCoin, result);
        }

        [Fact]
        public void SelectProduct_WithSufficientAmount_DispensesProduct()
        {
            // Arrange
            var helper = new VendingMachineHelper();
            helper.InsertCoin("quarter");
            helper.InsertCoin("quarter");
            helper.InsertCoin("quarter");
            helper.InsertCoin("quarter"); // $1.00

            // Act
            helper.SelectProduct("cola");

            // Assert
            Assert.True(helper.CurrentAmount < 1.00m);
        }

        [Fact]
        public void SelectProduct_InsufficientFunds_ShowsPrice()
        {
            // Arrange
            var helper = new VendingMachineHelper();
            helper.InsertCoin("dime");

            // Act
            helper.SelectProduct("cola");

            // Assert
            Assert.Equal(0.10m, helper.CurrentAmount); // No change
        }

        [Fact]
        public void SelectProduct_InvalidProduct_ShowsError()
        {
            // Arrange
            var helper = new VendingMachineHelper();

            // Act
            helper.SelectProduct("coffee");

            // Assert
            Assert.Equal(0.00m, helper.CurrentAmount);
        }
    }
}
