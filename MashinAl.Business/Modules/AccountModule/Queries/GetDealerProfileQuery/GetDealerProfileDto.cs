namespace MashinAl.Business.Modules.AccountModule.Queries.GetDealerProfileQuery
{
    public class GetDealerProfileDto
    {
        public int Id { get; set; }
        public int Balance {  get; set; }
        public string Description { get; set; }
        public string DealerName { get; set; }
        public string DealerNumber { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
    }
}
