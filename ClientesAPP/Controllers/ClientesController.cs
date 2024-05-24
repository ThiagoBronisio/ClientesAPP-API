using Azure;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Interfaces.Services;
using ClientesAPP.DTOs.Requests.POST;
using ClientesAPP.DTOs.Requests.PUT;
using ClientesAPP.DTOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteDomainService _clienteDomainService;

        public ClientesController(IClienteDomainService clienteDomainService)
        {
            _clienteDomainService = clienteDomainService;
        }

        [HttpPost]
        [Route("addCliente")]
        [ProducesResponseType(typeof(CriarClienteResponseDTOs), 201)]
        public IActionResult AddCliente(CriarClienteRequestDTOs dto)
        {
            try
            {
                var cliente = new Cliente
                {
                    Nome = dto.Nome,
                    Email = dto.Email,
                    Cpf = dto.Cpf,
                };

                _clienteDomainService.AddCliente(cliente);

                var response = new CriarClienteResponseDTOs
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    Email = cliente.Email,
                    DataHoraCadastro = cliente.DataHoraCadastro.Value
                };

                return StatusCode(201, new { message = "Conta de usuário criado com sucesso", response });
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new {e.Message});
            }
            catch(Exception e)
            {
                return StatusCode(500, new {e.Message});
            }
        }

        [HttpPut]
        [Route("editarCliente")]
        [ProducesResponseType(typeof(EditarClienteResponseDTOs), 200)]
        public IActionResult EditarCliente(EditarClienteRequestDTOs dto)
        {
            try
            {
                var cliente = _clienteDomainService.GetById(dto.Id);
                if (cliente != null)
                {
                    cliente.Nome = dto.Nome;
                    cliente.Email = dto.Email;
                    cliente.Cpf = dto.Cpf;
 
                    _clienteDomainService.UpdateCliente(cliente);

                    var response = new EditarClienteResponseDTOs
                    {
                        Id = cliente.Id,
                        Nome = cliente.Nome,
                        Email = cliente.Email,
                        Cpf = cliente.Cpf,
                        DataHoraCadastro = cliente.DataHoraCadastro.Value
                    };

                    return StatusCode(200, new { message = "Cliente atualizado com sucesso", response });
                }
                else
                {
                    return NotFound("Cliente não encontrado");
                }
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExcluirClienteResponseDTOs), 200)]
        public IActionResult ExcluirCliente(Guid id)
        {
            try
            {
                _clienteDomainService.DeleteCliente(id);
                return StatusCode(200, (new { message = "Cliente deletado com sucesso." }));
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ConsultarClientesResponseDTOs>), 200)]
        public IActionResult ConsultarCliente()
        {
            var clientes = _clienteDomainService.GetAll();

            return StatusCode(201, clientes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConsultarClientesResponseDTOs), 200)]
        public IActionResult ObterClientePorId(Guid id)
        {
           var cliente = _clienteDomainService.GetById(id);
            if(cliente == null)
            {
                return NotFound();
            }
            return StatusCode(200, cliente);
        }
    }
}
