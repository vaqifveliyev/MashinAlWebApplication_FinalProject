using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Queries.PlateGetAllQuery
{
    public class PlateGetAllRequest : IRequest<IEnumerable<PlateGetAllDto>>
    {
    }
}
