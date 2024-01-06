using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.SupplyModule.Commands.SupplyAddCommand
{
    public class SupplyAddRequest : IRequest<Supply>
    {
        public string Title { get; set; }
    }
}
