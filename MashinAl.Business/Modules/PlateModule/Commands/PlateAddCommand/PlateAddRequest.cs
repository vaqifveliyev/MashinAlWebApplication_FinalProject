using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Commands.PlateAddCommand
{
    public class PlateAddRequest : IRequest<Plate>
    {
        public int RegionId { get; set; }
        public int CityId { get; set; }
        public string FirstLetter { get; set; }
        public string SecondLetter { get; set; }
        public string PlateNumber { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CreatedBy { get; set; }
    }
}
