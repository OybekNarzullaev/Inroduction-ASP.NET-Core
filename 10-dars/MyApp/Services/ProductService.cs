using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Services;

public interface IProductService
{
    Task<List<Product>> GetAll();
    Task<Product?> GetById(int id);
    void Create(Product product);
    void Edit(Product product);
    void Delete(Product product);

}

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;
    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Product>> GetAll()
    {
        List<Product> products = await _dbContext.Products.ToListAsync();
        return products;
    }

    public async Task<Product?> GetById(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
    }


    public async void Create(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    public async void Edit(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async void Delete(Product product)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}