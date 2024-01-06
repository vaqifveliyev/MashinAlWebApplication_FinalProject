using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.TransmissionTypeModule.Queries.TransmissionTypeGetAllQuery
{
    public class TransmissionTypeGetAllRequest : IRequest<IEnumerable<TransmissionType>>
    {
    }
}
