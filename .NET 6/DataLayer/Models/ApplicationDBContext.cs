using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models
{
    public class ApplicationDbContext : DbContext
    {
        public string ConnectionString { get; set; }
        public DbSet<Leilao> Leilao { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Classificacao> Avaliacao { get; set; }
        public DbSet<Utilizador> Utilizador { get; set; }
        public DbSet<Carregamento> Carregamentos { get; set; }
        public DbSet<Licitacao> Licitacao { get; set; }
        public DbSet<Foto> FotoDoProduto { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            ConnectionString = "Server=LAPTOP-43KJKR4F\\SQLEXPRESS;Database=LI4DB;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString,
                providerOptions => { providerOptions.EnableRetryOnFailure(); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leilao>(entity =>
            {
                entity.HasKey(e => e.LeilãoID);
                entity.Property(e => e.tipo).IsRequired().HasColumnName("Tipo do Leilao").HasColumnType("varchar(10)");
                entity.Property(e => e.estado).IsRequired().HasColumnName("Estado").HasColumnType("varchar(10)");
                entity.Property(e => e.nome).IsRequired().HasColumnName("Nome do Produto").HasColumnType("varchar(50)");
                entity.Property(e => e.idCategoria).IsRequired().HasColumnName("Categoria do Produto").HasColumnType("int");
                entity.Property(e => e.marca).IsRequired().HasColumnName("Marca do Produto").HasColumnType("varbinary(20)");
                entity.Property(e => e.vendedorId).IsRequired().HasColumnName("Username do Vendedor").HasColumnType("varchar(50)");
                entity.Property(e => e.descricao).IsRequired().HasColumnName("Descricao").HasColumnType("text");
                entity.Property(e => e.preco_inicial).IsRequired().HasColumnName("Valor Inicial").HasColumnType("float");
                entity.Property(e => e.dataDeTermino).IsRequired().HasColumnName("Data de termino").HasColumnType("datetime");
            });

            modelBuilder.Entity<Carregamento>(entity =>
            {
                entity.HasKey(e => e.IDCarregamento);
                entity.Property(e => e.Data).IsRequired().HasColumnName("Data").HasColumnType("datetime");
                entity.Property(e => e.valor).IsRequired().HasColumnName("Valor").HasColumnType("float");
                entity.Property(e => e.Username).IsRequired().HasColumnName("Username").HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasKey(e => e.Username);
                entity.Property(e => e.nome).IsRequired().HasColumnName("Primeiro Nome").HasColumnType("varchar(50)");
                entity.Property(e => e.email).IsRequired().HasColumnName("Email").HasColumnType("varchar(30)");
                entity.Property(e => e.password).IsRequired().HasColumnName("Password").HasColumnType("varchar(30)");
                entity.Property(e => e.contacto).IsRequired().HasColumnName("Contacto Telefonico").HasColumnType("varchar(9)");
                entity.Property(e => e.morada).IsRequired().HasColumnName("Morada").HasColumnType("varchar(50)");
                entity.Property(e => e.valor).IsRequired().HasColumnName("Saldo").HasColumnType("float");
                entity.Property(e => e.saldo_fantasma).IsRequired().HasColumnName("Saldo Fantasma").HasColumnType("float");
            });

            modelBuilder.Entity<Licitacao>(entity =>
            {
                entity.HasKey(e => e.LicitaçãoID);
                entity.Property(e => e.tempo).IsRequired().HasColumnName("Tempo").HasColumnType("datetime");
                entity.Property(e => e.valor).IsRequired().HasColumnName("Valor").HasColumnType("float");
                entity.Property(e => e.userUsername).IsRequired().HasColumnName("UserUsername").HasColumnType("varchar(50)");
                entity.Property(e => e.iDLeilao).IsRequired().HasColumnName("IDLeilão").HasColumnType("int");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.nome).IsRequired().HasColumnName("Nome").HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.HasKey(e => e.IDLeilão);
                entity.Property(e => e.FotoPath).IsRequired().HasColumnName("Foto").HasColumnType("image");
            });

            modelBuilder.Entity<Classificacao>(entity =>
            {
                entity.HasKey(e => e.AvaliaçãoID);
                entity.Property(e => e.usernameCliente).IsRequired().HasColumnName("UsernameClient").HasColumnType("varchar(50)");
                entity.Property(e => e.usernameUser).IsRequired().HasColumnName("UsernameUser").HasColumnType("varchar(50)");
                entity.Property(e => e.aval).IsRequired().HasColumnName("Avaliacao").HasColumnType("int");
                entity.Property(e => e.comentario).HasColumnName("Comentario").HasColumnType("text");
            });

            base.OnModelCreating(modelBuilder);
        }


    }

}
