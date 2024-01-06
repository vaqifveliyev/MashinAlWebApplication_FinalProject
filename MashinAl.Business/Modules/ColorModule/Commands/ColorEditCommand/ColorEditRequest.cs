using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.ColorModule.Commands.ColorEditCommand
{
    public class ColorEditRequest : IRequest<Color>
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string HexCode { get; set; }
    }
}
