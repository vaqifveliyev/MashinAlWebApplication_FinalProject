using MediatR;

namespace MashinAl.Business.Modules.CarModule.Queries.ComplexSearchQuery
{
    public class ComplexSearchRequest : IRequest<IEnumerable<ComplexSearchResponseDto>>
    {
        public int Marka { get; set; }
        public int Model { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; } 
        public bool IsCredit { get; set; }
        public bool IsBarter { get; set; }
        public bool IsNew { get; set; }
        public bool IsDriven { get; set; }
        public int March { get; set; }
        public int City { get; set; }
        public int Transmission { get; set; }
        public int Color { get; set; }
        public int FuelType { get; set; }
    }
}
