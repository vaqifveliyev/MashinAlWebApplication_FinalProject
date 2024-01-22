namespace MashinAl.Business.Modules.CarModule.Queries.FavoritesListQuery
{
    public  class FavoritesListItem
    {
        public int CarId { get; set; }
        public int MarkaId { get; set; }
        public string MarkaName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
        public bool IsBoosted { get; set; }
        public bool IsDealership { get; set; }
        public bool IsCredit { get; set; }
        public bool IsBarter { get; set; }
        public int YearId { get; set; }
        public decimal Engine { get; set; }
        public int March { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
