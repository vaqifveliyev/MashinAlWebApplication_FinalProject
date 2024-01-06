using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.TransmissionTypeModule.Commands.TransmissionTypeEditCommand
{
    public class TransmissionTypeEditRequest  : IRequest<TransmissionType>
    {
        public int Id { get; set; }
        public string Name { get; set; }   
    }
}
