using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Commands.PlatePublishCommand
{
    public class PlatePublishRequest : IRequest
    {
        public int Id { get; set; }
    }
}
