using MediatR;

namespace MashinAl.Business.Modules.ModelModule.Queries.ModelGetAllQuery
{
    public class ModelGetAllRequest : IRequest<IEnumerable<ModelGetAllDto>>
    {

    }
}
