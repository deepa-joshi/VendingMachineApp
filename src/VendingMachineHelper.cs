namespace VendingMachineApp.src
{
public class VendingMachineHelper
    {
       public decimal currentAmount = 0.00m;
        static List<GlobalConstants.CoinType> coinReturn = new List<GlobalConstants.CoinType>();

        /// <summary>
        /// Insert the coin/ Reject Invalid coin
        /// </summary>
        /// <param name="coin"></param>
        public void InsertCoin(string coin)
        {
            GlobalConstants.CoinType coinType = IdentifyCoin(coin);

            if (coinType == GlobalConstants.CoinType.Penny || coinType == GlobalConstants.CoinType.InvalidCoin)
            {
                Console.WriteLine($"{coin} is not accepted. Sent to coin return.");
                coinReturn.Add(coinType);
            }
            else
            {
                currentAmount += GlobalConstants.CoinValues[coinType];
                Console.WriteLine($"Accepted {coin}. Current amount: ${currentAmount:F2}");
            }
        }
        /// <summary>
        /// Identify Coin
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GlobalConstants.CoinType IdentifyCoin(string input)
        {
            return input switch {
                "nickel" => GlobalConstants.CoinType.Nickel,
                "dime" => GlobalConstants.CoinType.Dime,
                "quarter" => GlobalConstants.CoinType.Quarter,
                "penny" => GlobalConstants.CoinType.Penny,
                _ => GlobalConstants.CoinType.InvalidCoin
            };
        }

        /// <summary>
        /// Select the product/Reject Invalidproduct
        /// </summary>
        /// <param name="productInput"></param>
        public void SelectProduct(string productInput)
        {

            bool isValid = Enum.TryParse<GlobalConstants.Products>(productInput, true, out GlobalConstants.Products product);
            if (!isValid)
            {
                Console.WriteLine("Invalid product.");
                return;
            }

            decimal price = GlobalConstants.ProductPrices[product];

            if (currentAmount >= price)
            {
                Console.WriteLine($"Dispensing {product}. THANK YOU!");
                currentAmount -= price;
            }
            else
            {
                Console.WriteLine($"PRICE ${price:F2}");
            }
        }

        /// <summary>
        /// Return and Exit
        /// </summary>
        /// <param name="Inputval"></param>
        public void ReturnCoinsAndExit(string Inputval)
        {
            if (Inputval == "return")
            {
                Console.WriteLine($"Returning ${currentAmount:F2} to coin return.");
                currentAmount = 0.00m;
            }
            else if (Inputval != "exit")
            {
                Console.WriteLine("Invalid command.");
            }
        }

        /// <summary>
        /// Display Message
        /// </summary>
        public void DisplayMessage()
        {
            if (currentAmount == 0.00m)
                Console.WriteLine("INSERT COIN");
            Console.WriteLine($"Current amount: ${currentAmount:F2}");
        }
}
}