using Microsoft.AspNetCore.Identity;

namespace MashinAl.Infastructure.Entities.Membership
{
    public class MashinAlUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Balance { get; set; }

    }
}
