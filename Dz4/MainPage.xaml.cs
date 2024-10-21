using static Dz4.MainPage;
using System.Collections.ObjectModel;
using System;

namespace Dz4
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Product> _products;
        private int _clickCount = 0;
        private Random _random = new Random();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Ініціалізація списку товарів
            _products = new ObservableCollection<Product>();

            // Додавання перших рядків в таблицю
            PopulateGrid();
        }

        private void OnAddProductClicked(object sender, EventArgs e)
        {
            _clickCount++;

            Product product;
            if (_clickCount % 2 == 1)
            {
                product = GenerateRandomProduct();
            }
            else
            {
                product = GenerateRandomBook();
            }

            _products.Add(product);
            AddProductToGrid(product);
        }

        private void OnRemoveProductClicked(object sender, EventArgs e)
        {
            if (_products.Any())
            {
                _products.RemoveAt(_products.Count - 1);
                ProductGrid.Children.RemoveAt(ProductGrid.Children.Count - 10); // Видаляємо останній рядок
            }
        }

        private void PopulateGrid()
        {
            // Встановлюємо для ProductGrid одну заголовкову рядок
            ProductGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            foreach (var product in _products)
            {
                AddProductToGrid(product);
            }
        }


        private void AddProductToGrid(Product product)
        {
            // Використовуємо rowIndex, щоб вказати номер рядка для нових товарів
            int row = ProductGrid.RowDefinitions.Count;

            // Додаємо новий рядок для товару
            ProductGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            // Додаємо елементи до сітки, починаючи з другого рядка
            ProductGrid.Add(new Label { Text = product.Name }, 0, row);
            ProductGrid.Add(new Label { Text = product.Price.ToString("C") }, 1, row);
            ProductGrid.Add(new Label { Text = product.OriginCountry }, 2, row);
            ProductGrid.Add(new Label { Text = product.Description }, 3, row);

            if (product is FoodProduct food)
            {
                ProductGrid.Add(new Label { Text = food.ShelfLife.ToString() }, 4, row);
                ProductGrid.Add(new Label { Text = food.Quantity.ToString() }, 5, row);
                ProductGrid.Add(new Label { Text = food.Unit }, 6, row);
                ProductGrid.Add(new Label { Text = "-" }, 7, row); // Прочерк для книги
                ProductGrid.Add(new Label { Text = "-" }, 8, row); // Прочерк для книги
                ProductGrid.Add(new Label { Text = "-" }, 9, row); // Прочерк для книги
            }
            else if (product is Book book)
            {
                ProductGrid.Add(new Label { Text = "-" }, 4, row); // Прочерк для продукту
                ProductGrid.Add(new Label { Text = "-" }, 5, row); // Прочерк для продукту
                ProductGrid.Add(new Label { Text = "-" }, 6, row); // Прочерк для продукту
                ProductGrid.Add(new Label { Text = book.Pages.ToString() }, 7, row);
                ProductGrid.Add(new Label { Text = book.Publisher }, 8, row);
                ProductGrid.Add(new Label { Text = book.Authors }, 9, row);
            }
        }

        
        private Product GenerateRandomProduct()
        {
            var productNames = new List<string> { "Молоко", "Хліб", "Ковбаса" };
            var countries = new List<string> { "Україна", "Польща" };
            decimal price = (decimal)(_random.Next(10, 201) + Math.Round(_random.NextDouble(), 2));
            int shelfLife = _random.Next(1, 366);
            int quantity = _random.Next(1, 51);
            var units = new List<string> { "л", "кг" };
            string unit = units[_random.Next(units.Count)];
            DateTime packagingDate = DateTime.Now.AddDays(-_random.Next(0, 101));

            return new FoodProduct(price, countries[_random.Next(countries.Count)], productNames[_random.Next(productNames.Count)], packagingDate, "-", shelfLife, quantity, unit);
        }

        private Product GenerateRandomBook()
        {
            var bookTitles = new List<string> { "Програмування", "Основи Python" };
            var publishers = new List<string> { "Видавництво", "КСД" };
            var authors = new List<string> { "Автор1", "Автор2" };
            int pageCount = _random.Next(100, 1001);
            decimal price = (decimal)(_random.Next(100, 501) + Math.Round(_random.NextDouble(), 2));

            return new Book(price, "Україна", bookTitles[_random.Next(bookTitles.Count)], DateTime.Now, "Опис", pageCount, publishers[_random.Next(publishers.Count)], string.Join(", ", authors));
        }
    }
}