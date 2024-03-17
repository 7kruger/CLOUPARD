using AutoMapper;
using CLOUPARD.BLL.Interfaces;
using CLOUPARD.BLL.Models;
using CLOUPARD.DAL.Entities;
using CLOUPARD.DAL.Interfaces;
using CLOUPARD.Domain.Enum;

namespace CLOUPARD.BLL.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public ProductService(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductModel>?> GetAllAsync(string? search, SortState? sortBy)
    {
        try
        {
            var products = _mapper.Map<IEnumerable<ProductModel>>(await _repository.GetAllAsync());

            if(!string.IsNullOrWhiteSpace(search))
            {
                products = products.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            }

            if(sortBy != null)
            {
                switch (sortBy)
                {
                    case SortState.IdAsc:
                        products = products.OrderBy(x => x.Id);
                        break;
                    case SortState.IdDesc:
                        products = products.OrderByDescending(x => x.Id);
                        break;
                    case SortState.NameAsc:
                        products = products.OrderBy(x => x.Name);
                        break;
                    case SortState.NameDesc:
                        products = products.OrderByDescending(x => x.Name);
                        break;
                }
            }

            return products;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<ProductModel?> GetByIdAsync(Guid id)
    {
        try
        {
            var product = await _repository.GetByIdAsync(id);

            return _mapper.Map<ProductModel>(product);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<ProductModel?> CreateAsync(ProductModel model)
    {
        try
        {
            var product = _mapper.Map<Product>(model);

            await _repository.CreateAsync(product);

            return _mapper.Map<ProductModel>(product);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> UpdateAsync(ProductModel model)
    {
        try
        {
            var product = await _repository.GetByIdAsync(model.Id);

            if(product == null)
            {
                return false;
            }

            product.Name = model.Name;
            product.Description = model.Description;

            await _repository.UpdateAsync(product);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            await _repository.DeleteAsync(id);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
