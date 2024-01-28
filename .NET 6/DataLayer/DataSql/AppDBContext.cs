using Microsoft.EntityFrameworkCore;

namespace EFCoreBasics.Data
{
	public class AppDBContext: DBContext
	{
		public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Classificacao> Classificaçoes { get; set; }

        public DbSet<Leilao> Leiloes { get; set; }

        public DbSet<Licitacao> Licitacoes { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Saldo> Saldos { get; set; }

        public DbSet<Utilizador> Utilizadores { get; set; }

        public string ConnectionString { get; }

        public AppDbContext()
        {
            ConnectionString = "Data Source=(localdb)\\MSSqlLocalDB;Initial Catalog=EmployeeMngt_EFCorePractice;Integrated Security=True";
        }

        protected override void OnConfiguration(DbContextOptionBuilder optionBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}