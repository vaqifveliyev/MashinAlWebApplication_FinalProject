using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.SupplyModule.Queries.SupplyGetByIdQuery
{
    internal class SupplyGetByIdRequestHandler : IRequestHandler<SupplyGetByIdRequest, Supply>
    {
        private readonly ISupplyRepository supplyRepository;

        public SupplyGetByIdRequestHandler(ISupplyRepository supplyRepository)
        {
            this.supplyRepository = supplyRepository;
        }
        public async Task<Supply> Handle(SupplyGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = supplyRepository.Get(m => m.Id == request.Id);
            return data;
        }
    }
}
