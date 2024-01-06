using MediatR;

namespace MashinAl.Business.Modules.ModelModule.Commands.MarkaRemoveCommand
{
    public class ModelRemoveRequest : IRequest
    {
        public int Id { get; set; } 
    }
}
