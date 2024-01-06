using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.ColorModule.Queries.ColorGetAllQuery
{
    public class ColorGetAllRequest : IRequest<IEnumerable<Color>>
    {
    }
}
