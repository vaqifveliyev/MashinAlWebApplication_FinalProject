using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.SeatsModule.Commands.SeatsEditCommand
{
    internal class SeatsEditRequestHandler : IRequestHandler<SeatsEditRequest, Seats>
    {
        private readonly ISeatRepository seatRepository;

        public SeatsEditRequestHandler(ISeatRepository seatRepository)
        {
            this.seatRepository = seatRepository;
        }
        public async Task<Seats> Handle(SeatsEditRequest request, CancellationToken cancellationToken)
        {
            var seat = new Seats
            {
                Id = request.Id,
                SeatTitle = request.SeatTitle
            };

            seatRepository.Edit(seat);
            seatRepository.Save();
            return seat;
        }
    }
}
