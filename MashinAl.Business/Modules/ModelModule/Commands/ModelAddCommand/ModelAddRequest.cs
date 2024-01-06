using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.ModelModule.Commands.ModelAddCommand
{
    public class ModelAddRequest : IRequest<Model>
    {
        public string Name { get; set; }
        public int MarkaId { get; set; }
    }
}
