using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.FuelTypeModule.Queries.FuelTypeGetByIdQuery
{
    public class FuelTypeGetByIdRequest : IRequest<FuelType>
    {
        public int Id { get; set; }
    }
}
