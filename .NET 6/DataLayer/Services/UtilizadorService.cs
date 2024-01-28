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
                string id = utilizador.usernameId;
                Utilizador user = FindById(id);
                if (user == null)
                    _context.utilizadores.Add(utilizador);
                else
                    _context.utilizadores.Update(utilizador);
                _context.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var utilizador = _context.utilizadores.Find(id);

                _context.utilizadores.Remove(utilizador);
                _context.SaveChanges();
            }

        }

        public Utilizador FindById(string id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.utilizadores.SingleOrDefault(x => x.usernameId == id);
        }

        public List<Utilizador> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.utilizadores.ToList();
        }
    }
}
