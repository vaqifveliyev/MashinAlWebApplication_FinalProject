using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.MarkasModule.Queries.MarkaGetAllQuery
{

    internal class MarkaGetAllRequestHandler : IRequestHandler<MarkaGetAllRequest, IEnumerable<MarkaGetAllDto>>
    {
        private readonly IMarkaRepository markaRepository;
        private readonly ICarRepository carRepository;


        public MarkaGetAllRequestHandler(IMarkaRepository markaRepository, ICarRepository carRepository)
        {
            this.markaRepository = markaRepository;
            this.carRepository = carRepository;
        }
        public async Task<IEnumerable<MarkaGetAllDto>> Handle(MarkaGetAllRequest request, CancellationToken cancellationToken)
        {
            var markas = await markaRepository.GetAll().ToListAsync();
            var cars = await carRepository.GetAll().ToListAsync();

            var data = markas
                .Select(marka => new MarkaGetAllDto
                {
                    Id = marka.Id,
                    Name = marka.Name,
                    Cars = cars.Where(car => car.MarkaId == marka.Id).ToList()
                })
                .ToList();

            return data;
        }


    }
}
