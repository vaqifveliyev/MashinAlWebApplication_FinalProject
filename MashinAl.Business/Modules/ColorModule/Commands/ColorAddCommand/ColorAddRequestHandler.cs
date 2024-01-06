using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.ColorModule.Commands.ColorAddCommand
{
    internal class ColorAddRequestHandler : IRequestHandler<ColorAddRequest, Color>
    {
        private readonly IColorRepository colorRepository;

        public ColorAddRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorAddRequest request, CancellationToken cancellationToken)
        {
            var color = new Color
            {
                Name = request.Name,
                HexCode = request.HexCode,
            };

            colorRepository.Add(color);
            colorRepository.Save();

            return color;
        }
    }
}
