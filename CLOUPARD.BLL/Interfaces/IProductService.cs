using CLOUPARD.BLL.Models;
using CLOUPARD.Domain.Enum;

namespace CLOUPARD.BLL.Interfaces;

public interface IProductService
{
    public Task<IEnumerable<ProductModel>?> GetAllAsync(string? search, SortState? sortBy);
    public Task<ProductModel?> GetByIdAsync(Guid id);
    public Task<ProductModel?> CreateAsync(ProductModel model);
    public Task<bool> UpdateAsync(ProductModel model);
    public Task<bool> DeleteAsync(Guid id);
}
