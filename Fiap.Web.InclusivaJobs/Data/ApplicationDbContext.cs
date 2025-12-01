using Fiap.Web.InclusivaJobs.Models;
using InclusivaJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.InclusivaJobs.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Vaga> Vagas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configuração específica para Oracle
			modelBuilder.HasDefaultSchema("INCLUSIVAJOBS");

			modelBuilder.Entity<Vaga>(entity =>
			{
				entity.ToTable("VAGAS");

				entity.HasKey(e => e.Id);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Titulo)
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnName("TITULO");

				entity.Property(e => e.Descricao)
					.HasMaxLength(1000)
					.HasColumnName("DESCRICAO");

				entity.Property(e => e.Empresa)
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnName("EMPRESA");

				entity.Property(e => e.Localizacao)
					.HasMaxLength(100)
					.HasColumnName("LOCALIZACAO");

				entity.Property(e => e.Salario)
					.HasColumnType("NUMBER(18,2)")
					.HasColumnName("SALARIO");

				entity.Property(e => e.OfereceAcessibilidade)
					.HasColumnName("OFERECE_ACESSIBILIDADE");

				entity.Property(e => e.RecursosAcessibilidade)
					.HasMaxLength(500)
					.HasColumnName("RECURSOS_ACESSIBILIDADE");

				entity.Property(e => e.VagasPCD)
					.HasColumnName("VAGAS_PCD");

				entity.Property(e => e.QuantidadeVagasPCD)
					.HasColumnName("QUANTIDADE_VAGAS_PCD");

				entity.Property(e => e.Ativa)
					.HasColumnName("ATIVA");

				entity.Property(e => e.DataCriacao)
					.HasColumnType("TIMESTAMP")
					.HasColumnName("DATA_CRIACAO");

				entity.Property(e => e.DataExpiracao)
					.HasColumnType("TIMESTAMP")
					.HasColumnName("DATA_EXPIRACAO");

				// Índices
				entity.HasIndex(e => e.Ativa)
					.HasDatabaseName("IDX_VAGAS_ATIVA");

				entity.HasIndex(e => e.DataExpiracao)
					.HasDatabaseName("IDX_VAGAS_DATA_EXP");

				entity.HasIndex(e => e.VagasPCD)
					.HasDatabaseName("IDX_VAGAS_PCD");
			});

			modelBuilder.HasSequence<int>("VAGAS_SEQ")
				.StartsAt(1)
				.IncrementsBy(1);
		}
	}
}