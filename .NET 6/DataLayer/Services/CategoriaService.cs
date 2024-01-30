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
                context.Categoria.Add(categoria);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var categoria = _context.Categoria.Find(id);

                _context.Categoria.Remove(categoria);
                _context.SaveChanges();
            }

        }

        public Categoria FindById(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Categoria.SingleOrDefault(x => x.ID == id);
        }

        public List<Categoria> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.Categoria.ToList();
        }

        public string nomeCategoria(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                Categoria cat = _context.Categoria.SingleOrDefault(x => x.ID == id);
                return cat.nome;
            }
        }
    }
}
