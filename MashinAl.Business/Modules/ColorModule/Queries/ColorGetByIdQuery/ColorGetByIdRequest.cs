using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.ColorModule.Queries.ColorGetByIdQuery
{
    public class ColorGetByIdRequest : IRequest<Color>
    {
        public int Id { get; set; } 
    }
}
