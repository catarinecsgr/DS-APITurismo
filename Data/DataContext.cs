using Microsoft.EntityFrameworkCore;
using Turismo_Catsy.Models;

namespace Turismo_Catsy.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AtrativoTuristico> AtrativoTuristicos { get; set; }
        public DbSet<TipoTuristico> TipoTuristicos { get; set; }
        public DbSet<AtrativoTipo> AtrativoTipos { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

         

             modelBuilder.Entity<AtrativoTuristico>().HasData
            (

                new AtrativoTuristico() {IdAtrativo = 1, Nome = "MASP", Endereco ="Av. Paulista, 1578, Bela Vista, São Paulo - SP", Gratuidade = "V", DiaGratuidade = "Terça e 1ª Quinta de cada mês" , Regiao = RegiaoEnum.Centro },
                new AtrativoTuristico() {IdAtrativo = 2, Nome = "Museu das Favelas" , Endereco = "Av. Rio Branco, 1269, Campos Elíseos, São Paulo - SP", Gratuidade = "V" , DiaGratuidade = "Todos os dias" , Regiao = RegiaoEnum.Centro },
                new AtrativoTuristico() {IdAtrativo = 3, Nome = "Pinacoteca do Estado", Endereco = "Praça da Luz, 2, Luz, São Paulo - SP", Gratuidade = "V", DiaGratuidade = "Sábado", Regiao = RegiaoEnum.Centro },
                new AtrativoTuristico() {IdAtrativo = 4, Nome = "Museu da Língua Portuguesa", Endereco = "Praça da Luz, s/n, Luz, São Paulo - SP", Gratuidade = "V", DiaGratuidade = "Sábado", Regiao = RegiaoEnum.Centro },
                new AtrativoTuristico() {IdAtrativo = 5, Nome = "CCBB SP", Endereco = "R. Álvares Penteado, 112, Centro Histórico de São Paulo, São Paulo - SP", Gratuidade = "V", DiaGratuidade = "Todos os dias", Regiao = RegiaoEnum.Centro },
                new AtrativoTuristico() {IdAtrativo = 6, Nome = "Parque do Ibirapuera", Endereco = "Av. Pedro Álvares Cabral, 5300, Vila Mariana, São Paulo - SP", Gratuidade = "V", DiaGratuidade = "Todos os dias", Regiao = RegiaoEnum.Sul },
                new AtrativoTuristico() {IdAtrativo = 7, Nome = "Parque Villa-Lobos", Endereco = "Av. Prof. Fonseca Rodrigues, 2001, Alto de Pinheiros, São Paulo - SP", Gratuidade = "V", DiaGratuidade = "Todos os dias", Regiao = RegiaoEnum.Oeste },
                new AtrativoTuristico() {IdAtrativo = 8, Nome = "Parque do Carmo", Endereco = "Av. Afonso de Sampaio e Sousa, 951, Itaquera, São Paulo - SP", Gratuidade = "V", DiaGratuidade = "Todos os dias", Regiao = RegiaoEnum.Leste },
                new AtrativoTuristico() {IdAtrativo = 9, Nome = "Parque da Água Branca", Endereco = "Av. Francisco Matarazzo, 455, Água Branca, São Paulo - SP", Gratuidade = "V", DiaGratuidade = "Todos os dias", Regiao = RegiaoEnum.Oeste },
                new AtrativoTuristico() {IdAtrativo = 10,Nome = "Parque do Povo", Endereco = "Av. Henrique Chamma, 420, Pinheiros, São Paulo - SP", Gratuidade = "V", DiaGratuidade = "Todos os dias", Regiao = RegiaoEnum.Oeste },
                new AtrativoTuristico() {IdAtrativo = 11, Nome = "Alteza Doceria", Endereco = "R. Américo de Campos, 36, Liberdade, São Paulo - SP", Gratuidade = "F", DiaGratuidade = " ", Regiao = RegiaoEnum.Centro },
                new AtrativoTuristico() {IdAtrativo = 12, Nome = "Gatcha (Cat Café/Cat Matcha Café)", Endereco = "Av. São Luís, 187, piso 02, lj 02, República, São Paulo - SP", Gratuidade = "F", DiaGratuidade = " ", Regiao = RegiaoEnum.Centro },
                new AtrativoTuristico() {IdAtrativo = 13, Nome = "Antique Café", Endereco = "R. Maria Cândida, 1153, Vila Guilherme, São Paulo - SP", Gratuidade = "F", DiaGratuidade = " ", Regiao = RegiaoEnum.Norte },
                new AtrativoTuristico() {IdAtrativo = 14, Nome = "Café Floresta", Endereco = "Av. Ipiranga, 200-21, Centro Histórico de São Paulo, São Paulo - SP", Gratuidade = "F", DiaGratuidade = " ", Regiao = RegiaoEnum.Centro },
                new AtrativoTuristico() {IdAtrativo = 15, Nome = "Cafeteria Gosto de Grão", Endereco = "R. Silveira Martins, 86, lj 02, Sé, São Paulo - SP", Gratuidade = "F", DiaGratuidade = " ", Regiao = RegiaoEnum.Centro }              
            );

            modelBuilder.Entity<AtrativoTipo>()
                .HasKey(pk => new {pk.IdAtrativo, pk.IdTipo });

            modelBuilder.Entity<TipoTuristico>().HasData
            (
                new TipoTuristico() {IdTipo = 1 , Segmento = "Museu" },
                new TipoTuristico() {IdTipo = 2 , Segmento = "Parque" },
                new TipoTuristico() {IdTipo = 3 , Segmento = "Cafeteria" }
            );

            modelBuilder.Entity<AtrativoTipo>().HasData
            (
                new AtrativoTipo() {IdAtrativo = 1, IdTipo = 1   },
                new AtrativoTipo() {IdAtrativo = 2, IdTipo = 1   },
                new AtrativoTipo() {IdAtrativo = 3, IdTipo = 1   },
                new AtrativoTipo() {IdAtrativo = 4, IdTipo = 1   },
                new AtrativoTipo() {IdAtrativo = 5, IdTipo = 1   },
                new AtrativoTipo() {IdAtrativo = 6, IdTipo = 2   },
                new AtrativoTipo() {IdAtrativo = 7, IdTipo = 2   },
                new AtrativoTipo() {IdAtrativo = 8, IdTipo = 2   },
                new AtrativoTipo() {IdAtrativo = 9, IdTipo = 2   },
                new AtrativoTipo() {IdAtrativo = 10, IdTipo = 2  },
                new AtrativoTipo() {IdAtrativo = 11, IdTipo = 3  },
                new AtrativoTipo() {IdAtrativo = 12, IdTipo = 3  },
                new AtrativoTipo() {IdAtrativo = 13, IdTipo = 3  },
                new AtrativoTipo() {IdAtrativo = 14, IdTipo = 3  },
                new AtrativoTipo() {IdAtrativo = 15, IdTipo = 3  }
            );

        }


    }

 
}

   
  