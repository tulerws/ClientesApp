using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void Add(Cliente cliente)
        {
            using (var context = new DataContext())
            {
                context.Add(cliente);
                context.SaveChanges();
            }
        }

        public void Update(Cliente cliente)
        {
            using (var context = new DataContext())
            {
                context.Update(cliente);
                context.SaveChanges();
            }
        }

        public void Delete(Cliente cliente)
        {
            using (var context = new DataContext())
            {
                context.Remove(cliente);
                context.SaveChanges();
            }
        }

        public List<Cliente> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<Cliente>().ToList();
            }
        }

        public Cliente? GetById(Guid id)
        {
            using (var context = new DataContext())
            {
                return context.Set<Cliente>().Find(id);
            }
        }

        
        public Cliente? GetByCpf(string cpf)
        {
            using (var context = new DataContext())
            {
                return context.Set<Cliente>()
                    .Where(c => c.Cpf.Equals(cpf))
                    .FirstOrDefault();
            }
        }
        
    }
}
