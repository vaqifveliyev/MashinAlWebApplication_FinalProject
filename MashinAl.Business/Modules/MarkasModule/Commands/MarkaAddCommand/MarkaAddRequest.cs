using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.MarkasModule.Commands.MarkaAddCommand
{
    public class MarkaAddRequest : IRequest<Marka>
    {
        public string Name { get; set; }
    }
}
