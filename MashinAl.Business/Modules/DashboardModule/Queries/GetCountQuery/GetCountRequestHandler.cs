using MashinAl.Infastructure.Entities.Membership;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MashinAl.Business.Modules.DashboardModule.Queries.GetCountQuery
{
    internal class GetCountRequestHandler : IRequestHandler<GetCountRequest, GetCountDto>
    {
        private readonly ICarRepository carRepository;
        private readonly IPlateRepository plateRepository;
        private readonly UserManager<MashinAlUser> userManager;

        public GetCountRequestHandler(ICarRepository carRepository, IPlateRepository plateRepository, UserManager<MashinAlUser> userManager)
        {
            this.carRepository = carRepository;
            this.plateRepository = plateRepository;
            this.userManager = userManager;
        }
        public async Task<GetCountDto> Handle(GetCountRequest request, CancellationToken cancellationToken)
        {
            int carCount =  carRepository.GetAll().Where(m => m.IsAccepted == true).Count();
            int plateCount = plateRepository.GetAll().Where(m => m.IsAccepted == true).Count();
            int userCount = userManager.Users.Where(m => m.DealershipName == null).Count();
            int dealerCount = userManager.Users.Where(m => m.DealershipName != null).Count();

            var getCount = new GetCountDto
            {
                CarCount = carCount,
                PlateCount = plateCount,
                UserCount = userCount,
                DealerCount = dealerCount
            };

            return getCount;


        }
    }
}
