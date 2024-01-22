using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Queries.PlateComplexFilterQuery
{
    public class PlateComplexFilterRequest : IRequest<IEnumerable<PlateComplexFilterDto>>
    {
        public int RegionId { get; set; }
        public string FirstLetter { get; set; }
        public string SecondLetter { get; set; }
        public string PlateNumber { get; set; }
    }
}
