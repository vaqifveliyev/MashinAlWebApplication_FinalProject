namespace MashinAl.Infastructure.Entities
{
    public class Plate
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }
        public string FirstLetter { get; set; }
        public string SecondLetter { get; set; }
        public string PlateNumber { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CreatedBy { get; set; }
        public bool IsAccepted { get; set; } = false;
        public bool IsRejected { get; set; } = false;
    }
}
