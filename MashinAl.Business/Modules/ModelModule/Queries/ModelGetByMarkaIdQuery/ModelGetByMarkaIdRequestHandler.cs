using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.ModelModule.Queries.ModelGetByMarkaIdQuery
{
    internal class ModelGetByMarkaIdRequestHandler : IRequestHandler<ModelGetByMarkaIdRequest, IEnumerable<ModelGetByMarkaIdDto>>
    {
        private readonly IModelRepository modelRepository;
        private readonly IMarkaRepository markaRepository;

        public ModelGetByMarkaIdRequestHandler(IModelRepository modelRepository, IMarkaRepository markaRepository)
        {
            this.modelRepository = modelRepository;
            this.markaRepository = markaRepository;
        }
        public async Task<IEnumerable<ModelGetByMarkaIdDto>> Handle(ModelGetByMarkaIdRequest request, CancellationToken cancellationToken)
        {
            var query = await (from models in modelRepository.GetAll()
                              join markas in markaRepository.GetAll() on models.MarkaId equals markas.Id
                              where models.MarkaId == request.MarkaId
                              select new ModelGetByMarkaIdDto
                              {
                                  Id = models.Id,
                                  Name = models.Name,
                                  MarkaId = models.MarkaId,
                              }).ToListAsync(cancellationToken);



            return query;
        }
    }
}
