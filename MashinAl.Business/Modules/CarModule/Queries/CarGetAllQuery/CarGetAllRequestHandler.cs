﻿using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.CarModule.Queries.CarGetAllQuery
{
    internal class CarGetAllRequestHandler : IRequestHandler<CarGetAllRequest, IEnumerable<CarGetAllDto>>
    {
        private readonly ICarRepository carRepository;
        private readonly IMarkaRepository markaRepository;
        private readonly IModelRepository modelRepository;
        private readonly IYearRepository yearRepository;
        private readonly IBanTypeRepository banTypeRepository;
        private readonly IFuelTypeRepository fuelTypeRepository;
        private readonly IGearBoxTypeRepository gearBoxTypeRepository;
        private readonly ITransmissionTypeRepository transmissionTypeRepository;
        private readonly IColorRepository colorRepository;
        private readonly ISeatRepository seatRepository;
        private readonly ICarStatusRepository carStatusRepository;
        private readonly ICityRepository cityRepository;

        public CarGetAllRequestHandler(ICarRepository carRepository, IMarkaRepository markaRepository,
            IModelRepository modelRepository,IYearRepository yearRepository,
            IBanTypeRepository banTypeRepository, IFuelTypeRepository fuelTypeRepository,
            IGearBoxTypeRepository gearBoxTypeRepository, ITransmissionTypeRepository transmissionTypeRepository,
            IColorRepository colorRepository, ISeatRepository seatRepository,
            ICarStatusRepository carStatusRepository, ICityRepository cityRepository)
        {
            this.carRepository = carRepository;
            this.markaRepository = markaRepository;
            this.modelRepository = modelRepository;
            this.yearRepository = yearRepository;
            this.banTypeRepository = banTypeRepository;
            this.fuelTypeRepository = fuelTypeRepository;
            this.gearBoxTypeRepository = gearBoxTypeRepository;
            this.transmissionTypeRepository = transmissionTypeRepository;
            this.colorRepository = colorRepository;
            this.seatRepository = seatRepository;
            this.carStatusRepository = carStatusRepository;
            this.cityRepository = cityRepository;
        }

        public async Task<IEnumerable<CarGetAllDto>> Handle(CarGetAllRequest request, CancellationToken cancellationToken)
        {

            var query = await (from c in carRepository.GetAll()
                         join m in markaRepository.GetAll() on c.MarkaId equals m.Id
                         join model in modelRepository.GetAll() on c.ModelId equals model.Id
                         //join year in yearRepository.GetAll() on c.YearId equals year.Id
                         join ban in banTypeRepository.GetAll() on c.BanTypeId equals ban.Id
                         join fuel in fuelTypeRepository.GetAll() on c.FuelTypeId equals fuel.Id
                         join g in gearBoxTypeRepository.GetAll() on c.GearboxId equals g.Id
                         join tr in transmissionTypeRepository.GetAll() on c.TransmissionId equals tr.Id
                         join color in colorRepository.GetAll() on c.ColorId equals color.Id
                         join st in seatRepository.GetAll() on c.SeatsId equals st.Id
                         join cs in carStatusRepository.GetAll() on c.StatusId equals cs.Id
                         join city in cityRepository.GetAll() on c.SellCityId equals city.Id
                         join images in carRepository.GetImages(m => m.IsMain ==true) on c.Id equals images.CarId
                         select new CarGetAllDto
                         {
                             Id = c.Id,
                             MarkaId = c.MarkaId,
                             MarkaName = m.Name,
                             ModelId = c.ModelId,
                             ModelName = model.Name,
                             YearId = c.YearId,
                             //YearTitle = year.YearTitle,
                             BanTypeId = c.BanTypeId,
                             BanName = ban.Name,
                             FuelTypeId = c.FuelTypeId,
                             FuelName = fuel.Name,
                             GearboxId = c.GearboxId,
                             GearboxTitle = g.Name,
                             TransmissionId = c.TransmissionId,
                             TransmissionName = tr.Name,
                             ColorId = c.ColorId,
                             ColorName = color.Name,
                             SeatsId = c.SeatsId,
                             SeatsTitle = st.SeatTitle,
                             StatusId = c.StatusId,
                             StatusName = cs.Title,
                             SellCityId = c.SellCityId,
                             SellCityName = city.Name,
                             Price = c.Price,
                             ImagePath = images.Name,
                             March = c.March,
                             Engine = c.Engine,
                             IsBarter   = c.IsBarter,
                             IsCredit = c.IsCredit,
                             Description = c.Description,
                             Name = c.Name,
                             Email = c.Email,
                             Phone = c.Phone,
                             PublishedAt = c.PublishedAt,
                             CreatedBy = c.CreatedBy,
                             IsAccepted = c.IsAccepted,
                             IsRejected = c.IsRejected,
                             IsBoosted = c.IsBoosted,
                             IsDealership = c.IsDealership,
                         }).ToListAsync(cancellationToken);

            return query.OrderByDescending(m => m.PublishedAt);

        }
    }
}
