using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.ColorModule.Queries.ColorGetAllQuery
{
    internal class ColorGetAllRequestHandler : IRequestHandler<ColorGetAllRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository colorRepository;

        public ColorGetAllRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task<IEnumerable<Color>> Handle(ColorGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = colorRepository.GetAll();
            return await data.ToListAsync(cancellationToken);
        }
    }
}
