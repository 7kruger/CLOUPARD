using CLOUPARD.Domain.Enum;
using CLOUPARD.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CLOUPARD.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IIndexPageService _indexPageService;

    public HomeController(ILogger<HomeController> logger, IIndexPageService indexPageService)
    {
        _logger = logger;
        _indexPageService = indexPageService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? pageId, string? search, SortState? sortState)
    {
        var indexPageViewModel = await _indexPageService.GetIndexPageViewModel(pageId, search, sortState);

        return View(indexPageViewModel);
    }
}
