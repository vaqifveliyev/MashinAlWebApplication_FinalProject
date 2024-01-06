using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.SupplyModule.Commands.SupplyRemoveCommand
{
    internal class SupplyRemoveRequestHandler : IRequestHandler<SupplyRemoveRequest>
    {
        private readonly ISupplyRepository supplyRepository;

        public SupplyRemoveRequestHandler(ISupplyRepository supplyRepository)
        {
            this.supplyRepository = supplyRepository;
        }
        public async Task Handle(SupplyRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = supplyRepository.Get(m => m.Id == request.Id);
            supplyRepository.Remove(data);
            supplyRepository.Save();
        }
    }
}
