namespace InclusivaJobs.Models
{
	public class Usuario
	{
		public int Id { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Senha { get; set; } = string.Empty;
		public string Role { get; set; } = "CANDIDATO";
		public bool Ativo { get; set; } = true;
		public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
	}
}