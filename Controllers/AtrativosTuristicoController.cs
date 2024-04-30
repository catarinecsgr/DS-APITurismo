using Microsoft.AspNetCore.Mvc;
using Turismo_Catsy.Data;
using Microsoft.EntityFrameworkCore;
using Turismo_Catsy.Models;


namespace Turismo_Catsy.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AtrativosTuristicoController : ControllerBase
    {
        //Programação de toda a classe ficará aqui abaixo
        private readonly DataContext _context; //Declaração do atributo

        public AtrativosTuristicoController(DataContext context)
        {
            //Inicialização do atributo a partir de um parâmetro          
            _context = context;
        } 

        [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                AtrativoTuristico a = await _context.AtrativoTuristicos
                    .Include(at => at.AtrativoTipos)
                        .ThenInclude(at => at.TipoTuristico)
                    .FirstOrDefaultAsync(aBusca => aBusca.IdAtrativo == id);

                return Ok(a);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<AtrativoTuristico> lista = await _context.AtrativoTuristicos
                .Include(a => a.AtrativoTipos)
                    .ThenInclude(at => at.TipoTuristico)
                .ToListAsync();
                
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Incluir novo atrativo
        [HttpPost]
        public async Task<IActionResult> Add(AtrativoTuristico novoAtrativo)
        {
            try
            {
                await _context.AtrativoTuristicos.AddAsync(novoAtrativo);
                await _context.SaveChangesAsync();

                return Ok(novoAtrativo.IdAtrativo);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                AtrativoTuristico aRemover = await _context.AtrativoTuristicos.FirstOrDefaultAsync(p => p.IdAtrativo == id);

                _context.AtrativoTuristicos.Remove(aRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}