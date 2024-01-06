using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.MarkasModule.Queries.MarkaGetByIdQuery
{
    internal class MarkaGetByIdRequestHandler : IRequestHandler<MarkaGetByIdRequest, Marka>
    {
        private readonly IMarkaRepository markaRepository;

        public MarkaGetByIdRequestHandler(IMarkaRepository markaRepository)
        {
            this.markaRepository = markaRepository;
        }
        public async Task<Marka> Handle(MarkaGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = markaRepository.Get(m => m.Id == request.Id);
            return data;
        }
    }
}
