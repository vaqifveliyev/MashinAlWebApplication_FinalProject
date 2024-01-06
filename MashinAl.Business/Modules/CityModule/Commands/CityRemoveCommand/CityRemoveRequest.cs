using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CityModule.Commands.CityRemoveCommand
{
    public class CityRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
