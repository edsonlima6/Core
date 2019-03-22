using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class QuestionarioService : ServiceBase<Questionario>, IQuestionarioService
    {

        private readonly IQuestionarioRepository _questionarioRepository;

        public QuestionarioService(IQuestionarioRepository questionarioRepository)
            : base(questionarioRepository)
        {
            _questionarioRepository = questionarioRepository;
        }

    }
}
