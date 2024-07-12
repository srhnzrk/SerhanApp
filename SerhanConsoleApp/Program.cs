using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using SerhanApp.Data;
using SerhanApp.Data.Entities.Catalog;
using SerhanApp.Data.Repositories;
using SerhanApp.Core.Caching;
using System.Net;


namespace SerhanConsoleApp
{
    class Program
    {
        #region serhan crud methodları
        //SerhanContext context = new SerhanContext();

        // Method to add product
        //public static void AddProduct(Product product)
        //{
        //    SerhanContext context = new SerhanContext();
        //    context.Product.Add(product);
        //    context.SaveChanges();
        //}

        //// Method to remove product by its id
        //public void RemoveProduct(int id)
        //{
        //    var product = context.Product.Find(id);
        //    context.Product.Remove(product);
        //    context.SaveChanges();
        //}

        //// method to update products price by the user input
        //public void UpdateProduct(Product product)
        //{
        //    var productToUpdate = context.Product.FirstOrDefault(p => p.Id == product.Id);

        //    if (productToUpdate != null)
        //    {
        //        productToUpdate.Price = product.Price;
        //        context.SaveChanges();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Product not found");
        //    }

        //}

        //// method to search items by the name it contains
        //public void SearchProduct(string name)
        //{
        //    var products = context.Product.Where(p => p.Name.Contains(name));
        //    foreach (var product in products)
        //    {
        //        Console.WriteLine(product.Name);
        //    }
        //}

        //// method to get list products
        //public void GetProducts()
        //{
        //    var products = context.Product.ToList();
        //    foreach (var product in products)
        //    {
        //        Console.WriteLine("ID: " + product.Id + ", " + product.Name + ", Price: " + product.Price);
        //    }
        //}

        //public void ChooseOption()
        //{
        //    Console.WriteLine("1- Add Product");
        //    Console.WriteLine("2- Remove Product");
        //    Console.WriteLine("3- Update Product");
        //    Console.WriteLine("4- Search Product");
        //    Console.WriteLine("5- List All Products");
        //    Console.WriteLine("Choose an option: ");

        //    Program program = new Program();


        //    int option = int.Parse(Console.ReadLine());
        //    if (option == 1)
        //    {
        //        Console.WriteLine("Enter product name: ");
        //        string name = Console.ReadLine();
        //        Console.WriteLine("Enter product description: ");
        //        string description = Console.ReadLine();
        //        Console.WriteLine("Enter product price: ");
        //        decimal price = decimal.Parse(Console.ReadLine());
        //        Product product = new Product
        //        {
        //            Name = name,
        //            Description = description,
        //            Price = price
        //        };
        //        program.AddProduct(product);
        //        ChooseOption();
        //    }
        //    else if (option == 2)
        //    {
        //        Console.WriteLine("Do you want to list all products?\n" + "1- Yes\n" + "2- No\n");
        //        int ListOption = int.Parse(Console.ReadLine());                
        //        if (ListOption == 1)
        //        {
        //            program.GetProducts();
        //        }

        //        Console.WriteLine("Enter product id: ");
        //        int id = int.Parse(Console.ReadLine());
        //        program.RemoveProduct(id);
        //        ChooseOption();

        //    }
        //    else if (option == 3)
        //    {
        //        Console.WriteLine("Do you want to list all products?\n" + "1- Yes\n" + "2- No\n");
        //        int ListOption = int.Parse(Console.ReadLine());
        //        if (ListOption == 1)
        //        {
        //            program.GetProducts();
        //        }

        //        Console.WriteLine("Enter product id to update");
        //        int idUpdate = int.Parse(Console.ReadLine());
        //        Console.WriteLine("Enter new price: ");
        //        decimal priceUpdate = decimal.Parse(Console.ReadLine());
        //        Product productUpdate = new Product
        //        {
        //            Id = idUpdate,
        //            Price = priceUpdate
        //        };
        //        program.UpdateProduct(productUpdate);
        //        ChooseOption();

        //    }
        //    else if (option == 4)
        //    {
        //        Console.WriteLine("Enter product name to search: ");
        //        string nameSearch = Console.ReadLine();
        //        program.SearchProduct(nameSearch);
        //        ChooseOption();

        //    }
        //    else if (option == 5)
        //    {
        //        program.GetProducts();
        //        ChooseOption();

        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid option");
        //        ChooseOption();
        //    }
        //}


        #endregion

        static void Main(string[] args)
        {
            SerhanContext context = new SerhanContext();
            ProductRepository productRepository = new ProductRepository();

            #region Serhan Kod
            //int productId = 2;
            //var productCategory = context.ProductCategory.FirstOrDefault(x => x.ProductId == productId);

            //var category = context.Category.FirstOrDefault(x => x.Id == productCategory.CategoryId);

            //Console.WriteLine(category.Name);


            //// "kahve" kategorisine ait Id bilgisini al
            //var category = context.Category.FirstOrDefault(x => x.Name == "kahve");

            //// kahve kategorisinin Id'sini ata
            //int categoryId = category.Id;

            //// ProductCategory'e gidip bu Id ile eşleşen category id'leri al 
            //var productCategories = context.ProductCategory.Where(pc => pc.CategoryId == categoryId).ToList();

            //// Bu category id'lerin içinden eşleşen product id'leri al
            //var productIds = productCategories.Select(x => x.ProductId).ToList();

            //// bu product id'lerle eşleşen productları al
            //var products = context.Product.Where(x => productIds.Contains(x.Id)).ToList();


            //var category = (from x in context.Category
            //                where x.Name == "kahve"
            //                select x).FirstOrDefault();

            //int categoryId = category.Id;

            //var productCategories = (from x in context.ProductCategory
            //                         where x.CategoryId == categoryId
            //                         select x).ToList();

            //var productIds = (from x in productCategories
            //                  select x.ProductId).ToList();

            //var products = (from x in context.Product
            //                where productIds.Contains(x.Id) ).ToList();

            #endregion

            //var query = from product in context.Product
            //            join productCategory in context.ProductCategory on product.Id equals productCategory.ProductId
            //            join category in context.Category on productCategory.CategoryId equals category.Id
            //            where category.Name == "Kahve"
            //            select product;

            //var result = query.ToList();

            //foreach (var product in result)
            //{
            //    Console.WriteLine("Product ID: " + product.Id + "Product Name: " + product.Name + "Price: " + product.Price);
            //}


            Product product = new Product()
            {
                Name = "Samsung Galaxy S10 Plus",
                Price = 14000,
                Description = "Samsung's flagship of the year",
                VendorId = 1,
            };

            GenericRepository<Product> genericRepository = new GenericRepository<Product>();
            genericRepository.InsertEntity(product);
        }
    }
}