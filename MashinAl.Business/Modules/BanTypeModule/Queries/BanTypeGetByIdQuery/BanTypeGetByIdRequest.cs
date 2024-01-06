using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.BanTypeModule.Queries.BanTypeGetByIdQuery
{
    public class BanTypeGetByIdRequest : IRequest<BanType>
    {
        public int Id { get; set; }
    }
}
