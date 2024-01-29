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
                int id = licitacao.LicitaçãoID;
                Licitacao licit = FindById(id);
                if (licit == null)
                    context.Licitação.Add(licitacao);
                else
                    context.Licitação.Update(licitacao);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var leilao = _context.Licitação.Find(id);

                _context.Licitação.Remove(leilao);
                _context.SaveChanges();
            }

        }

        public Licitacao FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Licitação.SingleOrDefault(x => x.LicitaçãoID == id);
        }

        public List<Licitacao> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Licitação.ToList();
        }
    }
}
