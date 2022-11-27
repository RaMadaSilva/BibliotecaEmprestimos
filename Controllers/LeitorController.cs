using System.Threading;
using BibliotecaEmprestimos.Data;
using BibliotecaEmprestimos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaEmprestimos.Controllers
{
    [ApiController]
    [Route("v1/leitor")]
    public class LeitorController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetLeitoAsync([FromServices] MyDbContext context)
        {
            var leitores = await context.Leitores.ToListAsync();
            return Ok(leitores);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetLeitorByIdAsync([FromRoute] int id, [FromServices] MyDbContext context)
        {
            var leitor = await context.Leitores.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (leitor == null)
                return NotFound();
            return Ok(leitor);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostLeitorAsync([FromBody] Leitor leitor, [FromServices] MyDbContext context)
        {
            try
            {
                await context.Leitores.AddAsync(leitor);
                await context.SaveChangesAsync();

                return Ok("Leitor Salvo com sucesso");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> PutLeitorAsync([FromRoute] int id, [FromBody] Leitor leitor, [FromServices] MyDbContext context)
        {
            var leitorbd = await context.Leitores.FirstOrDefaultAsync(x => x.Id == id);
            if (leitorbd == null)
                return NotFound();
            leitorbd.Nome = leitor.Nome;
            leitorbd.DataNascimento = leitor.DataNascimento;
            leitorbd.Telefone = leitor.Telefone;
            leitorbd.Email = leitor.Email;

            context.Leitores.Update(leitorbd);
            await context.SaveChangesAsync();

            return Ok("leitor Actualizado com sucesso! ");
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteLeitorAsync([FromRoute] int id, [FromServices] MyDbContext context)
        {
            var leitor = await context.Leitores.FirstOrDefaultAsync(x => x.Id == id);
            if (leitor == null)
                return NotFound();
            context.Leitores.Remove(leitor);
            return Ok("Leitor Removido com sucesso!");
        }
    }
}