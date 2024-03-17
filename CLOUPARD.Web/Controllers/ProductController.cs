using AutoMapper;
using CLOUPARD.BLL.Interfaces;
using CLOUPARD.BLL.Models;
using CLOUPARD.DAL.Entities;
using CLOUPARD.Web.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace CLOUPARD.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound("Продукт не найден");
        }

        return Ok(_mapper.Map<ProductViewModel>(product));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdProduct = await _productService.CreateAsync(_mapper.Map<ProductModel>(model));

        if (createdProduct == null)
        {
            return BadRequest("Не удалось создать продукт");
        }

        return Ok(_mapper.Map<ProductViewModel>(createdProduct));
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updated = await _productService.UpdateAsync(_mapper.Map<ProductModel>(model));

        if (!updated)
        {
            return BadRequest("Не удалось обновить продукт");
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _productService.DeleteAsync(id);

        if (!deleted)
        {
            return BadRequest("Не удалить продукт");
        }

        return Ok();
    }
}
