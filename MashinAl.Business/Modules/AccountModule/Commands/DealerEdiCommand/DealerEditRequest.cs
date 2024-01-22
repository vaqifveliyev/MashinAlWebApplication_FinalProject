using MediatR;
using Microsoft.AspNetCore.Http;

namespace MashinAl.Business.Modules.AccountModule.Commands.DealerEdiCommand
{
    public class DealerEditRequest : IRequest
    {
        public string Description { get; set; }
        public string DealerName { get; set; }
        public string DealerNumber { get; set; }
        public string Address { get; set; }
        public IFormFile Image { get; set; }
    }
}
