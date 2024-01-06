using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.TransmissionTypeModule.Queries.TransmissionTypeGetAllQuery
{
    internal class TransmissionTypeGetAllRequestHandler : IRequestHandler<TransmissionTypeGetAllRequest, IEnumerable<TransmissionType>>
    {
        private readonly ITransmissionTypeRepository transmissionTypeRepository;

        public TransmissionTypeGetAllRequestHandler(ITransmissionTypeRepository transmissionTypeRepository)
        {
            this.transmissionTypeRepository = transmissionTypeRepository;
        }
        public async Task<IEnumerable<TransmissionType>> Handle(TransmissionTypeGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = transmissionTypeRepository.GetAll();
            return await data.ToListAsync(cancellationToken);
        }
    }
}
