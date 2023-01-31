using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using desafio_api_payment.Context;
using desafio_api_payment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace desafio_api_payment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
      private OrganizadorContext _context { get; set; }

        public VendaController(OrganizadorContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult RegistrarVenda(Venda venda)
        {

            venda.Status = "Aguardando pagamento";
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Created("Venda registrada", venda);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarVenda(int id)
        {
            var venda = _context.Vendas.Find(id);

            if (venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarVenda(int id, Venda venda)
        {
            var vendaBanco = _context.Vendas.Find(venda.Id);

            if (vendaBanco == null)
                return NotFound();

            vendaBanco.Status = venda.Status;
            
            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();
            return Ok();
        }
    }
}