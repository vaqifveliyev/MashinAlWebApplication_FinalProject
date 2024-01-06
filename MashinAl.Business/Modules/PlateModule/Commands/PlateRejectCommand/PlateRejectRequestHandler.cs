using MashinAl.Business.Modules.AccountModule.Commands.RegisterCommand;
using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Commands.PlateRejectCommand
{
    internal class PlateRejectRequestHandler : IRequestHandler<PlateRejectRequest>
    {
        private readonly IPlateRepository plateRepository;
        private readonly IEmailService emailService;
        private readonly IRegionRepository regionRepository;

        public PlateRejectRequestHandler(IPlateRepository plateRepository, IEmailService emailService, IRegionRepository regionRepository)
        {
            this.plateRepository = plateRepository;
            this.emailService = emailService;
            this.regionRepository = regionRepository;
        }

        public async Task Handle(PlateRejectRequest request, CancellationToken cancellationToken)
        {
            var entity = plateRepository.Get(m => m.Id == request.Id);

            entity.IsRejected = true;
            entity.IsAccepted = false;
            plateRepository.Save();

            int regionTitle = regionRepository.Get(r => r.Id == entity.RegionId).ShortTitle;

            string name = entity.Name;
            string email = entity.Email;
            string plate = $"{regionTitle + entity.FirstLetter + entity.SecondLetter + entity.PlateNumber}";
            string rejectReason = request.Reason; 

            string htmlMessage = RejectEmail.RejectMessage(name, plate, rejectReason);

            await emailService.SendMailAsync(email, "MashinAl | Elan İmtinası", htmlMessage);
        }
    }
}
