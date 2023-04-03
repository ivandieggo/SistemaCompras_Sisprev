using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Infra.Data.Produto;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions options) : base(options) { }
        public DbSet<ProdutoAgg.Produto> Produtos { get; set; }
        public DbSet<SolicitacaoAgg.SolicitacaoCompra> SolicitacaoCompras { get; set; }
        public DbSet<SolicitacaoAgg.Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoAgg.Produto>()
                .HasData(
                    new ProdutoAgg.Produto("Produto01", "Descricao01", "Madeira", 100)
                );


            //modelBuilder.Entity<SolicitacaoAgg.SolicitacaoCompra>()
            //    .OwnsOne(x => x.TotalGeral);

            modelBuilder.Entity<Money>()
                .HasNoKey();

            modelBuilder.Entity<CondicaoPagamento>()
                .HasNoKey();

            modelBuilder.Entity<NomeFornecedor>()
                .HasNoKey();

            modelBuilder.Entity<UsuarioSolicitante>()
                .HasNoKey();

            modelBuilder.Ignore<Event>();   
            modelBuilder.Ignore<CondicaoPagamento>();   
            modelBuilder.Ignore<NomeFornecedor>();   
            modelBuilder.Ignore<UsuarioSolicitante>();   

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=DESKTOP-HT1H0C4\SQLEXPRESS;Database=SistemaCompraDb;Trusted_Connection=True;MultipleActiveResultSets=true");
                //.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=SistemaCompraDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
