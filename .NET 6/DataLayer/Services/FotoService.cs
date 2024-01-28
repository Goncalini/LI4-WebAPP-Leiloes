using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services
{
    public class FotoService
    {
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public FotoService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddFoto(Foto foto)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.fotos.Add(foto);
            }
        }

        public void Delete(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var foto = _context.fotos.Find(id);

                _context.fotos.Remove(foto);
                _context.SaveChanges();
            }

        }

        public Foto FindById(string path)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.fotos.SingleOrDefault(x => x.fotoPath == path);
        }

        public List<Foto> GetAll()
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.fotos.ToList();
        }

        public List<Foto> GetAll(int id)
        {
            using (var _context = _dbContextFactory.CreateDbContext())
                return _context.fotos.ToList().FindAll( x => x.idLeilao == id);
        }
    }
}
