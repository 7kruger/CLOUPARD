using CLOUPARD.Domain.Enum;
using CLOUPARD.Web.Models.Index;

namespace CLOUPARD.Web.Services.Interfaces;

public interface IIndexPageService
{
    public Task<IndexPageViewModel> GetIndexPageViewModel(int? pageId, string? search, SortState? sortBy);
}
