using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.CityModule.Commands.CityAddCommand
{
    internal class CityAddRequestHandler : IRequestHandler<CityAddRequest, City>
    {
        private readonly ICityRepository cityRepository;

        public CityAddRequestHandler(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public async Task<City> Handle(CityAddRequest request, CancellationToken cancellationToken)
        {
            var city = new City
            {
                Name = request.Name,
            };

            cityRepository.Add(city);
            cityRepository.Save();
            return city;
        }
    }
}
