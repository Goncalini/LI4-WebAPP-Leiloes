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
                    context.Licitacao.Add(licitacao);
                else
                    context.Licitacao.Update(licitacao);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var leilao = _context.Licitacao.Find(id);

                _context.Licitacao.Remove(leilao);
                _context.SaveChanges();
            }

        }

        public Licitacao FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Licitacao.SingleOrDefault(x => x.LicitaçãoID == id);
        }

        public List<Licitacao> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Licitacao.ToList();
        }

        public double GetLicitacaoRecente(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                List<Licitacao> lista = _context.Licitacao.ToList();
                List<Licitacao> licitacoesLeilao = new List<Licitacao>(lista.FindAll(x => x.iDLeilao == id));
                Licitacao first = licitacoesLeilao.OrderBy(x => x.tempo).FirstOrDefault();
                if(first != null) {
                    return first.valor;
                }
                return 0;
            }
        }

    }
}
