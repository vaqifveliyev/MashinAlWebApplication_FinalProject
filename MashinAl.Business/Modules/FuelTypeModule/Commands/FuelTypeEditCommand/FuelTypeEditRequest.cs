using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.FuelTypeModule.Commands.FuelTypeEditCommand
{
    public class FuelTypeEditRequest : IRequest<FuelType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
