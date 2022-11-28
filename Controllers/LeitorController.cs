using BibliotecaEmprestimos.Data;
using BibliotecaEmprestimos.Extencions;
using BibliotecaEmprestimos.Models;
using BibliotecaEmprestimos.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaEmprestimos.Controllers
{
    [ApiController]
    [Route("v1/leitor")]
    public class LeitorController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetLeitoAsync([FromServices] MyDbContext context)
        {
            try
            {

                var leitores = await context.Leitores.AsNoTracking().ToListAsync();
                return Ok(new ResultViewModel<List<Leitor>>(leitores));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Leitor>($"erro na ao buscar os leitores {ex.Message}"));
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetLeitorByIdAsync([FromRoute] int id, [FromServices] MyDbContext context)
        {
            try
            {
                var leitor = await context.Leitores.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (leitor == null)
                    return NotFound(new ResultViewModel<Leitor>("Leitor não encontrado!"));

                var model = new LeitorViewModel()
                {
                    Nome = leitor.Nome,
                    DataNascimento = leitor.DataNascimento,
                    Email = leitor.Email
                };
                return Ok(new ResultViewModel<Leitor>(leitor));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Leitor>($"erro ao pegar um leitor pelo Id {ex.Message}"));
            }

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostLeitorAsync([FromBody] LeitorViewModel model, [FromServices] MyDbContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Leitor>(ModelState.GetError()));

            try
            {
                var leitor = new Leitor()
                {
                    Nome = model.Nome,
                    DataNascimento = model.DataNascimento,
                    Telefone = model.Telefone,
                    Email = model.Email,
                };

                await context.Leitores.AddAsync(leitor);
                await context.SaveChangesAsync();

                return Created($"v1/leitor/{leitor.Id}", new ResultViewModel<Leitor>(leitor));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Leitor>($"Erros ao criar o Leitor: {ex.Message}"));
            }

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> PutLeitorAsync([FromRoute] int id, [FromBody] LeitorViewModel model, [FromServices] MyDbContext context)
        {
            try
            {
                var leitor = await context.Leitores.FirstOrDefaultAsync(x => x.Id == id);
                if (leitor == null)
                    return NotFound();

                leitor.Nome = model.Nome;
                leitor.DataNascimento = model.DataNascimento;
                leitor.Telefone = model.Telefone;
                leitor.Email = model.Email;

                context.Leitores.Update(leitor);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Leitor>(leitor));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Leitor>($"Erro ao Actualizar o leitor {ex.Message}"));
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteLeitorAsync([FromRoute] int id, [FromServices] MyDbContext context)
        {
            try
            {
                var leitor = await context.Leitores.FirstOrDefaultAsync(x => x.Id == id);
                if (leitor == null)
                    return NotFound();
                context.Leitores.Remove(leitor);
                await context.SaveChangesAsync();
                return Ok(new ResultViewModel<Leitor>(leitor, "Leitor Removido com sucesso!"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Leitor>($"erro ao Apagar um leitor {ex.Message}"));
            }
        }
    }
}