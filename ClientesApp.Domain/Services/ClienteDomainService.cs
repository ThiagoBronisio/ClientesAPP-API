using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddCliente(Cliente cliente)
        {
            if(_clienteRepository.GetClienteByCpf(cliente.Cpf) != null)
            {
                throw new ApplicationException("O CPF informado já existe em nosso sitema, tente outro.");
            }
            cliente.Id = Guid.NewGuid();
            cliente.DataHoraCadastro = DateTime.Now;

            _clienteRepository.AddCliente(cliente);
        }

        public Cliente GetClienteByCpf(string cpf)
        {
            return _clienteRepository.GetClienteByCpf(cpf);
        }

        public void UpdateCliente(Cliente cliente)
        {
            var existeCliente = _clienteRepository.GetById(cliente.Id);
            if(existeCliente == null)
            {
                throw new ApplicationException("Cliente não encontrado.");

            } else if (_clienteRepository.GetClienteByCpf(cliente.Cpf) != null){

                throw new ApplicationException("Esté CPF já está cadastrado.");
            }
            existeCliente.Nome = cliente.Nome;
            existeCliente.Email = cliente.Email;
            existeCliente.Cpf = cliente.Cpf;
            _clienteRepository.UpdateCliente(existeCliente);
        }

        public void DeleteCliente(Guid id)
        {
            var existeCliente = _clienteRepository.GetById(id);
            if (existeCliente == null)
            {
                throw new ApplicationException("Cliente não encontrado.");
            }
            _clienteRepository.DeleteCliente(id);
        }

        public List<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente GetById(Guid id)
        {
            return _clienteRepository.GetById(id);
        }
    }
}
