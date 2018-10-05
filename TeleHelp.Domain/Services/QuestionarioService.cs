using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
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
