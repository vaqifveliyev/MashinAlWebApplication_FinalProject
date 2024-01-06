using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.CityModule.Commands.CityEditCommand
{
    internal class CityEditRequestHandler : IRequestHandler<CityEditRequest, City>
    {
        private readonly ICityRepository cityRepository;

        public CityEditRequestHandler(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public async Task<City> Handle(CityEditRequest request, CancellationToken cancellationToken)
        {
            var city = new City
            {
                Id = request.Id,
                Name = request.Name,
            };

            cityRepository.Edit(city);
            cityRepository.Save();

            return city;
        }
    }
}
