using AutoMapper;
using CLOUPARD.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLOUPARD.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : Controller
{
    protected IActionResult SendSuccess(int statusCode = 200, string message = "", object? data = default)
    {
        return StatusCode(statusCode, new ApiResponse(success: true, message: message, data: data));
    }

    protected IActionResult SendError(int statusCode, string message = "", object? data = default)
    {
        return StatusCode(statusCode, new ApiResponse(success: false, message: message, data: data));
    }
}
