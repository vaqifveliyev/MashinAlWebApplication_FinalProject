using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.SeatsModule.Commands.SeatsAddCommand
{
    internal class SeatsAddRequestHandler : IRequestHandler<SeatsAddRequest, Seats>
    {
        private readonly ISeatRepository seatRepository;

        public SeatsAddRequestHandler(ISeatRepository seatRepository)
        {
            this.seatRepository = seatRepository;
        }
        public async Task<Seats> Handle(SeatsAddRequest request, CancellationToken cancellationToken)
        {
            var seat = new Seats
            {
                SeatTitle = request.SeatTitle
            };

            seatRepository.Add(seat);
            seatRepository.Save();

            return seat;
        }
    }
}
