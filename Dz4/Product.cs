
public class Product
{
    public decimal Price { get; set; }
    public string OriginCountry { get; set; }
    public string Name { get; set; }
    public DateTime PackagingDate { get; set; }
    public string Description { get; set; }

    public Product(decimal price, string originCountry, string name, DateTime packagingDate, string description)
    {
        Price = price;
        OriginCountry = originCountry;
        Name = name;
        PackagingDate = packagingDate;
        Description = description;
    }
}