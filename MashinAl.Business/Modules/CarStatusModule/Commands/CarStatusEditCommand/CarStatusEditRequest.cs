using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CarStatusModule.Commands.CarStatusEditCommand
{
    public class CarStatusEditRequest : IRequest<CarStatus>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
