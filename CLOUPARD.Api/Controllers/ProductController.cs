using AutoMapper;
using CLOUPARD.BLL.Interfaces;
using CLOUPARD.BLL.Models;
using CLOUPARD.Domain.DTO;
using CLOUPARD.Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace CLOUPARD.Api.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] string? search, SortState? sortBy)
    {
        var products = await _productService.GetAllAsync(search, sortBy);

        if(products == null)
        {
            return SendError(500, message: "Server Error");
        }

        if(!products.Any())
        {
            return SendSuccess(statusCode: 204, message: "Products list is empty", data: products);
        }

        return SendSuccess(message: "Operation successfully", data: products);
    }

    [HttpGet]
    [Route("GetById/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);

        if(product == null)
        {
            return SendError(404, message: "Prodcut not found");
        }

        return SendSuccess(message: "Operation successfully", data: product);
    }

    [HttpPost]
    [Route("Add")]
    public async Task<IActionResult> Add([FromBody] ProductDTO product)
    {
        var productModel = _mapper.Map<ProductModel>(product);

        var createdModel = await _productService.CreateAsync(productModel);

        if(createdModel == null)
        {
            return SendError(500, message: "Sever Error", data: false);
        }

        return SendSuccess(message: "Product created successfully", data: createdModel);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] ProductDTO product)
    {
        var productModel = _mapper.Map<ProductModel>(product);

        var updated = await _productService.UpdateAsync(productModel);

        if(!updated)
        {
            return SendError(500, message: "Server Error", data: false);
        }

        return SendSuccess(message: "Product updated successfully", data: true);
    }

    [HttpDelete]
    [Route("Delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _productService.DeleteAsync(id);

        if(!deleted)
        {
            return SendError(500, message: "Server Error", data: false);
        }

        return SendSuccess(message: "Product deleted successfully", data: true);
    }
}
