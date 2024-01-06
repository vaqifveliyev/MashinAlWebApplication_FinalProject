using MediatR;

namespace MashinAl.Business.Modules.CarModule.Queries.CarGetAllByUserQuery
{
    public class CarGetAllByUserRequest : IRequest<IEnumerable<CarGetAllByUserDto>>
    {
        public int UserId { get; set; }
    }
}
