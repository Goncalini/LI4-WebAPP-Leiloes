using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataLayer.Services
{
    public class LeilaoService
    {
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public LeilaoService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddLeilao(Leilao leilao)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                int id = leilao.LeilãoID;
                Leilao lei = FindById(id);
                if (lei == null)
                    context.Leilão.Add(leilao);
                else
                    context.Leilão.Update(leilao);
                context.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var leilao = _context.Leilão.Find(id);

                _context.Leilão.Remove(leilao);
                _context.SaveChanges();
            }

        }

        public Leilao FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Leilão.SingleOrDefault(x => x.LeilãoID == id);
        }

        public List<Leilao> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Leilão.ToList();
        }

        public List<Leilao> GetAllCategoria(string nome)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Leilão.ToList().FindAll(x=>x.categoria_produto.nome == nome);
        }
    }


}

