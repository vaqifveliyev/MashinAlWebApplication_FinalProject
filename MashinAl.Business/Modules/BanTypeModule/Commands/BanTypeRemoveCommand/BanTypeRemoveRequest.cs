using MediatR;

namespace MashinAl.Business.Modules.BanTypeModule.Commands.BanTypeRemoveCommand
{
    public class BanTypeRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
