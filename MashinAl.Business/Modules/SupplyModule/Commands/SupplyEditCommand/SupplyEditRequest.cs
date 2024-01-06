using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.SupplyModule.Commands.SupplyEditCommand
{
    public class SupplyEditRequest : IRequest<Supply>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
