using MyApp.Models;

namespace MyApp.Repositories;

public class ProductRepository
{
    private List<Product> _database = new List<Product>
    {
        new Product { Id = 1, Name="iPhone 16", Price=2000, ReleaseDate=DateTime.Parse("2024-09-01") },
        new Product { Id = 2, Name="Samsung Galaxy S24", Price=2000, ReleaseDate=DateTime.Parse("2024-02-01") },
    };

    public List<Product> GetAll()
    {
        return _database;
    }

    public Product? GetById(int id)
    {
        var product = _database.FirstOrDefault(x => x.Id == id);
        if (product == null)
        {
            return null;
        }
        return product;
    }


    public Product Create(Product newProduct)
    {
        _database.Add(newProduct);
        return newProduct;
    }

    public Product? Update(Product updatedProduct)
    {
        var product = _database.FirstOrDefault(x => x.Id == updatedProduct.Id);
        if (product == null)
        {
            return null;
        }
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.ReleaseDate = updatedProduct.ReleaseDate;

        return product;
    }

    public Product? Delete(int id)
    {
        var product = _database.FirstOrDefault(x => x.Id == id);
        if (product == null)
        {
            return null;
        }
        _database.Remove(product);

        return product;
    }
}