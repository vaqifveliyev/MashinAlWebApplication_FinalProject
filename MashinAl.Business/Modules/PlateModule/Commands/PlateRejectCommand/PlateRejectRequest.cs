using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Commands.PlateRejectCommand
{
    public class PlateRejectRequest : IRequest
    {
        public int Id { get; set; } 
        public string Reason { get; set; }
    }
}
