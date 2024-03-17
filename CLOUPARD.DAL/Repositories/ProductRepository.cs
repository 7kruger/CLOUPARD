using CLOUPARD.DAL.Entities;
using CLOUPARD.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CLOUPARD.DAL.Repositories;

public class ProductRepository : IRepository<Product>
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
    {
        _context.Products.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Products.FirstAsync(x => x.Id == id);
        _context.Products.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
