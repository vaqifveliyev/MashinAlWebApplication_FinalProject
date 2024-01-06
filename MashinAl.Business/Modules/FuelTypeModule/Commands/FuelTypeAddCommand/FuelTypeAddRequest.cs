using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.FuelTypeModule.Commands.FuelTypeAddCommand
{
    public class FuelTypeAddRequest : IRequest<FuelType>
    {
        public string Name { get; set; }
    }
}
