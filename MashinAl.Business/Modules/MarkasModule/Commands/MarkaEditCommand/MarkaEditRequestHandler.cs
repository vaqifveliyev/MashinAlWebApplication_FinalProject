using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.MarkasModule.Commands.MarkaEditCommand
{
    internal class MarkaEditRequestHandler : IRequestHandler<MarkaEditRequest, Marka>
    {
        private readonly IMarkaRepository markaRepository;

        public MarkaEditRequestHandler(IMarkaRepository markaRepository)
        {
            this.markaRepository = markaRepository;
        }
        public async Task<Marka> Handle(MarkaEditRequest request, CancellationToken cancellationToken)
        {
            var marka = new Marka
            {
                Id = request.Id,
                Name = request.Name,
            };

            markaRepository.Edit(marka);
            markaRepository.Save();

            return marka;
        }
    }
}
