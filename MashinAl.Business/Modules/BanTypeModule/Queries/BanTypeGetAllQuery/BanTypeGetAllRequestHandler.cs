using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.BanTypeModule.Queries.BanTypeGetAllQuery
{
    internal class BanTypeGetAllRequestHandler : IRequestHandler<BanTypeGetAllRequest, IEnumerable<BanType>>
    {
        private readonly IBanTypeRepository banTypeRepository;

        public BanTypeGetAllRequestHandler(IBanTypeRepository banTypeRepository)
        {
            this.banTypeRepository = banTypeRepository;
        }
        public async Task<IEnumerable<BanType>> Handle(BanTypeGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = banTypeRepository.GetAll();
            return await data.ToListAsync(cancellationToken);
        }
    }
}
