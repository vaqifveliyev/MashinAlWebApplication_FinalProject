using MashinAl.Infastructure.Entities;

namespace MashinAl.Business.Modules.MarkasModule.Queries.MarkaGetAllQuery
{
    public class MarkaGetAllDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
