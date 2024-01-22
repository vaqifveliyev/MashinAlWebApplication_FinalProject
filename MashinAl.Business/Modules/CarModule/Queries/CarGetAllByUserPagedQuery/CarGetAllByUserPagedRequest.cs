using MashinAl.Infastructure.Commons.Abstracts;
using MashinAl.Infastructure.Commons.Concrates;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Queries.CarGetAllByUserQuery
{
    public class CarGetAllByUserPagedRequest : Pageable, IRequest<IPagedResponse<CarGetAllByUserPagedDto>>
    {
        public int UserId { get; set; }

        public override int Size
        {
            get
            {
                return base.Size < 10 ? 10 : base.Size;
            }
            set
            {
                base.Size = value < 10 ? 10 : value;
            }
        }
    }
}
