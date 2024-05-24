using System.ComponentModel.DataAnnotations;

namespace ClientesApp.API.DTOs.Request
{
    public class UpdateClienteRequestDTO
    {
        public Guid Id { get; set; } 

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe um nome.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe um email.")]
        public string? Email { get; set; }
    }
}
