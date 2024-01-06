using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.RegionModule.Commands.RegionAddCommand
{
    public class RegionAddRequest : IRequest<Region>
    {
        public string Title { get; set; }
        public int ShortTitle {  get; set; }
    }
}
