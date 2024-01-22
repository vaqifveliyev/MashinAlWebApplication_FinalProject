using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.PlateModule.Queries.PlateComplexFilterQuery
{
    internal class PlateComplexFilterRequestHandler : IRequestHandler<PlateComplexFilterRequest, IEnumerable<PlateComplexFilterDto>>
    {
        private readonly IPlateRepository plateRepository;
        private readonly IRegionRepository regionRepository;
        private readonly ICityRepository cityRepository;

        public PlateComplexFilterRequestHandler(IPlateRepository plateRepository, IRegionRepository regionRepository,
            ICityRepository cityRepository)
        {
            this.plateRepository = plateRepository;
            this.regionRepository = regionRepository;
            this.cityRepository = cityRepository;
        }
        public async Task<IEnumerable<PlateComplexFilterDto>> Handle(PlateComplexFilterRequest request, CancellationToken cancellationToken)
        {
            var query = plateRepository.GetAll();

            if(request.RegionId > 0)
            {
                query = query.Where(p => request.RegionId == p.RegionId);
            }

            if (!string.IsNullOrEmpty(request.FirstLetter))
            {
                query = query.Where(p => request.FirstLetter == p.FirstLetter);
            }

            if (!string.IsNullOrEmpty(request.SecondLetter))
            {
                query = query.Where(p => request.FirstLetter == p.SecondLetter);
            }

            if(!string.IsNullOrEmpty(request.PlateNumber))
            {
                query = query.Where(p => request.PlateNumber == p.PlateNumber);
            }

            var plateIds = await query.Select(m => m.Id).Distinct().ToArrayAsync(cancellationToken);

            var summaryQuery = await (from p in query.Where(m => plateIds.Contains(m.Id))
                                      join region in regionRepository.GetAll() on p.RegionId equals region.Id
                                      join cities in cityRepository.GetAll() on p.CityId equals cities.Id
                                      select new PlateComplexFilterDto
                                      {
                                          Id = p.Id,
                                          RegionId = region.Id,
                                          RegionTitle = region.ShortTitle,
                                          FirstLetter = p.FirstLetter,
                                          SecondLetter = p.SecondLetter,
                                          PlateNumber = p.PlateNumber,
                                          Price = p.Price,
                                          PublishedAt = p.PublishedAt,
                                          CityName = cities.Name,
                                          Name = p.Name,
                                          IsAccepted = p.IsAccepted,
                                      }).ToListAsync(cancellationToken);

            return summaryQuery.OrderByDescending(m => m.PublishedAt);
        }
    }
}
