using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.SupplyModule.Commands.SupplyAddCommand
{
    internal class SupplyAddRequestHandler : IRequestHandler<SupplyAddRequest, Supply>
    {
        private readonly ISupplyRepository supplyRepository;

        public SupplyAddRequestHandler(ISupplyRepository supplyRepository)
        {
            this.supplyRepository = supplyRepository;
        }
        public async Task<Supply> Handle(SupplyAddRequest request, CancellationToken cancellationToken)
        {
            var supply = new Supply
            {
                Title = request.Title,
            };

            supplyRepository.Add(supply);
            supplyRepository.Save();

            return supply;
        }
    }
}
