using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CarStatusModule.Queries.CarStatusGetAllQuery
{
    public class CarStatusGetAllRequest : IRequest<IEnumerable<CarStatus>>
    {
    }
}
