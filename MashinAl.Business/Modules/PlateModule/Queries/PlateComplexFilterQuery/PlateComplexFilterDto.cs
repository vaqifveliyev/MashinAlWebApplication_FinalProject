namespace MashinAl.Business.Modules.PlateModule.Queries.PlateComplexFilterQuery
{
    public class PlateComplexFilterDto
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int RegionTitle { get; set; }
        public string FirstLetter { get; set; }
        public string SecondLetter { get; set; }
        public string PlateNumber { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
    }
}
