using ClientesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Interfaces.Services
{
    public interface IClienteDomainService
    {
        void CriarCliente(Cliente cliente);

        void EditarCliente(Cliente cliente);

        void ExcluirCliente(Guid id);

        List<Cliente> ConsultarClientes();

        Cliente? GetById(Guid id);

    }
}
