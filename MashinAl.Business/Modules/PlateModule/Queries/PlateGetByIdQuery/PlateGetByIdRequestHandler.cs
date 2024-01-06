using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.PlateModule.Queries.PlateGetByIdQuery
{
    internal class PlateGetByIdRequestHandler : IRequestHandler<PlateGetByIdRequest, PlateGetByIdDto>
    {
        private readonly IPlateRepository plateRepository;
        private readonly IRegionRepository regionRepository;
        private readonly ICityRepository cityRepository;

        public PlateGetByIdRequestHandler(IPlateRepository plateRepository, IRegionRepository regionRepository, ICityRepository cityRepository)
        {
            this.plateRepository = plateRepository;
            this.regionRepository = regionRepository;
            this.cityRepository = cityRepository;
        }
        public async Task<PlateGetByIdDto> Handle(PlateGetByIdRequest request, CancellationToken cancellationToken)
        {

            var query = (from plates in plateRepository.GetAll()
                         join region in regionRepository.GetAll() on plates.RegionId equals region.Id
                         join city in cityRepository.GetAll() on plates.CityId equals city.Id
                         where plates.Id == request.Id
                         select new PlateGetByIdDto
                         {
                             Id = plates.Id,
                             RegionId = plates.RegionId,
                             RegionTitle = region.ShortTitle,
                             FirstLetter = plates.FirstLetter,
                             SecondLetter = plates.SecondLetter,
                             PlateNumber = plates.PlateNumber,
                             CityId = plates.CityId,
                             CityName = city.Name,
                             Price = plates.Price,
                             Description = plates.Description,
                             Name = plates.Name,
                             Email = plates.Email,
                             Phone = plates.Phone,
                             PublishedAt = plates.PublishedAt,
                             CreatedAt = plates.CreatedAt,
                             IsRejected = plates.IsRejected,
                             IsAccepted = plates.IsAccepted,
                         });

            var data = await query.FirstOrDefaultAsync(cancellationToken);
            return data;
        }
    }
}
