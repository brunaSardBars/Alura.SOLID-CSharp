using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handles
{
    public class DefaultProdutoService : IProdutoService
    {
        ILeilaoDAO _leilaoDAO;
        ICategoriaDAO _categoriaDAO;

        public DefaultProdutoService(ILeilaoDAO leilaoDAO, ICategoriaDAO categoriaDAO)
        {
            _leilaoDAO = leilaoDAO;
            _categoriaDAO = categoriaDAO;
        }

        public Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id)
        {
            return _categoriaDAO.BuscarPorId(id);
        }

        public IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao()
        {
            return _categoriaDAO.BuscarCategorias();
        }

        public IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo)
        {
            return _leilaoDAO.BuscarPorTemo(termo);
        }
    }
}
