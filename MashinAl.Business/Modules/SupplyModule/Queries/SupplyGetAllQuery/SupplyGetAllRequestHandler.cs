using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.SupplyModule.Queries.SupplyGetAllQuery
{
    internal class SupplyGetAllRequestHandler : IRequestHandler<SupplyGetAllRequest, IEnumerable<Supply>>
    {
        private readonly ISupplyRepository supplyRepository;

        public SupplyGetAllRequestHandler(ISupplyRepository supplyRepository)
        {
            this.supplyRepository = supplyRepository;
        }
        public async Task<IEnumerable<Supply>> Handle(SupplyGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = supplyRepository.GetAll();
            return await data.ToListAsync(cancellationToken);
        }
    }
}
