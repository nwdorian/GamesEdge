using Application.Database;
using Application.Games.Queries;
using Application.Games.Responses;
using Application.Pagination;
using Domain.Games;

namespace Application.Games;

public class GameService(IApplicationDbContext dbContext) : IGameService
{
    public async Task<PagedList<GetGamesPageResponse>> GetGamesPage(
        GetGamesPageQuery query,
        CancellationToken cancellationToken
    )
    {
        IQueryable<Game> games = dbContext.Games;

        games = games.ConditionalWhere(
            !string.IsNullOrWhiteSpace(query.Filter.SearchTerm),
            g => g.Name.Contains(query.Filter.SearchTerm!)
        );

        games = games.ApplySorting(query.Sorting.GetSortColumn(), query.Sorting.SortDirection);

        IQueryable<GetGamesPageResponse> gameResponses = games.Select(g => new GetGamesPageResponse(
            g.Id,
            g.Name,
            g.Genre,
            g.Price,
            g.ReleaseDate
        ));

        return await PagedList<GetGamesPageResponse>.Create(gameResponses, query.Paging, cancellationToken);
    }
}
