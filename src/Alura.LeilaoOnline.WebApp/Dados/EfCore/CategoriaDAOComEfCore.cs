using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class CategoriaDAOComEfCore : ICategoriaDAO
    {
        AppDbContext _context;

        public CategoriaDAOComEfCore()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<CategoriaComInfoLeilao> BuscarCategorias()
        {
           return  _context.Categorias
                    .Include(c => c.Leiloes)
                    .Select(c => new CategoriaComInfoLeilao
                    {
                        Id = c.Id,
                        Descricao = c.Descricao,
                        Imagem = c.Imagem,
                        EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                        EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                        Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
                    });
        }

        public Categoria BuscarPorId(int id)
        {
            return _context.Categorias
                   .Include(c => c.Leiloes)
                   .First(c => c.Id == id);
        }
    }
}
