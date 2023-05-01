using AlugaCarro.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugaCarro.ModuloCarro
{
     internal class Carro : EntidadeBase
     {
          //refatorar para carro herdar de veiculo
          //veiculo - cor/modelo/...
          //arraylist multas
          public string cor, placa, modelo, chassi, dataFabricacao, marca;


          public Carro(string cor, string placa, string modelo, string chassi, string dataFabricacao, string marca)
          {
               this.cor = cor;
               this.placa = placa;
               this.modelo = modelo;
               this.chassi = chassi;
               this.dataFabricacao = dataFabricacao;
               this.marca = marca;
          }

          public override void Atualizar(EntidadeBase registro)
          {
               Carro carro = (Carro)registro;
               this.cor = carro.cor;
               this.placa = carro.placa;
               this.modelo = carro.modelo;
               this.chassi = carro.chassi;
               this.dataFabricacao = carro.dataFabricacao;
               this.marca = carro.marca;
          }

          public override ArrayList ValidarErros()
          {
               ArrayList listaErros = new ArrayList();
               string[] cores = {"preto", "branco", "vermelho", "prata"};

               if (int.TryParse(cor, out int valor))
                    listaErros.Add("Cor não pode conter números.");

               if (!cores.Contains(cor.ToLower()))
                    listaErros.Add("Cor não encontrada.");

               if (!int.TryParse(dataFabricacao, out int value))
                    listaErros.Add("Data não pode conter letras.");

               return listaErros;
          }
     }
}
