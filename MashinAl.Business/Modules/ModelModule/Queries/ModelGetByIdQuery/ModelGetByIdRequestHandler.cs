using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.ModelModule.Queries.ModelGetByIdQuery
{
    internal class ModelGetByIdRequestHandler : IRequestHandler<ModelGetByIdRequest, ModelGetByIdDto>
    {
        private readonly IModelRepository modelRepository;
        private readonly IMarkaRepository markaRepository;

        public ModelGetByIdRequestHandler(IModelRepository modelRepository, IMarkaRepository markaRepository)
        {
            this.modelRepository = modelRepository;
            this.markaRepository = markaRepository;
        }
        public async Task<ModelGetByIdDto> Handle(ModelGetByIdRequest request, CancellationToken cancellationToken)
        {
            var query = (from models in modelRepository.GetAll()
                         join markas in markaRepository.GetAll() on models.MarkaId equals markas.Id
                         where models.Id == request.Id
                         select new ModelGetByIdDto
                         {
                             Id = models.Id,
                             Name = models.Name,
                             MarkaId = models.MarkaId,
                             MarkaName = markas.Name
                         });
            var data = await query.FirstOrDefaultAsync(cancellationToken);

            return data;
        }
    }
}
