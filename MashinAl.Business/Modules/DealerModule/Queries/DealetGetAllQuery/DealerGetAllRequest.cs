using MediatR;

namespace MashinAl.Business.Modules.DealerModule.Queries.DealetGetAllQuery
{
    public class DealerGetAllRequest : IRequest<IEnumerable<DealerGetAllDto>>
    {
    }
}
