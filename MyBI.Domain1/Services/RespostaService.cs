using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
