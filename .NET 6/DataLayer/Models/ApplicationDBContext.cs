using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models
{
    public class ApplicationDbContext : DbContext
    {
        public string ConnectionString { get; set; }
        public DbSet<Leilao> leiloes { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Classificacao> classificacoes { get; set; }
        public DbSet<Utilizador> utilizadores { get; set; }
        public DbSet<Carregamento> carregamentos { get; set; }
        public DbSet<Licitacao> licitacoes { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Foto> fotos { get; set; }
        //public DbSet<Saldo> saldos { get; set; }

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
                entity.HasKey(e => e.id);
                entity.Property(e => e.tipo).IsRequired().HasColumnName("Tipo do Leilão").HasColumnType("varchar(10)");
                entity.Property(e => e.produto.estado).IsRequired().HasColumnName("Estado").HasColumnType("varchar(10)");
                entity.Property(e => e.produto.nome).IsRequired().HasColumnName("Nome do Produto").HasColumnType("varchar(50)");
                entity.Property(e => e.produto.categoria_produto).IsRequired().HasColumnName("Categoria do Produto").HasColumnType("varchar(50)");
                entity.Property(e => e.produto.marca).IsRequired().HasColumnName("Marca do Produto").HasColumnType("varbinary(20)");
                entity.Property(e => e.vendedorId).IsRequired().HasColumnName("Username do Vendedor").HasColumnType("varchar(50)");
                entity.Property(e => e.produto.descricao).IsRequired().HasColumnName("Descrição").HasColumnType("text");
                entity.Property(e => e.tempo_limite).IsRequired().HasColumnName("TempoLimite").HasColumnType("time(7)");
                entity.Property(e => e.preco_inicial).IsRequired().HasColumnName("Valor Inicial").HasColumnType("float");
                entity.Property(e => e.dataDeTermino).IsRequired().HasColumnName("Data de termino").HasColumnType("datetime");
            });

            modelBuilder.Entity<Carregamento>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.Data).IsRequired().HasColumnName("Data").HasColumnType("datetime");
                entity.Property(e => e.valor).IsRequired().HasColumnName("Valor").HasColumnType("float");
                entity.Property(e => e.utilizador.usernameId).IsRequired().HasColumnName("Username").HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasKey(e => e.usernameId);
                entity.Property(e => e.primeiroNome).IsRequired().HasColumnName("Primeiro Nome").HasColumnType("varchar(50)");
                entity.Property(e => e.segundoNome).IsRequired().HasColumnName("Segundo Nome").HasColumnType("varchar(50)");
                entity.Property(e => e.email).IsRequired().HasColumnName("Email").HasColumnType("varchar(30)");
                entity.Property(e => e.password).IsRequired().HasColumnName("Password").HasColumnType("varchar(30)");
                entity.Property(e => e.contacto).IsRequired().HasColumnName("Contacto Telefonico").HasColumnType("varchar(9)");
                entity.Property(e => e.morada).IsRequired().HasColumnName("Morada").HasColumnType("varchar(50)");
                entity.Property(e => e.saldo.valor).IsRequired().HasColumnName("Saldo").HasColumnType("float");
                entity.Property(e => e.saldo.saldo_fantasma).IsRequired().HasColumnName("Saldo Fantasma").HasColumnType("float");
            });

            modelBuilder.Entity<Licitacao>(entity =>
            {
                entity.HasKey(e => e.numero);
                entity.Property(e => e.tempo).IsRequired().HasColumnName("Tempo").HasColumnType("datetime");
                entity.Property(e => e.valor).IsRequired().HasColumnName("Valor").HasColumnType("float");
                entity.Property(e => e.cliente.usernameId).IsRequired().HasColumnName("UserUsername").HasColumnType("varchar(50)");
                entity.Property(e => e.leilao.id).IsRequired().HasColumnName("IDLeilão").HasColumnType("int");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.nome).IsRequired().HasColumnName("Nome").HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.HasKey(e => e.leilao.id);
                entity.Property(e => e.fotoPath).IsRequired().HasColumnName("Foto").HasColumnType("image");
            });

            modelBuilder.Entity<Classificacao>(entity =>
            {
                entity.HasKey(e => e.avaliacaoId);
                entity.Property(e => e.usernameCliente).IsRequired().HasColumnName("Primeiro Nome").HasColumnType("varchar(50)");
                entity.Property(e => e.usernameUser).IsRequired().HasColumnName("Segundo Nome").HasColumnType("varchar(50)");
                entity.Property(e => e.aval).IsRequired().HasColumnName("Email").HasColumnType("int");
                entity.Property(e => e.comentario).IsRequired().HasColumnName("Password").HasColumnType("text");

            });

            base.OnModelCreating(modelBuilder);
        }


    }

}
