using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Queries.PlateGetAllByUserQuery
{
    public class PlateGetAllByUserRequest : IRequest<IEnumerable<PlateGetAllByUserDto>>
    {
        public int UserId { get; set; }
    }
}
