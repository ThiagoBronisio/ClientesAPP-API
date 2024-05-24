using ClientesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        void AddCliente(Cliente cliente);
        Cliente GetClienteByCpf(string cpf);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(Guid id);
        List<Cliente> GetAll();
        Cliente GetById(Guid id);
    }
}
