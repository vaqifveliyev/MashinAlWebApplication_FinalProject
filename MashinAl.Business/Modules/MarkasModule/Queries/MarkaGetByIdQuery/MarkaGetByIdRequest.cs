using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.MarkasModule.Queries.MarkaGetByIdQuery
{
    public class MarkaGetByIdRequest  : IRequest<Marka>
    {
        public int Id { get; set; }
    }
}
