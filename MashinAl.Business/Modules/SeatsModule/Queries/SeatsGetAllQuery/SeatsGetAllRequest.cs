using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.SeatsModule.Queries.SeatsGetAllQuery
{
    public class SeatsGetAllRequest : IRequest<IEnumerable<Seats>>
    {
    }
}
