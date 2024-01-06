using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.SeatsModule.Queries.SeatsGetByIdQuery
{
    public class SeatsGetByIdRequest : IRequest<Seats>
    {
        public int Id { get; set; }
    }
}
