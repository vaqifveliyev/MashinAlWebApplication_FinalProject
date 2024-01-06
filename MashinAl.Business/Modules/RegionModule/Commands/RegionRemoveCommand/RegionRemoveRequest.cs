using MediatR;

namespace MashinAl.Business.Modules.RegionModule.Commands.RegionRemoveCommand
{
    public class RegionRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
