using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.SeatsModule.Queries.SeatsGetAllQuery
{
    internal class SeatsGetAllRequestHandler : IRequestHandler<SeatsGetAllRequest, IEnumerable<Seats>>
    {
        private readonly ISeatRepository seatRepository;

        public SeatsGetAllRequestHandler(ISeatRepository seatRepository)
        {
            this.seatRepository = seatRepository;
        }
        public async Task<IEnumerable<Seats>> Handle(SeatsGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = seatRepository.GetAll();
            return await data.ToListAsync(cancellationToken);
        }
    }
}
