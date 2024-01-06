using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.SeatsModule.Queries.SeatsGetByIdQuery
{
    internal class SeatsGetByIdRequestHandler : IRequestHandler<SeatsGetByIdRequest, Seats>
    {
        private readonly ISeatRepository seatRepository;

        public SeatsGetByIdRequestHandler(ISeatRepository seatRepository)
        {
            this.seatRepository = seatRepository;
        }
        public async Task<Seats> Handle(SeatsGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = seatRepository.Get(m => m.Id == request.Id);
            return data;
        }
    }
}
