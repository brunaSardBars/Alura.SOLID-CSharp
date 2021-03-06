using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDAO
    {
        IEnumerable<Leilao> BuscarPorTemo(string termo);
        IEnumerable<Leilao> BuscarLeiloes();
        Leilao BuscarPorId(int id);

        void Incluir(Leilao leilao);

        void Alterar(Leilao leilao);

        void Excluir(Leilao leilao);

    }
}
