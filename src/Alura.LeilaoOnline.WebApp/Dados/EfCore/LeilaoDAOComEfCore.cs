using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class LeilaoDAOComEfCore : ILeilaoDAO
    {
        AppDbContext _context;

        public LeilaoDAOComEfCore()
        {
            _context = new AppDbContext();
        }
        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return _context.Leiloes.Include(l => l.Categoria).ToList();
        }
        public Leilao BuscarPorId(int id)
        {
            return _context.Leiloes.FirstOrDefault(x => x.Id == id);
        }

        public void Incluir(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void Alterar(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void Excluir(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _context.Categorias.ToList();
        }
    }
}
