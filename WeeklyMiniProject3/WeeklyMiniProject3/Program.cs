using System.Text;

namespace WeeklyMiniProject3
{
    internal partial class Program
    {
        private static List<Office> offices = new List<Office>(); // List of offices to be populated

        private static void PopulateOfficeList()
        {
            List<Product> productsSweden = new List<Product>();
            productsSweden.Add(new MobilePhone("Apple", "iPhone X", new DateTime(2020, 7, 15), 1245));
            productsSweden.Add(new Computer("HP", "Elitebook", new DateTime(2022, 10, 2), 1423));
            productsSweden.Add(new MobilePhone("Motorola", "Razr", new DateTime(2022, 3, 16), 970));
            Office officeSweden = new Office("Sweden", "SEK", productsSweden);
            offices.Add(officeSweden);

            List<Product> productsUnitedStates = new List<Product>();
            productsUnitedStates.Add(new Computer("Asus", "W234", new DateTime(2019, 4, 21), 1200));
            productsUnitedStates.Add(new Computer("Lenovo", "Yoga 730", new DateTime(2020, 5, 28), 835));
            productsUnitedStates.Add(new Computer("Lenovo", "Yoga 530", new DateTime(2021, 11, 5), 1030));
            Office officeUnitedStates = new Office("United States", "USD", productsUnitedStates);
            offices.Add(officeUnitedStates);

            List<Product> productsSpain = new List<Product>();
            productsSpain.Add(new MobilePhone("Apple", "iPhone 8", new DateTime(2020, 12, 29), 970));
            productsSpain.Add(new Computer("HP", "Elitebook", new DateTime(2021, 6, 1), 1423));
            productsSpain.Add(new MobilePhone("Apple", "iPhone 11", new DateTime(2022, 9, 25), 990));
            Office officeSpain = new Office("Spain", "EUR", productsSpain);
            offices.Add(officeSpain);

            offices.Sort((p, q) => p.Name.CompareTo(q.Name)); // Sorts the list of offices in alphabetical order of country name
        }

        private static void PrintProductList()
        {
            /* Headers to be printed at the top of the table; the numbers in curly braces indicate spacing of each column */
            List<string> headers = new List<string>() { "Type", "Brand", "Model", "Office", "Purchase date", "Price in USD", "Currency", "Local price today" };
            Console.WriteLine("{0,-13}{1,-13}{2,-13}{3,-14}{4,-14}{5,-13}{6,-9}{7,-17}", headers[0], headers[1], headers[2], headers[3], headers[4], headers[5], headers[6], headers[7]);
            Console.WriteLine("{0,-13}{1,-13}{2,-13}{3,-14}{4,-14}{5,-13}{6,-9}{7,-17}", new string('-', headers[0].Length), new string('-', headers[1].Length), 
                new string('-', headers[2].Length), new string('-', headers[3].Length), new string('-', headers[4].Length), new string('-', headers[5].Length),
                new string('-', headers[6].Length), new string('-', headers[7].Length));

            /* Loop that goes through all of the offices and all of the products within each office, and prints the attributes listed within the headers */
            foreach (Office office in offices) 
            {
                foreach (Product product in office.Products)
                {
                    if ((DateTime.Now.AddMonths(3) - product.PurchaseDate.AddYears(3)).TotalDays > 0) // Color the text red if the product is older than 3 years in 3 months
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if ((DateTime.Now.AddMonths(6) - product.PurchaseDate.AddYears(3)).TotalDays > 0) // Color the text yellow if the product is older than 3 years in 6 months
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0,-13}{1,-13}{2,-13}{3,-14}{4,-14}{5,13}{6,9}{7,17}", product.Type, product.Brand, product.Model, office.Name,
                        product.PurchaseDate.ToString("yyyy-MM-dd"), product.PriceUSD.ToString("F2") + " ", 
                        office.Currency + " ", (office.Currency == "USD") ? product.PriceUSD.ToString("F2") : 
                        LiveCurrency.Convert(product.PriceUSD,"USD",office.Currency).ToString("F2"));
                    if ((DateTime.Now.AddMonths(6) - product.PurchaseDate.AddYears(3)).TotalDays > 0 || (DateTime.Now.AddMonths(3) - product.PurchaseDate.AddYears(3)).TotalDays > 0)
                        Console.ResetColor();
                }
            }
        }

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            LiveCurrency.FetchRates(); // Fetch the exchange rates once before running the program

            PopulateOfficeList(); // Places all the products within the offices and the offices within the database
            PrintProductList(); // Outputs the list of all products within all offices

            Console.ReadKey();
        }
    }
}