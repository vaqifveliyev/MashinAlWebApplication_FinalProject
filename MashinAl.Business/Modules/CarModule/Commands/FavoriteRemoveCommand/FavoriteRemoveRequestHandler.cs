using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.FavoriteRemoveCommand
{
    internal class FavoriteRemoveRequestHandler : IRequestHandler<FavoriteRemoveRequest, Favorites>
    {
        private readonly ICarRepository carRepository;
        private readonly IIdentityService identityService;

        public FavoriteRemoveRequestHandler(ICarRepository carRepository, IIdentityService identityService)
        {
            this.carRepository = carRepository;
            this.identityService = identityService;
        }
        public async Task<Favorites> Handle(FavoriteRemoveRequest request, CancellationToken cancellationToken)
        {
            var favorites = new Favorites
            {
                UserId = identityService.GetPrincipalId().Value,
                CarId = request.CarId,
            };

            await carRepository.RemoveFromFavorites(favorites, cancellationToken);

            return favorites;
        }
    }
}
