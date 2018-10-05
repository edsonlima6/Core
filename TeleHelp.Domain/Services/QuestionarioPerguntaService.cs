using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class QuestionarioPerguntaService : ServiceBase<QuestionarioPergunta>, IQuestionarioPerguntaService
    {

        private readonly IQuestionarioPerguntaRepository _questionarioPerguntaRepository;

        public QuestionarioPerguntaService(IQuestionarioPerguntaRepository questionarioPerguntaRepository)
            : base(questionarioPerguntaRepository)
        {
            _questionarioPerguntaRepository = questionarioPerguntaRepository;
        }

    }
}
