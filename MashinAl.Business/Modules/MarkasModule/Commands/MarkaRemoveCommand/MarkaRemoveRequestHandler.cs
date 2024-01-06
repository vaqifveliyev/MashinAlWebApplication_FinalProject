using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.MarkasModule.Commands.MarkaRemoveCommand
{
    internal class MarkaRemoveRequestHandler : IRequestHandler<MarkaRemoveRequest>
    {
        private readonly IMarkaRepository markaRepository;

        public MarkaRemoveRequestHandler(IMarkaRepository markaRepository)
        {
            this.markaRepository = markaRepository;
        }
        public  async Task Handle(MarkaRemoveRequest request, CancellationToken cancellationToken)
        {
            var marka = markaRepository.Get(m => m.Id == request.Id);
            markaRepository.Remove(marka);
            markaRepository.Save();
        }
    }
}
