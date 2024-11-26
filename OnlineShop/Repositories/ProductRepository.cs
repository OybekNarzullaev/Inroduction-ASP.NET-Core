using OnlineShop.Models;

namespace OnlineShop.Repositories;

public class ProductRepository
{
    private List<Product> _database = new List<Product>
    {
        new Product {
            Id = 1,
            Name = "Laptop",
            Description = "Gaming Laptop",
            Price = 1200,
            Image = "https://www.hp.com/ca-en/shop/Html/Merch/Images/c08505208_500x367.jpg"
        },
        new Product {
            Id = 2,
            Name = "Phone",
            Description = "Smartphone",
            Price = 800,
            Image="https://joybox.uz/wp-content/uploads/2024/09/smartfon-apple-iphone-16-pro-256gb-global-desert-titanium.jpg"
            },
        new Product {
            Id = 3,
            Name = "Headphones",
            Description = "Noise Cancelling",
            Price = 200,
            Image = "https://www.borofone.com/wp-content/uploads/2022/04/borofone-bo12-power-bt-headset-headphones.jpg"
        }
    };

    public List<Product> GetAll()
    {
        return _database;
    }

    public Product? Get(int id)
    {
        Product? product = _database.FirstOrDefault(p => p.Id == id);
        if (product is null) return null;
        return product;
    }

    public void Create(Product newProduct)
    {
        int Id = _database.Max(p => p.Id) + 1;
        newProduct.Id = Id;
        _database.Add(newProduct);
    }

    public void Edit(int id, Product updatedProduct)
    {
        Product? product = _database.FirstOrDefault(p => p.Id == id);
        if (product is not null)
        {
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Image = updatedProduct.Image;
        }

    }

    public void Delete(int id)
    {
        Product? product = _database.FirstOrDefault(p => p.Id == id);
        if (product is not null)
        {
            _database.Remove(product);
        }

    }
}