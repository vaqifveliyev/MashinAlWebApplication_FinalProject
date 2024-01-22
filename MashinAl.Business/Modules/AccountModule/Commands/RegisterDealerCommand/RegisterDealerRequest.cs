using MediatR;
using Microsoft.AspNetCore.Http;

namespace MashinAl.Business.Modules.AccountModule.Commands.RegisterDealerCommand
{
    public class RegisterDealerRequest : IRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string DealershipName { get; set; }
        public string DealershipAddress { get; set; }
        public string DealershipNumber { get; set; }
        public string DealershipDescription { get; set; }
        public string WorkingHours { get; set; }
        public IFormFile Image { get; set; }
    }
}
