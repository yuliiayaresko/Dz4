public class FoodProduct : Product
{
    public int ShelfLife { get; set; } // Термін придатності (дні)
    public int Quantity { get; set; }  // Кількість
    public string Unit { get; set; }   // Одиниця виміру

    public FoodProduct(decimal price, string originCountry, string name, DateTime packagingDate, string description,
                       int shelfLife, int quantity, string unit)
        : base(price, originCountry, name, packagingDate, description)
    {
        ShelfLife = shelfLife;
        Quantity = quantity;
        Unit = unit;
    }
}
