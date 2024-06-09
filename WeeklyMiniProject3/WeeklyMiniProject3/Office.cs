namespace WeeklyMiniProject3
{
    public class Office // Class that creates office-type objects
    {
        public string Name { get; set; } = "";
        public string Currency { get; set; } = "";
        public List<Product> Products { get; set; } = new List<Product>(); // List of products at each office

        public Office(string name, string currency, List<Product> products)
        {
            Name = name;
            Currency = currency;
            Products = products;

            SortProducts(); 
        }

        public void SortProducts()
        {
            Products.Sort((p, q) => p.PurchaseDate.CompareTo(q.PurchaseDate)); // Sort all products by date of purchase chronologically
        }
    }
}