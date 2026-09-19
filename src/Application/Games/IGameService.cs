using Application.Games.Queries;
using Application.Games.Responses;
using Application.Pagination;

namespace Application.Games;

public interface IGameService
{
    Task<PagedList<GetGamesPageResponse>> GetGamesPage(GetGamesPageQuery query, CancellationToken cancellationToken);
}
