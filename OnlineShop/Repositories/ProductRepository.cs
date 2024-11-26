using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Repositories;

public class ProductRepository
{
    private List<Product> _database = new List<Product>()
    {
        new Product() {
            Id=1,
            Name="HP laptop",
            Description="new HP laptop in 2024; CPU Core i9; Ram:512 SSD...",
            Price=1500,
            Image = "https://www.hp.com/ca-en/shop/Html/Merch/Images/c08408264_390x286.jpg"
        },
        new Product() {
            Id=2,
            Name="iPhone 16 pro Max",
            Description="ultimate iPhone model in 2024",
            Price=1700,
            Image="https://www.nfm.com/dw/image/v2/BDFM_PRD/on/demandware.static/-/Sites-nfm-master-catalog/default/dw025ae98c/images/067/15/67153825-1.jpg?sw=1000&sh=1000&sm=fit"
        },
        new Product() {
            Id=3,
            Name="Ferrari toy",
            Description="Toy model",
            Price=100,
            Image="https://i.ebayimg.com/images/g/5gEAAOSwRWRbThMO/s-l1200.jpg"
        }
    };

    public List<Product> GetAll()
    {
        return _database;
    }

    public Product? Get(int id)
    {
        var product = _database.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return null;
        }
        return product;
    }

    public void Create(Product product)
    {
        int Id = _database.Max(p => p.Id) + 1;
        product.Id = Id;
        _database.Add(product);
    }

    public void Edit(int id, Product updatedProduct)
    {
        var product = _database.FirstOrDefault(p => p.Id == id);
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
        var product = _database.FirstOrDefault(p => p.Id == id);
        if (product is not null)
        {
            _database.Remove(product);
        }
    }

}