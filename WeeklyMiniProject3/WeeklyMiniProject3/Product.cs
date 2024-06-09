namespace WeeklyMiniProject3
{
    public abstract class Product // Class from which children product type objects inherit
    {
        public virtual string Type { get; protected set; } = "Product";
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public DateTime PurchaseDate { get; set; }
        public double PriceUSD { get; set; }

        public Product(string brand, string model, DateTime purchaseDate, double priceUSD)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            PriceUSD = priceUSD;
        }
    }
    public class Computer : Product
    {
        public override string Type { get; protected set; } = "Computer";
        public Computer(string brand, string model, DateTime purchaseDate, double priceUSD) : base(brand, model, purchaseDate, priceUSD) { }
    
    }

    public class MobilePhone : Product
    {
        public override string Type { get; protected set; } = "Mobile phone";
        public MobilePhone(string brand, string model, DateTime purchaseDate, double priceUSD) : base(brand, model, purchaseDate, priceUSD) { }
    }
    
}