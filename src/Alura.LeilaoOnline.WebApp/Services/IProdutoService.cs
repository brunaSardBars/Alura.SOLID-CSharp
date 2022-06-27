using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IProdutoService
    {
        IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao();
        Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id);
        IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo);
    }
}
