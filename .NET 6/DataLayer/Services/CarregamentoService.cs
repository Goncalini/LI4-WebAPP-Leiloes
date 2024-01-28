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
                context.carregamentos.Add(carregamento);
            }
        }

        public void Delete(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var leilao = _context.carregamentos.Find(id);

                _context.carregamentos.Remove(leilao);
                _context.SaveChanges();
            }

        }

        public Carregamento FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.carregamentos.SingleOrDefault(x => x.id == id);
        }

        public List<Carregamento> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.carregamentos.ToList();
        }
        public List<Carregamento> GetAllUser(string username)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.carregamentos.ToList().FindAll(x => x.Username == username);
        }
    }
}

