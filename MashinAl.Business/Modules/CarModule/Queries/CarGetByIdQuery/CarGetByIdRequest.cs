using MediatR;

namespace MashinAl.Business.Modules.CarModule.Queries.CarGetByIdQuery
{
    public class CarGetByIdRequest : IRequest<CarGetByIdDto>
    {
        public int Id { get; set; }
    }
}
