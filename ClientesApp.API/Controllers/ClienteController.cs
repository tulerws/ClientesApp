using ClientesApp.API.DTOs.Request;
using ClientesApp.API.DTOs.Response;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ClientesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteDomainService _clienteDomainService;

        public ClienteController(IClienteDomainService clienteDomainService)
        {
            _clienteDomainService = clienteDomainService;
        }

        [HttpPost]
        [Route("criar")]
        [ProducesResponseType(typeof(CreateClienteResponseDTO), 200)]
        public IActionResult Post(CreateClienteRequestDTO dto)
        {
            try
            {
                var cliente = new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = dto.Nome,
                    Email = dto.Email,
                    Cpf = dto.Cpf,
                    DataHoraCadastro = DateTime.Now
                };

                _clienteDomainService.CriarCliente(cliente);

                var response = new CreateClienteResponseDTO
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Cpf = cliente.Cpf,
                    DataHoraCadastro = dto.DataHoraCadastro.Value
                };

                return StatusCode(201, new { message = "Cliente cadastrado com sucesso.", response });
            }
            catch(ApplicationException e)
            {
                return UnprocessableEntity(new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message } );
            }
        }

        [HttpPut]
        [Route("editar")]
        [ProducesResponseType(typeof(UpdateClienteResponseDTO), 200)]
        public IActionResult Put(UpdateClienteRequestDTO dto)
        {
            try
            {
                var cliente = new Cliente
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                    Email = dto.Email
                };

                _clienteDomainService.EditarCliente(cliente);

                var response = new UpdateClienteResponseDTO
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Cpf = cliente.Cpf
                };

                return Ok(new { message = "Cliente atualizado com sucesso." });
            }
            catch(ApplicationException e)
            {
                return UnprocessableEntity(new { e.Message });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete]
        [Route("excluir")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _clienteDomainService.ExcluirCliente(id);

                return Ok(new { message = "Cliente excluído com sucesso."});
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [Route("consultar")]
        [ProducesResponseType(typeof(List<GetClienteResponseDTO>),200)]
        public IActionResult GetAll()
        {
            try
            {
                var model = _clienteDomainService.ConsultarClientes();

                return Ok(model);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [Route("obter-por-id")]
        [ProducesResponseType(typeof(GetClienteResponseDTO), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _clienteDomainService.GetById(id);

                return Ok(response);
            }
            catch(ApplicationException e)
            {
                return NotFound(new { message = "Cliente não encontrado." });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
