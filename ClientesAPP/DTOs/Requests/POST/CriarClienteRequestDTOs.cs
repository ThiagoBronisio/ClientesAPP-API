using System.ComponentModel.DataAnnotations;

namespace ClientesAPP.DTOs.Requests.POST
{
    public class CriarClienteRequestDTOs
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um e-mail válido.")]
        [Required(ErrorMessage = "Por favor, informe o e-mail do cliente.")]
        public string? Email { get; set; }

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato 000.000.000-00")]
        [Required(ErrorMessage = "Por favor, informe o CPF do cliente.")]
        public string? Cpf { get; set; }
    }
}
