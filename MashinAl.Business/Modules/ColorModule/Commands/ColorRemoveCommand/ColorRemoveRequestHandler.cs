using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.ColorModule.Commands.ColorRemoveCommand
{
    internal class ColorRemoveRequestHandler : IRequestHandler<ColorRemoveRequest>
    {
        private readonly IColorRepository colorRepository;

        public ColorRemoveRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task Handle(ColorRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = colorRepository.Get(m => m.Id == request.Id);
            colorRepository.Remove(data);
            colorRepository.Save();
        }
    }
}
