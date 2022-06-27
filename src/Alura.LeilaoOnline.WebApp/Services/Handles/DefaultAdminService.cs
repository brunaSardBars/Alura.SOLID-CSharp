using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handles
{
    public class DefaultAdminService : IAdminService
    {
        ILeilaoDAO _leilaoDAO;
        ICategoriaDAO _categoriaDAO;

        public DefaultAdminService(ILeilaoDAO leilaoDAO, ICategoriaDAO categoriaDAO)
        {
            _leilaoDAO = leilaoDAO;
            _categoriaDAO = categoriaDAO;
        }
        public void CadastraLeilao(Leilao leilao)
        {
            _leilaoDAO.Incluir(leilao);
        }

        public IEnumerable<CategoriaComInfoLeilao> ConsultaCategorias()
        {
            return _categoriaDAO.BuscarCategorias();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _leilaoDAO.BuscarPorId(id);
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _leilaoDAO.BuscarLeiloes();
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            var leilao = _leilaoDAO.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _leilaoDAO.Alterar(leilao);
            }
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            var leilao = _leilaoDAO.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _leilaoDAO.Alterar(leilao);
            }
        }

        public void ModificaLeilao(Leilao leilao)
        {
            _leilaoDAO.Alterar(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                _leilaoDAO.Excluir(leilao);
            }
        }
    }
}
