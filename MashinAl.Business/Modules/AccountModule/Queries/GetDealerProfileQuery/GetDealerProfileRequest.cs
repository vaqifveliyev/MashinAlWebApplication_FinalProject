using MediatR;

namespace MashinAl.Business.Modules.AccountModule.Queries.GetDealerProfileQuery
{
    public class GetDealerProfileRequest : IRequest<GetDealerProfileDto>
    {
        public int Id { get; set; }
    }
}
