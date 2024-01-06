using MediatR;

namespace MashinAl.Business.Modules.CarStatusModule.Commands.CarStatusRemoveCommand
{
    public class CarStatusRemoveRequest : IRequest
    {
       public int Id { get; set; }  
    }
}
