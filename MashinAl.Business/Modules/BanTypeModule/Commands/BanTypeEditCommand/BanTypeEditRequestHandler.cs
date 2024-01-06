using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.BanTypeModule.Commands.BanTypeEditCommand
{
    internal class BanTypeEditRequestHandler : IRequestHandler<BanTypeEditRequest, BanType>
    {
        private readonly IBanTypeRepository banTypeRepository;

        public BanTypeEditRequestHandler(IBanTypeRepository banTypeRepository)
        {
            this.banTypeRepository = banTypeRepository;
        }
        public async Task<BanType> Handle(BanTypeEditRequest request, CancellationToken cancellationToken)
        {
            var bantype = new BanType
            {
                Id = request.Id,
                Name = request.Name,
            };

            banTypeRepository.Edit(bantype);
            banTypeRepository.Save();

            return bantype;
        }
    }
}
