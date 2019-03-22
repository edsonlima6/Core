using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class AgendaService : ServiceBase<Agenda>, IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        public AgendaService(IAgendaRepository agendaRepository)
            : base(agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

    }
}
