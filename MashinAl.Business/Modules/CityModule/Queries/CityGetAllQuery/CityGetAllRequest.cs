using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CityModule.Queries.CityGetAllQuery
{
    public class CityGetAllRequest : IRequest<IEnumerable<City>>
    {
    }
}
