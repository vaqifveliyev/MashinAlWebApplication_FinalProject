using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.BanTypeModule.Commands.BanTypeEditCommand
{
    public class BanTypeEditRequest : IRequest<BanType>
    {
        public int Id { get; set; }
        public string Name { get; set; } 
    }
}
