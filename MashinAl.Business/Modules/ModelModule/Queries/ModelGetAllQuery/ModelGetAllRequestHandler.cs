using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.ModelModule.Queries.ModelGetAllQuery
{
    internal class ModelGetAllRequestHandler : IRequestHandler<ModelGetAllRequest, IEnumerable<ModelGetAllDto>>
    {
        private readonly IModelRepository modelRepository;
        private readonly IMarkaRepository markaRepository;

        public ModelGetAllRequestHandler(IModelRepository modelRepository, IMarkaRepository markaRepository)
        {
            this.modelRepository = modelRepository;
            this.markaRepository = markaRepository;
        }

        public async Task<IEnumerable<ModelGetAllDto>> Handle(ModelGetAllRequest request, CancellationToken cancellationToken)
        {
            //var data = modelRepository.GetAll();
            //return await data.ToListAsync(cancellationToken); 

            var data = await (from models in modelRepository.GetAll()
                        join markas in markaRepository.GetAll() on models.MarkaId equals markas.Id
                        select new ModelGetAllDto
                        {
                            Id = models.Id,
                            Name = models.Name,
                            MarkaId = models.MarkaId,
                            MarkaName = markas.Name
                        }).ToListAsync(cancellationToken);

            return data;
        }
    }
}
