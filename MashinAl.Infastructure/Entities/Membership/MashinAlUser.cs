using Microsoft.AspNetCore.Identity;

namespace MashinAl.Infastructure.Entities.Membership
{
    public class MashinAlUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ImagePath { get; set; }
        public string? DealershipName { get; set; }
        public string? DealershipAddress { get; set; }
        public string? DealershipNumber { get; set; }
        public string? DealershipDescription { get; set; }
        public string? WorkingHours { get; set; }
        public int Balance { get; set; }


    }
}
