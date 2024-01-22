using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Entities.Membership;
using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MashinAl.Business.Modules.CarModule.Commands.CarBoostCommand
{
    internal class CarBoostRequestHandler : IRequestHandler<CarBoostRequest, Car>
    {
        private readonly IIdentityService identityService;
        private readonly UserManager<MashinAlUser> userManager;
        private readonly ICarRepository carRepository;

        public CarBoostRequestHandler(IIdentityService identityService, UserManager<MashinAlUser> userManager, ICarRepository carRepository)
        {
            this.identityService = identityService;
            this.userManager = userManager;
            this.carRepository = carRepository;
        }
        public async Task<Car> Handle(CarBoostRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(identityService.GetPrincipalId().ToString());
            var entity = carRepository.Get(m => m.Id == request.Id);


            if ( user.Balance <= 0)
            {
                throw new Exception("Balans kifayet qeder deyil");
            }
            else
            {
                entity.IsBoosted = true;
                user.Balance = user.Balance - 2;

                carRepository.Save();

                return entity;

            }

            
        }
    }
}
