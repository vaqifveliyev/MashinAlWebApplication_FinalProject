using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.ModelModule.Commands.ModelEditCommand
{
    public class ModelEditRequest : IRequest<Model>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarkaId { get; set; }
    }
}
