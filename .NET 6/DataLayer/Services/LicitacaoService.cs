using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services
{
    public class LicitacaoService
    {
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public LicitacaoService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddLicitacao(Licitacao licitacao)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.licitacoes.Add(licitacao);
            }
        }

        public void Delete(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var leilao = _context.licitacoes.Find(id);

                _context.licitacoes.Remove(leilao);
                _context.SaveChanges();
            }

        }

        public Licitacao FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.licitacoes.SingleOrDefault(x => x.numero == id);
        }

        public List<Licitacao> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.licitacoes.ToList();
        }
    }
}
