using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.BanTypeModule.Commands.BanTypeAddCommand
{
    internal class BanTypeAddRequestHandler : IRequestHandler<BanTypeAddRequest, BanType>
    {
        private readonly IBanTypeRepository banTypeRepository;

        public BanTypeAddRequestHandler(IBanTypeRepository banTypeRepository)
        {
            this.banTypeRepository = banTypeRepository;
        }
        public async Task<BanType> Handle(BanTypeAddRequest request, CancellationToken cancellationToken)
        {
            var bantype = new BanType
            {
                Name = request.Name,
            };

            banTypeRepository.Add(bantype);
            banTypeRepository.Save();
            return bantype;
        }
    }
}
