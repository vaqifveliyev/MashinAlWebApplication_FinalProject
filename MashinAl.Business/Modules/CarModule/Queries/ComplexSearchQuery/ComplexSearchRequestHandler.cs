using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.CarModule.Queries.ComplexSearchQuery
{
    internal class ComplexSearchRequestHandler : IRequestHandler<ComplexSearchRequest, IEnumerable<ComplexSearchResponseDto>>
    {
        private readonly ICarRepository carRepository;
        private readonly IModelRepository modelRepository;
        private readonly IMarkaRepository markaRepository;

        public ComplexSearchRequestHandler(ICarRepository carRepository, IModelRepository modelRepository, IMarkaRepository markaRepository)
        {
            this.carRepository = carRepository;
            this.modelRepository = modelRepository;
            this.markaRepository = markaRepository;
        }
        public async Task<IEnumerable<ComplexSearchResponseDto>> Handle(ComplexSearchRequest request, CancellationToken cancellationToken)
        {
            var query = carRepository.GetAll();


            if (request.Marka > 0)
            {
                query = query.Where(m => request.Marka == m.MarkaId);
            }

            if (request.Model > 0)
            {
                query = query.Where(m => request.Model == m.ModelId);
            }

            if (request.MaxPrice > 0)
            {
                query = query.Where(m => m.Price <= request.MaxPrice);
            }

            if (request.MinPrice > 0)
            {
                query = query.Where(m => m.Price >= request.MinPrice);
            }

            if (request.IsBarter == true)
            {
                query = query.Where(m => request.IsBarter == m.IsBarter);
            }

            if (request.IsCredit == true)
            {
                query = query.Where(m => request.IsCredit == m.IsCredit);
            }

            if (request.City > 0)
            {
                query = query.Where(m => request.City == m.SellCityId);
            }

            if (request.Transmission > 0)
            {
                query = query.Where(m => request.Transmission == m.TransmissionId);
            }

            if (request.FuelType > 0)
            {
                query = query.Where(m => request.FuelType == m.FuelTypeId);
            }

            if (request.Color > 0)
            {
                query = query.Where(m => request.Color == m.ColorId);
            }

            var carIds = await query.Select(m => m.Id).Distinct().ToArrayAsync(cancellationToken);

            var summaryQuery = await (from c in query.Where(m => carIds.Contains(m.Id))
                               join pi in carRepository.GetImages(m => m.IsMain == true) on c.Id equals pi.CarId
                               join model in modelRepository.GetAll() on c.ModelId equals model.Id
                               join marka in markaRepository.GetAll() on c.MarkaId equals marka.Id
                               select new ComplexSearchResponseDto
                               {
                                   Id = c.Id,
                                   Price = c.Price,
                                   MarkaName = marka.Name,
                                   ModelName = model.Name,
                                   ImagePath = pi.Name,
                                   Year = c.YearId,
                                   Engine = c.Engine,
                                   March = c.March,
                                   IsAccepted = c.IsAccepted,
                                   IsBarter = c.IsBarter,
                                   IsCredit = c.IsCredit,
                                   IsDealership = c.IsDealership,
                                   PublishedAt = c.PublishedAt,
                                   
                               }).ToListAsync(cancellationToken);

            return summaryQuery.OrderByDescending(m => m.PublishedAt);
        }
    }
}
