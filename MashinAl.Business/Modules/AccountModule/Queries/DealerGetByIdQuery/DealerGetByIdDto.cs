namespace MashinAl.Business.Modules.AccountModule.Queries.DealerGetByIdQuery
{
    public class DealerGetByIdDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DealershipName { get; set; }
        public string DealershipAddress { get; set; }
        public string DealershipNumber { get; set; }
        public string DealershipDescription { get; set; }
        public string WorkingHours { get; set; }
        public string ImagePath { get; set; }
    }
}
