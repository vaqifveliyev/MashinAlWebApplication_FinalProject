namespace MashinAl.Business.Modules.CarModule.Queries.ComplexSearchQuery
{
    public class ComplexSearchResponseDto
    {
        public int Id { get; set; }
        public string MarkaName { get; set; }
        public string ModelName { get; set; }
        public int March { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsCredit { get; set; }
        public bool IsBarter { get; set; }
        public int Year { get; set; }
        public decimal Engine { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsDealership { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
