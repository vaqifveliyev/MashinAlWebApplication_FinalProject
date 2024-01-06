using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.ModelModule.Commands.MarkaRemoveCommand
{
    internal class ModelRemoveRequestHandler : IRequestHandler<ModelRemoveRequest>
    {
        private readonly IModelRepository modelRepository;

        public ModelRemoveRequestHandler(IModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }
        public async Task Handle(ModelRemoveRequest request, CancellationToken cancellationToken)
        {
            var model = modelRepository.Get(m => m.Id == request.Id);
            modelRepository.Remove(model);
            modelRepository.Save();
        }
    }
}
