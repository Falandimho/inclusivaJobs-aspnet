using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.InclusivaJobs.Models
{
	[Table("VAGAS")]
	public class Vaga
	{
		[Key]
		[Column("ID")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column("TITULO")]
		[StringLength(100)]
		public string Titulo { get; set; } = string.Empty;

		[Column("DESCRICAO")]
		[StringLength(1000)]
		public string Descricao { get; set; } = string.Empty;

		[Required]
		[Column("EMPRESA")]
		[StringLength(100)]
		public string Empresa { get; set; } = string.Empty;

		[Column("LOCALIZACAO")]
		[StringLength(100)]
		public string Localizacao { get; set; } = string.Empty;

		[Column("SALARIO")]
		public decimal Salario { get; set; }

		[Column("OFERECE_ACESSIBILIDADE")]
		public bool OfereceAcessibilidade { get; set; }

		[Column("RECURSOS_ACESSIBILIDADE")]
		[StringLength(500)]
		public string RecursosAcessibilidade { get; set; } = string.Empty;

		[Column("VAGAS_PCD")]
		public bool VagasPCD { get; set; }

		[Column("QUANTIDADE_VAGAS_PCD")]
		public int QuantidadeVagasPCD { get; set; }

		[Column("ATIVA")]
		public bool Ativa { get; set; } = true;

		[Column("DATA_CRIACAO")]
		public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

		[Column("DATA_EXPIRACAO")]
		public DateTime DataExpiracao { get; set; }
	}
}