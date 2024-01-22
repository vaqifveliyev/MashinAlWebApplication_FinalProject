using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.CarAddCommand
{
    internal class CarAddDealerRequestHandler : IRequestHandler<CarAddDealerRequest, Car>
    {
        private readonly ICarRepository carRepository;
        private readonly IIdentityService identityService;
        private readonly IFileService fileService;

        public CarAddDealerRequestHandler(ICarRepository carRepository, IIdentityService identityService, IFileService fileService)
        {
            this.carRepository = carRepository;
            this.identityService = identityService;
            this.fileService = fileService;
        }
        public async Task<Car> Handle(CarAddDealerRequest request, CancellationToken cancellationToken)
        {
            int userId = Convert.ToInt32(identityService.GetPrincipalId());

            var car = new Car
            {
                MarkaId = request.MarkaId,
                ModelId = request.ModelId,
                YearId = request.YearId,
                BanTypeId = request.BanTypeId,
                FuelTypeId = request.FuelTypeId,
                GearboxId = request.GearboxId,
                TransmissionId = request.TransmissionId,
                March = request.March,
                ColorId = request.ColorId,
                SeatsId = request.SeatsId,
                StatusId = request.StatusId,
                Price = request.Price,
                Engine = request.Engine,
                IsBarter = request.IsBarter,
                IsCredit = request.IsCredit,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Description = request.Description,
                SellCityId = request.SellCityId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userId,
                IsBoosted = false,
                IsDealership = true,
            };

            car = carRepository.Add(car);
            carRepository.Save();

            if (request.Images != null && request.Images.Length > 0)
            {
                foreach (var image in request.Images)
                {
                    var carImage = new CarImage
                    {
                        IsMain = image.IsMain,
                        Name = fileService.Upload(image.File),
                    };

                    await carRepository.AddCarImage(car.Id, carImage, cancellationToken);
                }
                carRepository.Save();
            }

            if (request.Supplies != null && request.Supplies.Length > 0)
            {
                foreach (var supply in request.Supplies)
                {
                    var carSupply = new CarSupply
                    {
                        CarId = car.Id,
                        SupplyId = supply,
                    };
                    await carRepository.AddCarSupply(car.Id, carSupply, cancellationToken);
                }
                carRepository.Save();
            }

            return car;

        }
    }
}
