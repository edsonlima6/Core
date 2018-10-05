using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Application.Interface;
using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Application.Services
{
    public class EstadoApplication : AplicationBase<Estado>, IEstadoApplication
    {
        readonly IEstadoService _estadoService;
        public EstadoApplication(IEstadoService estadoService):base(estadoService)
        {
            _estadoService = estadoService;
        }
    }
}
