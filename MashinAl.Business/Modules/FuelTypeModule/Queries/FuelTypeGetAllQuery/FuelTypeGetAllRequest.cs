using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.FuelTypeModule.Queries.FuelTypeGetAllQuery
{
    public class FuelTypeGetAllRequest : IRequest<IEnumerable<FuelType>>
    {
    }
}
