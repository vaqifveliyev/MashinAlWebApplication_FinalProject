using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.FavoriteRemoveCommand
{
    public class FavoriteRemoveRequest : IRequest<Favorites>
    {
        public int CarId { get; set; }
    }
}
