using MediatR;

namespace MashinAl.Business.Modules.AccountModule.Queries.DealerGetByIdQuery
{
    public class DealerGetByIdRequest : IRequest<DealerGetByIdDto>
    {
        public int Id { get; set; }
    }
}
