using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ICategoriaDAO
    {
        IEnumerable<CategoriaComInfoLeilao> BuscarCategorias();

        Categoria BuscarPorId(int id);
    }
}
