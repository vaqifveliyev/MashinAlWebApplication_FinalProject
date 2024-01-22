using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Entities.Membership;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MashinAl.Business.Modules.DealerModule.Queries.DealetGetAllQuery
{
    internal class DealerGetAllRequestHandler : IRequestHandler<DealerGetAllRequest, IEnumerable<DealerGetAllDto>>
    {
        private readonly UserManager<MashinAlUser> userManager;
        private readonly ICarRepository carRepository;

        public DealerGetAllRequestHandler(UserManager<MashinAlUser> userManager, ICarRepository carRepository)
        {
            this.userManager = userManager;
            this.carRepository = carRepository;
        }
        public async Task<IEnumerable<DealerGetAllDto>> Handle(DealerGetAllRequest request, CancellationToken cancellationToken)
        {

            var query = (from user in await userManager.GetUsersInRoleAsync("Dealership")
                        let carCount = carRepository.GetAll().Count(car => car.CreatedBy == user.Id)
                        select new DealerGetAllDto
                        {
                            Id = user.Id,
                            Name = user.DealershipName,
                            Phone = user.DealershipNumber,
                            ImagePath = user.ImagePath,
                            Count = carCount
                        }).ToList();


            return query;

        }
    }
}
