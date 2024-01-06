using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Queries.PlateGetByIdQuery
{
    public class PlateGetByIdRequest : IRequest<PlateGetByIdDto>
    {
        public int Id { get; set; }
    }
}
