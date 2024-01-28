using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp1.Models;
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
                context.leiloes.Add(leilao);
            }
        }

        public void Delete(string id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var leilao = _context.leiloes.Find(id);

                _context.leiloes.Remove(leilao);
                _context.SaveChanges();
            }

        }

        public Leilao FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.leiloes.SingleOrDefault(x => x.id == id);
        }

        public List<Leilao> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.leiloes.ToList();
        }

        public List<Leilao> GetAllCategoria(string nome)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.leiloes.ToList().FindAll(x=>x.produto.categoria_produto.nome == nome);
        }
    }


}

