using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.SeatsModule.Commands.SeatsEditCommand
{
    public class SeatsEditRequest : IRequest<Seats>
    {
        public int Id { get; set; }
        public int SeatTitle { get; set; }
    }
}
