using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.CityModule.Queries.CityGetByIdQuery
{
    internal class CityGetByIdRequestHandler : IRequestHandler<CityGetByIdRequest, City>
    {
        private readonly ICityRepository cityRepository;

        public CityGetByIdRequestHandler(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public async Task<City> Handle(CityGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = cityRepository.Get(m => m.Id == request.Id);
            return data;
        }
    }
}
