using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesAPP.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesAPP.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void AddCliente(Cliente cliente)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(cliente);
                dataContext.SaveChanges();
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(cliente);
                dataContext.SaveChanges();
            }
        }

        public void DeleteCliente(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                var cliente = dataContext.Set<Cliente>().Find(id);
                if(cliente != null)
                {
                    dataContext.Remove(cliente);
                    dataContext.SaveChanges();
                }
            }
        }

        public List<Cliente?> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Cliente?>().ToList();
            }
        }

        public Cliente? GetById(Guid id)
        {
           using (var dataContext = new DataContext())
            {
                return dataContext.Set<Cliente>().Find(id);
            }
        }

        public Cliente? GetClienteByCpf(string cpf)
        {
            using (var dataContext = new DataContext())
            {
               return dataContext.Set<Cliente>()
                    .Where(c => c.Cpf.Equals(cpf))
                    .FirstOrDefault();
            }
        }
    }
}
