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
                int id = classi.AvaliaçãoID;
                Classificacao lei = FindById(id);
                if (lei == null)
                    context.Avaliação.Add(classi);
                else
                    context.Avaliação.Update(classi);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var classi = _context.Avaliação.Find(id);

                _context.Avaliação.Remove(classi);
                _context.SaveChanges();
            }

        }

        public Classificacao FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Avaliação.SingleOrDefault(x => x.AvaliaçãoID == id);
        }

        public List<Classificacao> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Avaliação.ToList();
        }

        public float GetMediaUser(string username)
        {

            var all = new List<Classificacao>();
            var sum = 0;
            using (var _context = _dbContextFactory.CreateDbContext())
                all = _context.Avaliação.ToList().FindAll(x => x.usernameUser == username);

            foreach (Classificacao item in all)
            {
                sum += item.aval;
            }

            return sum / all.Count();
        }
    }
}
