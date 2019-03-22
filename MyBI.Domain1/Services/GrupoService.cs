using System;
//using System.Data.Entity.Infrastructure;
using System.Transactions;
using MyBI.Domain1.DTO;
using MyBI.Domain1.DTO.InterfacesDTO;
using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;
using MyBI.Domain1.Specifications;

namespace MyBI.Domain1.Services
{
    public class GrupoService : ServiceBase<Grupo>, IGrupoService
    {

        readonly IGrupoRepository _grupoRepository;
        readonly IGrupoTelaRepository _grupoTelaRepository;

        public GrupoService(IGrupoRepository grupoRepository, IGrupoTelaRepository grupoTelaRepository)
            : base(grupoRepository)
        {
            _grupoRepository = grupoRepository;
            _grupoTelaRepository = grupoTelaRepository;
        }

        public bool AddGrupoTela(IGrupoDTO grupoDTO)
        {
            try
            {
                if (grupoDTO.Acao == Enums.Comuns.SistemaEnuns.Acao.INCLUIR)
                {
                    using (var tran = new TransactionScope())
                    {
                        _grupoRepository.Add(grupoDTO.Grupo);
                        _grupoRepository.SaveChanges();
                        AdicionaGrupoTela(grupoDTO);

                        tran.Complete();
                    }
                }
                if(grupoDTO.Acao == Enums.Comuns.SistemaEnuns.Acao.ALTERAR)
                {
                    var telasExcluir = _grupoTelaRepository.GetTelasHabilitadas(grupoDTO.Grupo.IdGrupo);
                    foreach (var excluiGrupoTela in telasExcluir)
                    {
                        _grupoTelaRepository.Delete(excluiGrupoTela);
                        _grupoTelaRepository.SaveChanges();
                    }
                    using (var tran = new TransactionScope())
                    {
                                             
                        _grupoRepository.UpdateGrupo(grupoDTO.Grupo);
                        _grupoRepository.SaveChanges();

                        AdicionaGrupoTela(grupoDTO);

                        tran.Complete();
                    }
                }
                return true;
            }
            catch(FormatException errorDB)
            {
                throw errorDB;
            }
            catch (Exception erroAdd)
            {
                throw erroAdd;
            }
           
        }
        private void AdicionaGrupoTela(IGrupoDTO grupoDTO)
        {
            try
            {
                
                foreach (var grupoTela in grupoDTO.GrupoTelas)
                {
                    grupoTela.IdGrupo = grupoDTO.Grupo.IdGrupo;
                    _grupoTelaRepository.Add(grupoTela);
                    _grupoTelaRepository.SaveChanges();
                }
                
            }
            catch (Exception erroGrupotela)
            {
                throw new Exception("ERRO AO ADICIONAR AS TELAS AO GRUPO \n \n" + erroGrupotela.Message);
            }
        }
        public void UpdateGrupo(Grupo _grupo)
        {
            _grupoRepository.UpdateGrupo(_grupo);
        }
    }
}
