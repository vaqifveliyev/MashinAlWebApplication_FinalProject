using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Commands.PlateAddCommand
{
    internal class PlateAddRequestHandler : IRequestHandler<PlateAddRequest, Plate>
    {
        private readonly IPlateRepository plateRepository;
        private readonly IIdentityService identityService;

        public PlateAddRequestHandler(IPlateRepository plateRepository, IIdentityService identityService)
        {
            this.plateRepository = plateRepository;
            this.identityService = identityService;
        }
        public async Task<Plate> Handle(PlateAddRequest request, CancellationToken cancellationToken)
        {
            int userId = Convert.ToInt32(identityService.GetPrincipalId());

            var plate = new Plate
            {
                RegionId = request.RegionId,
                CityId = request.CityId,
                FirstLetter = request.FirstLetter,
                SecondLetter = request.SecondLetter,
                PlateNumber = request.PlateNumber,
                Price = request.Price,
                Description = request.Description,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                CreatedBy = userId
            };

            plateRepository.Add(plate);
            plateRepository.Save();

            return plate;
        }
    }
}
