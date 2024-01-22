using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.FavoriteAddCommand
{
    public class FavoriteAddRequest : IRequest<Favorites>
    {
        public int CarId { get; set; }
        public decimal Quantity { get; set; }
    }
}
