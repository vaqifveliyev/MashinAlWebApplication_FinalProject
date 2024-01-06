using MashinAl.Business.Modules.AccountModule.Commands.RegisterCommand;
using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.CarPublishCommand
{
    internal class CarPublishRequestHandler : IRequestHandler<CarPublishRequest>
    {
        private readonly ICarRepository carRepository;
        private readonly IEmailService emailService;
        private readonly IMarkaRepository markaRepository;
        private readonly IModelRepository modelRepository;

        public CarPublishRequestHandler(ICarRepository carRepository, IEmailService emailService, IMarkaRepository markaRepository, IModelRepository modelRepository)
        {
            this.carRepository = carRepository;
            this.emailService = emailService;
            this.markaRepository = markaRepository;
            this.modelRepository = modelRepository;
        }
        public async Task Handle(CarPublishRequest request, CancellationToken cancellationToken)
        {
            var entity = carRepository.Get(m => m.Id == request.Id);

            entity.IsAccepted = true;
            entity.IsRejected = false;
            entity.PublishedAt = DateTime.UtcNow;
            carRepository.Save();

            string name = entity.Name;
            string email = entity.Email;

            string markaName = markaRepository.Get(mr => mr.Id == entity.MarkaId).Name;
            string modelName = modelRepository.Get(md => md.Id == entity.ModelId).Name;
            int carId = entity.Id;

            string htmlMessage = PublishCarEmail.PublishCarMessage(name, markaName, modelName, carId);

            await emailService.SendMailAsync(email, "MashinAl | Elan Təsdiqi", htmlMessage);
        }
    }
}
