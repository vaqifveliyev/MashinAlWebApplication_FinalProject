using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.ColorModule.Commands.ColorEditCommand
{
    internal class ColorEditRequestHandler : IRequestHandler<ColorEditRequest, Color>
    {
        private readonly IColorRepository colorRepository;

        public ColorEditRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorEditRequest request, CancellationToken cancellationToken)
        {
            var color = new Color
            {
                Id = request.Id,
                Name = request.Name,
                HexCode = request.HexCode,
            };

            colorRepository.Edit(color);
            colorRepository.Save();

            return color;
        }
    }
}
