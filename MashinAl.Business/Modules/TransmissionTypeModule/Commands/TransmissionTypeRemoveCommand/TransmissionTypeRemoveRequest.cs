using MediatR;

namespace MashinAl.Business.Modules.TransmissionTypeModule.Commands.TransmissionTypeRemoveCommand
{
    public class TransmissionTypeRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
