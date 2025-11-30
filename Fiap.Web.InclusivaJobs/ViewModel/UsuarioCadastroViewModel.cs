using System.ComponentModel.DataAnnotations;

namespace InclusivaJobs.ViewModels
{
	public class UsuarioCadastroViewModel
	{
		[Required(ErrorMessage = "Nome é obrigatório")]
		[StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
		public string Nome { get; set; } = string.Empty;

		[Required(ErrorMessage = "Email é obrigatório")]
		[EmailAddress(ErrorMessage = "Email inválido")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Senha é obrigatória")]
		[MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 caracteres")]
		public string Senha { get; set; } = string.Empty;

		[Required(ErrorMessage = "Confirmação de senha é obrigatória")]
		[Compare("Senha", ErrorMessage = "Senhas não conferem")]
		public string ConfirmacaoSenha { get; set; } = string.Empty;

		public string Role { get; set; } = "CANDIDATO";
	}
}