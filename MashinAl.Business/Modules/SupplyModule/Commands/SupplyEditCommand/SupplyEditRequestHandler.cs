using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.SupplyModule.Commands.SupplyEditCommand
{
    internal class SupplyEditRequestHandler : IRequestHandler<SupplyEditRequest, Supply>
    {
        private readonly ISupplyRepository supplyRepository;

        public SupplyEditRequestHandler(ISupplyRepository supplyRepository)
        {
            this.supplyRepository = supplyRepository;
        }
        public async Task<Supply> Handle(SupplyEditRequest request, CancellationToken cancellationToken)
        {
            var supply = new Supply
            {
                Id = request.Id,
                Title = request.Title,
            };

            supplyRepository.Edit(supply);
            supplyRepository.Save();

            return supply;
        }
    }
}
