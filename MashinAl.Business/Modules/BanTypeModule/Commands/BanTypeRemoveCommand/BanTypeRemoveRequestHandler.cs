using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.BanTypeModule.Commands.BanTypeRemoveCommand
{
    internal class BanTypeRemoveRequestHandler : IRequestHandler<BanTypeRemoveRequest>
    {
        private readonly IBanTypeRepository banTypeRepository;

        public BanTypeRemoveRequestHandler(IBanTypeRepository banTypeRepository)
        {
            this.banTypeRepository = banTypeRepository;
        }
        public async Task Handle(BanTypeRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = banTypeRepository.Get(m => m.Id == request.Id);
            banTypeRepository.Remove(data);
            banTypeRepository.Save();
        }
    }
}
