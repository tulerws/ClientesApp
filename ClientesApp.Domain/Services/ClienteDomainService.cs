using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Services
{
    public class ClienteDomainService : IClienteDomainService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void CriarCliente(Cliente cliente)
        {
            if (_clienteRepository.GetByCpf(cliente.Cpf) != null)
            {
                throw new ApplicationException("O CPF informado já está cadastrado.");
            }

            _clienteRepository.Add(cliente);
        }

        public void EditarCliente(Cliente cliente)
        {
            var clienteEdicao = _clienteRepository.GetById(cliente.Id);

            if (clienteEdicao == null)
            {
                throw new ApplicationException("Cliente não encontrado.");
            }

            clienteEdicao.Nome = cliente.Nome;
            clienteEdicao.Email = cliente.Email;

            _clienteRepository.Update(clienteEdicao);
        }

        public void ExcluirCliente(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente != null)
            {
                _clienteRepository.Delete(cliente);
            }
        }

        public List<Cliente> ConsultarClientes()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente? GetById(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente != null)
                return cliente;
            else
                throw new ApplicationException("Cliente não encontrado.");
        }
    }
}
