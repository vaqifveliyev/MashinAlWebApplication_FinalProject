using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.BanTypeModule.Queries.BanTypeGetByIdQuery
{
    internal class BanTypeGetByIdRequestHandler : IRequestHandler<BanTypeGetByIdRequest, BanType>
    {
        private readonly IBanTypeRepository banTypeRepository;

        public BanTypeGetByIdRequestHandler(IBanTypeRepository banTypeRepository)
        {
            this.banTypeRepository = banTypeRepository;
        }
        public async Task<BanType> Handle(BanTypeGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = banTypeRepository.Get(m => m.Id == request.Id);
            return data;
        }
    }
}
