using MashinAl.Infastructure.Commons.Abstracts;
using MashinAl.Infastructure.Commons.Concrates;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Queries.CarGetAllPagedQuery
{
    public class CarGetAllPagedRequest : Pageable, IRequest<IPagedResponse<CarGetAllPagedDto>>
    {
    }
}
