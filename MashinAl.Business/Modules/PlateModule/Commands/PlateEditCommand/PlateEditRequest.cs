using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Commands.PlateEditCommand
{
    public class PlateEditRequest : IRequest<Plate>
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }
        public string FirstLetter { get; set; }
        public string SecondLetter { get; set; }
        public string PlateNumber { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
