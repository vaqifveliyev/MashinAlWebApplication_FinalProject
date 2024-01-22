using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.FavoriteAddCommand
{
    internal class FavoriteAddRequestHandler : IRequestHandler<FavoriteAddRequest, Favorites>
    {
        private readonly IIdentityService identityService;
        private readonly ICarRepository carRepository;

        public FavoriteAddRequestHandler(IIdentityService identityService, ICarRepository carRepository)
        {
            this.identityService = identityService;
            this.carRepository = carRepository;
        }
        public async Task<Favorites> Handle(FavoriteAddRequest request, CancellationToken cancellationToken)
        {
            var car = carRepository.Get(m => m.Id == request.CarId);

            var favorites = new Favorites
            {
                UserId = identityService.GetPrincipalId().Value,
                CarId = car.Id,
                Quantity = request.Quantity <= 0 ? 1 : request.Quantity,
            };

            await carRepository.AddToFavoritesAsync(favorites, cancellationToken);
            carRepository.Save();

            return favorites;
        }
    }
}
