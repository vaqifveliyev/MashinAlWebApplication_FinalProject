using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CityModule.Queries.CityGetByIdQuery
{
    public class CityGetByIdRequest : IRequest<City>
    {
        public int Id { get; set; }
    }
}
