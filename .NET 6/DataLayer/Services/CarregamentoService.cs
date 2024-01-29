using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services
{
    public class CarregamentoService
    {
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public CarregamentoService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddCarregamento(Carregamento carregamento)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Carregamentos.Add(carregamento);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var leilao = _context.Carregamentos.Find(id);

                _context.Carregamentos.Remove(leilao);
                _context.SaveChanges();
            }

        }

        public Carregamento FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Carregamentos.SingleOrDefault(x => x.IDCarregamento == id);
        }

        public List<Carregamento> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Carregamentos.ToList();
        }
        public List<Carregamento> GetAllUser(string username)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Carregamentos.ToList().FindAll(x => x.Username == username);
        }
    }
}

