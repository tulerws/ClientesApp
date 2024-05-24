using System.ComponentModel.DataAnnotations;

namespace ClientesApp.API.DTOs.Response
{
    public class CreateClienteResponseDTO
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
    }
}
