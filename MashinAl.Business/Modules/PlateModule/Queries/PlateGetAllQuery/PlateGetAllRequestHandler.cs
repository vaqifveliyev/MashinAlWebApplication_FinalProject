using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.PlateModule.Queries.PlateGetAllQuery
{
    internal class PlateGetAllRequestHandler : IRequestHandler<PlateGetAllRequest, IEnumerable<PlateGetAllDto>>
    {
        private readonly IPlateRepository plateRepository;
        private readonly IRegionRepository regionRepository;
        private readonly ICityRepository cityRepository;

        public PlateGetAllRequestHandler(IPlateRepository plateRepository, IRegionRepository regionRepository, ICityRepository cityRepository)
        {
            this.plateRepository = plateRepository;
            this.regionRepository = regionRepository;
            this.cityRepository = cityRepository;
        }
        public async Task<IEnumerable<PlateGetAllDto>> Handle(PlateGetAllRequest request, CancellationToken cancellationToken)
        {
            
            var query = await (from plates in plateRepository.GetAll()
                               join region in regionRepository.GetAll() on plates.RegionId equals region.Id
                               join city in cityRepository.GetAll() on plates.CityId equals city.Id
                               select new PlateGetAllDto
                               {
                                   Id  = plates.Id,
                                   RegionId = plates.RegionId,
                                   RegionTitle = region.ShortTitle,
                                   FirstLetter = plates.FirstLetter,
                                   SecondLetter = plates.SecondLetter,
                                   PlateNumber  = plates.PlateNumber,
                                   CityId = plates.CityId,
                                   CityName = city.Name,
                                   Price = plates.Price,
                                   Description = plates.Description,
                                   Name = plates.Name,
                                   Email = plates.Email,
                                   Phone = plates.Phone,
                                   PublishedAt = plates.PublishedAt,
                                   CreatedAt = plates.CreatedAt,
                                   IsAccepted = plates.IsAccepted,
                                   IsRejected = plates.IsRejected,

                               }).ToListAsync(cancellationToken);

            return query.OrderByDescending(m => m.PublishedAt);
        }
    }
}
