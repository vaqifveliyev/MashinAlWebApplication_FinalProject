using MediatR;

namespace MashinAl.Business.Modules.CarModule.Queries.FavoritesListQuery
{
    public class FavoritesListRequest : IRequest<IEnumerable<FavoritesListItem>>
    {
    }
}
