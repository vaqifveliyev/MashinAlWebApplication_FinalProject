using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CityModule.Commands.CityAddCommand
{
    public class CityAddRequest : IRequest<City>
    {
        public string Name { get; set; }
    }
}
