using Microsoft.EntityFrameworkCore;

namespace Turismo_Catsy.Models
{
  
    [PrimaryKey(nameof(IdAtrativo))]
    public class AtrativoTuristico
    {
      public int IdAtrativo { get; set; }
      public string Nome { get; set; }
      public string Endereco { get; set; }
      public byte[]? Foto { get; set; }
      public string Gratuidade { get; set; }
      public string? DiaGratuidade { get; set; }
      public RegiaoEnum Regiao { get; set; }
      public List<AtrativoTipo> AtrativoTipos { get; set; }

    }
}