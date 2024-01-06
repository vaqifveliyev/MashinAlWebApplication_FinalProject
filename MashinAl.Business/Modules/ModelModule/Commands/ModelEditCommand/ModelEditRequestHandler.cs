using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.ModelModule.Commands.ModelEditCommand
{
    internal class ModelEditRequestHandler : IRequestHandler<ModelEditRequest, Model>
    {
        private readonly IModelRepository modelRepository;

        public ModelEditRequestHandler(IModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }
        public async Task<Model> Handle(ModelEditRequest request, CancellationToken cancellationToken)
        {
            var model = new Model
            {
                Id = request.Id,
                Name = request.Name,
                MarkaId = request.MarkaId,
            };

            modelRepository.Edit(model);
            modelRepository.Save();

            return model;
        }
    }
}
