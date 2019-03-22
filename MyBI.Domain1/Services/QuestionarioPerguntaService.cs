using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
