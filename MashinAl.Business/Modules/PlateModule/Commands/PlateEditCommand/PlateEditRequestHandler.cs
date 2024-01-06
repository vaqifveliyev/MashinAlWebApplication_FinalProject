using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Commands.PlateEditCommand
{
    internal class PlateEditRequestHandler : IRequestHandler<PlateEditRequest, Plate>
    {
        private readonly IPlateRepository plateRepository;
        private readonly IIdentityService identityService;

        public PlateEditRequestHandler(IPlateRepository plateRepository, IIdentityService identityService)
        {
            this.plateRepository = plateRepository;
            this.identityService = identityService;
        }
        public async Task<Plate> Handle(PlateEditRequest request, CancellationToken cancellationToken)
        {
            var plate = plateRepository.Get(m => m.Id == request.Id);


            plate.RegionId = request.RegionId;
            plate.FirstLetter = request.FirstLetter;
            plate.SecondLetter = request.SecondLetter;
            plate.PlateNumber = request.PlateNumber;
            plate.CityId = request.CityId;
            plate.Price = request.Price;
            plate.Name = request.Name;
            plate.Email = request.Email;
            plate.Phone = request.Phone;

            plateRepository.Edit(plate);
            plateRepository.Save();

            return plate;
        }
    }
}
