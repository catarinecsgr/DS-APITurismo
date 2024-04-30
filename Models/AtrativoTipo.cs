using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Turismo_Catsy.Models
{
    public class AtrativoTipo
    {
        [Key, Column(Order = 0)]
        [ForeignKey("IdAtrativo")]
        public int IdAtrativo { get; set; }
        [JsonIgnore]
        public AtrativoTuristico? AtrativoTuristico { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("TipoTuristico")]
        public int IdTipo { get; set; }
        [JsonIgnore]
        public TipoTuristico? TipoTuristico { get; set; }
    }
}
