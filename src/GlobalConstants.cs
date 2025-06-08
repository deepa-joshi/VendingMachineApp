public static class GlobalConstants {
    public enum CoinType
    {
        Nickel,
        Dime,
        Quarter,
        Penny,
        InvalidCoin
    }

    // Coin values mapping
    public static readonly Dictionary<CoinType, decimal> CoinValues = new()
    {
        { CoinType.Nickel, 0.05m },
        { CoinType.Dime, 0.10m },
        { CoinType.Quarter, 0.25m },
        { CoinType.Penny, 0.01m },
        { CoinType.InvalidCoin, 0.00m }
    };

    public enum Products {
        Cola,
        Chips,
        Candy
    }

    public static readonly Dictionary<Products, decimal> ProductPrices = new()
        {
            { Products.Cola, 1.00m },
            { Products.Chips, 0.50m },
            { Products.Candy, 0.65m }
        };
    }