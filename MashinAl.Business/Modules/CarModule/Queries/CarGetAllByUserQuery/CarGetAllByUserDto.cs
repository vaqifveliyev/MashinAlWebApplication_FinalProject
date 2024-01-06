namespace MashinAl.Business.Modules.CarModule.Queries.CarGetAllByUserQuery
{
    public class CarGetAllByUserDto
    {
        public int Id { get; set; }
        public int MarkaId { get; set; }
        public string MarkaName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int YearId { get; set; }
        public int YearTitle { get; set; }
        public int BanTypeId { get; set; }
        public string BanName { get; set; }
        public int FuelTypeId { get; set; }
        public string FuelName { get; set; }
        public int GearboxId { get; set; }
        public string GearboxTitle { get; set; }
        public int TransmissionId { get; set; }
        public string TransmissionName { get; set; }
        public int March { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int SeatsId { get; set; }
        public int SeatsTitle { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public decimal Price { get; set; }
        public decimal Engine { get; set; }
        public bool IsBarter { get; set; }
        public bool IsCredit { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int SellCityId { get; set; }
        public string SellCityName { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int CreatedBy { get; set; }
        public string ImagePath { get; set; }
        public int UserId { get; set; }
    }
}
