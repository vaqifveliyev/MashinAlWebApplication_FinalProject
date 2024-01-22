using MediatR;

namespace MashinAl.Business.Modules.CarModule.Queries.CarGetAllByDealerQuery
{
    public class CarGetAllByDealerListRequest : IRequest<IEnumerable<CarGetAllByDealerListItem>>
    {
        public int Id { get; set; }
    }
}
