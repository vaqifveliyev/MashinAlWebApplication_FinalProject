using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CarStatusModule.Queries.CarStatusGetByIdQuery
{
    public class CarStatusGetByIdRequest : IRequest<CarStatus>
    {
        public int Id { get; set; }
    }
}
