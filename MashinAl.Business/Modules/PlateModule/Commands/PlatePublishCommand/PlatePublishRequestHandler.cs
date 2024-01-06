using MashinAl.Business.Modules.AccountModule.Commands.RegisterCommand;
using MashinAl.Infastructure.Repositories;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Commands.PlatePublishCommand
{
    internal class PlatePublishRequestHandler : IRequestHandler<PlatePublishRequest>
    {
        private readonly IPlateRepository plateRepository;
        private readonly IEmailService emailService;
        private readonly IRegionRepository regionRepository;

        public PlatePublishRequestHandler(IPlateRepository plateRepository, IEmailService emailService, IRegionRepository regionRepository)
        {
            this.plateRepository = plateRepository;
            this.emailService = emailService;
            this.regionRepository = regionRepository;
        }
        public async Task Handle(PlatePublishRequest request, CancellationToken cancellationToken)
        {
            var entity = plateRepository.Get(m => m.Id == request.Id);
            
            entity.IsAccepted = true; 
            entity.IsRejected = false;
            entity.PublishedAt = DateTime.UtcNow;
            plateRepository.Save();

            int regionTitle = regionRepository.Get(r => r.Id == entity.RegionId).ShortTitle;

            string name = entity.Name;
            string email = entity.Email;
            string plate = $"{regionTitle + entity.FirstLetter + entity.SecondLetter + entity.PlateNumber}";
            
            string htmlMessage = PublishEmail.PublishMessage(name, plate);

            await emailService.SendMailAsync(email, "MashinAl | Elan Təsdiqi", htmlMessage);
        }   
    }
}
