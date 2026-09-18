using Application.Games;
using Application.Games.Pagination;
using Application.Games.Queries;
using Application.Games.Responses;
using Application.Pagination;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Games;
using Web.Models.Games.Requests;

namespace Web.Controllers;

public class GamesController(IGameService gameService) : Controller
{
    [HttpGet]
    public async Task<ActionResult> Index(GetGamesRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        GameFilter filter = new(request.SearchTerm);
        GameSorting sorting = new(request.SortBy, request.SortDirection);
        Paging paging = new(request.PageNumber, request.PageSize);
        GetGamesPageQuery query = new(filter, sorting, paging);

        PagedList<GetGamesPageResponse> page = await gameService.GetGamesPage(query, cancellationToken);
        return View(GamesIndex.Create(page, request));
    }
}
