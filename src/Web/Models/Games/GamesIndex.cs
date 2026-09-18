using Application.Games.Responses;
using Application.Pagination;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Constants;
using Web.Models.Games.Items;
using Web.Models.Games.Requests;
using Web.Models.Shared;

namespace Web.Models.Games;

public class GamesIndex
{
    public IReadOnlyList<GamesIndexItem> Games { get; set; } = [];
    public PagingMetadata PagingMetadata { get; set; } = null!;
    public SelectList PageSizes { get; set; } = null!;

    public static GamesIndex Create(PagedList<GetGamesPageResponse> page, GetGamesRequest request)
    {
        return new GamesIndex()
        {
            Games = page.Items.Select(g => new GamesIndexItem(g)).ToList(),
            PagingMetadata = new(
                page.PageNumber,
                page.PageSize,
                page.TotalCount,
                page.TotalPages,
                page.HasPreviousPage,
                page.HasNextPage
            ),
            PageSizes = new SelectList(PagingDefaults.PageSizeOptions, selectedValue: request.PageSize),
        };
    }
}
