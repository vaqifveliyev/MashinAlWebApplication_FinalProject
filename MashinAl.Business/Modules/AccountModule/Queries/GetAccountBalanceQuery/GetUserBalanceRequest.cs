using MediatR;

namespace MashinAl.Business.Modules.AccountModule.Queries.GetAccountBalanceQuery
{
    public class GetUserBalanceRequest : IRequest<GetUserBalanceDto>
    {
        public int Id { get; set; }
    }
}
