using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.ColorModule.Queries.ColorGetByIdQuery
{
    internal class ColorGetByIdRequestHandler : IRequestHandler<ColorGetByIdRequest, Color>
    {
        private readonly IColorRepository colorRepository;

        public ColorGetByIdRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = colorRepository.Get(m => m.Id == request.Id);

            return data;
        }
    }
}
