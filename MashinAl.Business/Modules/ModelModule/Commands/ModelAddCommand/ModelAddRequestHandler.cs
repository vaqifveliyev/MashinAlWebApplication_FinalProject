using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.ModelModule.Commands.ModelAddCommand
{
    internal class ModelAddRequestHandler : IRequestHandler<ModelAddRequest, Model>
    {
        private readonly IModelRepository modelRepository;

        public ModelAddRequestHandler(IModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }
        public async Task<Model> Handle(ModelAddRequest request, CancellationToken cancellationToken)
        {
            var model = new Model
            {
                Name = request.Name,
                MarkaId = request.MarkaId
            };

            modelRepository.Add(model);
            modelRepository.Save();

            return model;
        }
    }
}
