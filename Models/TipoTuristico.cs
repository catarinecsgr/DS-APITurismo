using Microsoft.EntityFrameworkCore;

namespace Turismo_Catsy.Models
{
    [PrimaryKey(nameof(IdTipo))]
    public class TipoTuristico
    {
        public int IdTipo { get; set; }
        public string Segmento { get; set; }

    }

}