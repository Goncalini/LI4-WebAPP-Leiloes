using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services
{
    public class CategoriaService
    {
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public CategoriaService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddCategoria(Categoria categoria)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.carregamentos.Add(categoria);
            }
        }

        public void Delete(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var categoria = _context.categorias.Find(id);

                _context.categorias.Remove(categoria);
                _context.SaveChanges();
            }

        }

        public Categoria FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.categorias.SingleOrDefault(x => x.id == id);
        }

        public List<Categoria> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.categorias.ToList();
        }
     }
}
