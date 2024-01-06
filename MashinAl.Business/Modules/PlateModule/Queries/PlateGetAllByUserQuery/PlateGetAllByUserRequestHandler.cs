using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.PlateModule.Queries.PlateGetAllByUserQuery
{
    internal class PlateGetAllByUserRequestHandler : IRequestHandler<PlateGetAllByUserRequest, IEnumerable<PlateGetAllByUserDto>>
    {
        private readonly IPlateRepository plateRepository;
        private readonly IRegionRepository regionRepository;
        private readonly ICityRepository cityRepository;
        private readonly IIdentityService identityService;

        public PlateGetAllByUserRequestHandler(IPlateRepository plateRepository, IRegionRepository regionRepository, ICityRepository cityRepository, IIdentityService identityService)
        {
            this.plateRepository = plateRepository;
            this.regionRepository = regionRepository;
            this.cityRepository = cityRepository;
            this.identityService = identityService;
        }
        public async Task<IEnumerable<PlateGetAllByUserDto>> Handle(PlateGetAllByUserRequest request, CancellationToken cancellationToken)
        {
            int userId = Convert.ToInt32(identityService.GetPrincipalId());

            var query = await (
                from plates in plateRepository.GetAll()
                join region in regionRepository.GetAll() on plates.RegionId equals region.Id
                join city in cityRepository.GetAll() on plates.CityId equals city.Id
                where plates.CreatedBy == userId
                select new PlateGetAllByUserDto
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
                    IsAccepted = plates.IsAccepted,
                    IsRejected = plates.IsRejected,
                    UserId = plates.CreatedBy

                }).ToListAsync(cancellationToken);

            return query;
        }
    }
}
