using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Services
{
    public class UtilizadorService
    {

        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public UtilizadorService(IDbContextFactory<ApplicationDbContext> context)
        {
            _dbContextFactory = context;
        }

        public void AddUpdate(Utilizador utilizador)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                string id = utilizador.Username;
                Utilizador user = FindById(id);
                if (user == null)
                    _context.Utilizador.Add(utilizador);
                else
                    _context.Utilizador.Update(utilizador);
                _context.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var utilizador = _context.Utilizador.Find(id);

                _context.Utilizador.Remove(utilizador);
                _context.SaveChanges();
            }

        }

        public Utilizador FindById(string id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Utilizador.SingleOrDefault(x => x.Username == id);
        }

        public List<Utilizador> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Utilizador.ToList();
        }
    }
}
