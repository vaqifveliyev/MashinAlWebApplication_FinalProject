using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.CarModule.Queries.FavoritesListQuery
{
    internal class FavoritesListRequestHandler : IRequestHandler<FavoritesListRequest, IEnumerable<FavoritesListItem>>
    {
        private readonly ICarRepository carRepository;
        private readonly IMarkaRepository markaRepository;
        private readonly IModelRepository modelRepository;
        private readonly IIdentityService identityService;

        public FavoritesListRequestHandler(ICarRepository carRepository, IMarkaRepository markaRepository, IModelRepository modelRepository, IIdentityService identityService)
        {
            this.carRepository = carRepository;
            this.markaRepository = markaRepository;
            this.modelRepository = modelRepository;
            this.identityService = identityService;
        }
        public async Task<IEnumerable<FavoritesListItem>> Handle(FavoritesListRequest request, CancellationToken cancellationToken)
        {
            var query = from c in carRepository.GetFavorites(identityService.GetPrincipalId().Value)
                        join cars in carRepository.GetAll() on c.CarId equals cars.Id
                        join marka in markaRepository.GetAll() on cars.MarkaId equals marka.Id
                        join model in modelRepository.GetAll() on cars.ModelId equals model.Id
                        join image in carRepository.GetImages(m => m.IsMain) on cars.Id equals image.CarId
                        select new FavoritesListItem
                        {
                            CarId = cars.Id,
                            MarkaName = marka.Name,
                            ModelName = model.Name,
                            ImagePath = image.Name,
                            Price = cars.Price,
                            IsAccepted = cars.IsAccepted,
                            IsBarter = cars.IsBarter,
                            IsBoosted = cars.IsBoosted,
                            IsCredit = cars.IsCredit,
                            IsDealership = cars.IsDealership,
                            March = cars.March,
                            Engine = cars.Engine,
                            YearId = cars.YearId,
                            IsRejected = cars.IsRejected,
                            PublishedAt = cars.PublishedAt,

                        };

            return await query.OrderByDescending(m => m.PublishedAt).ToListAsync(cancellationToken);
        }
    }
}
