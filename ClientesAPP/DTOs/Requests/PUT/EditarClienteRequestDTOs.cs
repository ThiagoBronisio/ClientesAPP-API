using System.ComponentModel.DataAnnotations;

namespace ClientesAPP.DTOs.Requests.PUT
{
    public class EditarClienteRequestDTOs
    {
        [Required(ErrorMessage = "Por favor, informe o id da tarefa.")]
        public Guid Id { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe o nome com pelo menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe o nome com no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome da tarefa.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um e-mail válido.")]
        [Required(ErrorMessage = "Por favor, informe o e-mail do cliente.")]
        public string? Email { get; set; }

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato 000.000.000-00")]
        [Required(ErrorMessage = "Por favor, informe o CPF do cliente.")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data e hora da tarefa.")]
        public DateTime? DataHoraCadastro { get; set; }
    }
}
