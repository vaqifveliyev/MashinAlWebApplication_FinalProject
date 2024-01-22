using MediatR;

namespace MashinAl.Business.Modules.ModelModule.Queries.ModelGetByMarkaIdQuery
{
    public class ModelGetByMarkaIdRequest : IRequest<IEnumerable<ModelGetByMarkaIdDto>>
    {
        public int MarkaId { get; set; }
    }
}
