using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.CityModule.Queries.CityGetAllQuery
{
    internal class CityGetAllRequestHandler : IRequestHandler<CityGetAllRequest, IEnumerable<City>>
    {
        private readonly ICityRepository cityRepository;

        public CityGetAllRequestHandler(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public async Task<IEnumerable<City>> Handle(CityGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = cityRepository.GetAll();
            return await data.ToListAsync(cancellationToken);
        }
    }
}
