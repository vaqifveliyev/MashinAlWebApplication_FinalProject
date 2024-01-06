using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.MarkasModule.Commands.MarkaAddCommand
{
    internal class BanTypeAddRequestHandler : IRequestHandler<MarkaAddRequest, Marka>
    {
        private readonly IMarkaRepository markaRepository;

        public BanTypeAddRequestHandler(IMarkaRepository markaRepository)
        {
            this.markaRepository = markaRepository;
        }
        public async Task<Marka> Handle(MarkaAddRequest request, CancellationToken cancellationToken)
        {
            var marka = new Marka
            {
                Name = request.Name
            };

            markaRepository.Add(marka);
            markaRepository.Save();

            return marka;
        }
    }
}
