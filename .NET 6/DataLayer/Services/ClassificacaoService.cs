using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DataLayer.Services
{
    public class ClassificacaoService
    {
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public ClassificacaoService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddClassificacao(Classificacao classi)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.classificacoes.Add(classi);
            }
        }

        public void Delete(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var classi = _context.classificacoes.Find(id);

                _context.classificacoes.Remove(classi);
                _context.SaveChanges();
            }

        }

        public Classificacao FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.classificacoes.SingleOrDefault(x => x.avaliacaoId == id);
        }

        public List<Classificacao> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.classificacoes.ToList();
        }

        public float GetMediaUser(string username)
        {

            var all = new List<Classificacao>();
            var sum = 0;
            using (var _context = _dbContextFactory.CreateDbContext())
                all = _context.classificacoes.ToList().FindAll(x => x.usernameUser == username);

            foreach (Classificacao item in all)
            {
                sum += item.aval;
            }

            return sum / all.Count();
        }
    }
}
