using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
