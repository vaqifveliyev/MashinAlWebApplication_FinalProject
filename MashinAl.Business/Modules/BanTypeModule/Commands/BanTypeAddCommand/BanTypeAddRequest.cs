using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.BanTypeModule.Commands.BanTypeAddCommand
{
    public class BanTypeAddRequest : IRequest<BanType>
    {
        public string Name { get; set; }
    }
}
