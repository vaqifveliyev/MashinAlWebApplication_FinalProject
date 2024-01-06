using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.BanTypeModule.Queries.BanTypeGetAllQuery
{
    public class BanTypeGetAllRequest : IRequest<IEnumerable<BanType>>
    {
    }
}
