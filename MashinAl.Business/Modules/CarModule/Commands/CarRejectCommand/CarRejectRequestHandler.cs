using MashinAl.Business.Modules.AccountModule.Commands.RegisterCommand;
using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.CarRejectCommand
{
    internal class CarRejectRequestHandler : IRequestHandler<CarRejectRequest>
    {
        private readonly ICarRepository carRepository;
        private readonly IMarkaRepository markaRepository;
        private readonly IModelRepository modelRepository;
        private readonly IEmailService emailService;

        public CarRejectRequestHandler(ICarRepository carRepository, IMarkaRepository markaRepository, IModelRepository modelRepository, IEmailService emailService)
        {
            this.carRepository = carRepository;
            this.markaRepository = markaRepository;
            this.modelRepository = modelRepository;
            this.emailService = emailService;
        }
        public async Task Handle(CarRejectRequest request, CancellationToken cancellationToken)
        {
            var entity = carRepository.Get(m=> m.Id ==request.Id);
            entity.IsRejected = true;
            entity.IsAccepted = false;
            carRepository.Save();

            int carId = entity.Id;
            string markaName = markaRepository.Get(mr => mr.Id == entity.Id).Name;
            string modelName = modelRepository.Get(md => md.Id == entity.Id).Name;
            string rejectReason = request.Reason;
            string name = entity.Name;
            string email = entity.Email;

            string htmlMessage = CarRejectEmail.CarRejectMessage(name, carId, markaName, modelName, rejectReason);

            await emailService.SendMailAsync(email, "MashinAl | Elan İmtinası", htmlMessage);
        }
    }
}
