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
                    context.Leilao.Add(leilao);
                else
                    context.Leilao.Update(leilao);
                context.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var leilao = _context.Leilao.Find(id);

                _context.Leilao.Remove(leilao);
                _context.SaveChanges();
            }

        }

        public Leilao FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Leilao.SingleOrDefault(x => x.LeilãoID == id);
        }

        public List<Leilao> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Leilao.ToList();
        }

        public List<Leilao> GetAllCategoria(string nome)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Leilao.ToList().FindAll(x=>x.categoria_produto.nome == nome);
        }

        public List<Leilao> GetAllUser(string nome)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Leilao.ToList().FindAll(x => x.vendedorId == nome);
        }

    }


}

