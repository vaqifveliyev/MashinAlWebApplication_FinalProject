using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.TransmissionTypeModule.Commands.TransmissionTypeAddCommand
{
    public class TransmissionTypeAddRequest : IRequest<TransmissionType>
    {
        public string Name { get; set; }
    }
}
