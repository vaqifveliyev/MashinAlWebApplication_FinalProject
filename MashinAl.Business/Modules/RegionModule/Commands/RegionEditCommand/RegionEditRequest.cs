using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.RegionModule.Commands.RegionEditCommand
{
    public class RegionEditRequest : IRequest<Region>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ShortTitle { get; set; }
    }
}
