using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.TransmissionTypeModule.Queries.TransmissionTypeGetByIdQuery
{
    public class TransmissionTypeGetByIdRequest : IRequest<TransmissionType>
    {
        public int Id { get; set; }
    }
}
