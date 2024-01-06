using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.CityModule.Commands.CityRemoveCommand
{
    internal class CityRemoveRequestHandler : IRequestHandler<CityRemoveRequest>
    {
        private readonly ICityRepository cityRepository;

        public CityRemoveRequestHandler(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public async Task Handle(CityRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = cityRepository.Get(m => m.Id == request.Id);
            cityRepository.Remove(data);
            cityRepository.Save();
        }
    }
}
