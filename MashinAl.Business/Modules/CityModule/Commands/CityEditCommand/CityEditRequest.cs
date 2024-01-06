using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CityModule.Commands.CityEditCommand
{
    public class CityEditRequest : IRequest<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
