using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.SeatsModule.Commands.SeatsAddCommand
{
    public class SeatsAddRequest : IRequest<Seats>
    {
        public int SeatTitle { get; set; }
    }
}
