using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class RespostaService : ServiceBase<Resposta>, IRespostaService
    {

        private readonly IRespostaRepository _respostaRepository;

        public RespostaService(IRespostaRepository respostaRepository)
            : base(respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

    }
}
