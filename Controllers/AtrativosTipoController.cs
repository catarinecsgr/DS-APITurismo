using Microsoft.AspNetCore.Mvc;
using Turismo_Catsy.Data;
using Microsoft.EntityFrameworkCore;
using Turismo_Catsy.Models;


namespace Turismo_Catsy.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AtrativosTipoController : ControllerBase
    {
        //Programação de toda a classe ficará aqui abaixo
        private readonly DataContext _context; //Declaração do atributo

        public AtrativosTipoController(DataContext context)
        {
            //Inicialização do atributo a partir de um parâmetro          
            _context = context;
        } 

        [HttpGet ("{atrativoId}")]
        public async Task<IActionResult> GetAtrativosTipos(int atrativoId)
        {
            try
            {
                List<AtrativoTipo> atLista = await _context.AtrativoTipos
                    .Include(a => a.AtrativoTuristico)
                    .Include(t => t.TipoTuristico)
                    .Where(a => a.IdAtrativo == atrativoId).ToListAsync();
                return Ok(atLista);
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
                List<TipoTuristico> lista = await _context.TipoTuristicos.ToListAsync();
                
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Consertar
       [HttpPost]
        public async Task<IActionResult> AddAtrativoTipoAsync(AtrativoTipo novoAtrativoT)
        {
            try
            {
                // Verifica se pelo menos uma das propriedades opcionais está preenchida
                if (novoAtrativoT.AtrativoTuristico == null && novoAtrativoT.TipoTuristico == null)
                {
                    return BadRequest("Informe o AtrativoTuristico ou o TipoTuristico");
                }

                // Cria uma nova instância de AtrativoTipo
                await _context.AtrativoTipos.AddAsync(novoAtrativoT);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception)
            {
                return BadRequest(); // Retorna um código de status 400 (Bad Request) se ocorrer algum erro
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