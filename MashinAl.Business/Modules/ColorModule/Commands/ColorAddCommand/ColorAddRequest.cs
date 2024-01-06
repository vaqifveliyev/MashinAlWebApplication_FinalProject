using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.ColorModule.Commands.ColorAddCommand
{
    public class ColorAddRequest : IRequest<Color>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}
