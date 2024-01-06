using MediatR;

namespace MashinAl.Business.Modules.CarModule.Queries.CarGetAllQuery
{
    public class CarGetAllRequest : IRequest<IEnumerable<CarGetAllDto>>
    {
    }
}
