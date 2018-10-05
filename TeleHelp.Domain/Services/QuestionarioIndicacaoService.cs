using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class QuestionarioIndicacaoService : ServiceBase<QuestionarioIndicacao>, IQuestionarioIndicacaoService
    {

        private readonly IQuestionarioIndicacaoRepository _questionarioIndicacaoRepository;

        public QuestionarioIndicacaoService(IQuestionarioIndicacaoRepository questionarioIndicacaoRepository)
            : base(questionarioIndicacaoRepository)
        {
            _questionarioIndicacaoRepository = questionarioIndicacaoRepository;
        }

    }
}
