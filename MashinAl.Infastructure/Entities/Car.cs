namespace MashinAl.Infastructure.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int MarkaId { get; set; }
        public int ModelId { get; set; }
        public int YearId { get; set; }
        public int BanTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int GearboxId {  get; set; }
        public int TransmissionId { get; set; }
        public int March { get; set; }
        public int ColorId { get; set; }
        public int SeatsId { get; set; }
        public int StatusId { get; set; }
        public decimal Price { get; set; }
        public decimal Engine { get; set; }
        public bool IsBarter { get; set; }
        public bool IsCredit { get; set; }
        public bool IsDealership { get; set; }
        public bool IsBoosted { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int SellCityId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int CreatedBy { get; set; }
        public bool IsAccepted { get; set; } = false;
        public bool IsRejected { get; set; } = false;
        public int ViewCount { get; set; }
    }
}
