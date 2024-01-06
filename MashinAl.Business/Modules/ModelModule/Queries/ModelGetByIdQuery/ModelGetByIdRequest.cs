using MediatR;

namespace MashinAl.Business.Modules.ModelModule.Queries.ModelGetByIdQuery
{
    public class ModelGetByIdRequest : IRequest<ModelGetByIdDto>
    {
        public int Id { get; set; }
    }
}
