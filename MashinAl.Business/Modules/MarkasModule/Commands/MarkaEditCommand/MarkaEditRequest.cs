using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.MarkasModule.Commands.MarkaEditCommand
{
    public class MarkaEditRequest : IRequest<Marka>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
