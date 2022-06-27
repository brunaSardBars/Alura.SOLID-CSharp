using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handles
{
    public class ArquivamentoAdminService : IAdminService
    {
        IAdminService _defaultService;

        public ArquivamentoAdminService(ILeilaoDAO leilaoDAO, ICategoriaDAO categoriaDAO)
        {
            _defaultService = new DefaultAdminService(leilaoDAO, categoriaDAO);
        }
        public void CadastraLeilao(Leilao leilao)
        {
            _defaultService.CadastraLeilao(leilao);
        }

        public IEnumerable<CategoriaComInfoLeilao> ConsultaCategorias()
        {
            return _defaultService.ConsultaCategorias();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _defaultService.ConsultaLeilaoPorId(id);
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _defaultService
                    .ConsultaLeiloes()
                    .Where(l => l.Situacao != SituacaoLeilao.Arquivado);
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            _defaultService.FinalizaPregaoDoLeilaoComId(id);
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            _defaultService.IniciaPregaoDoLeilaoComId(id);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            _defaultService.ModificaLeilao(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {

            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                _defaultService.ModificaLeilao(leilao);
            }
        }
    }
}
