using AlugaCarro.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugaCarro.ModuloCarro
{
     internal class TelaCarro : TelaBase
     {
          public TelaCarro(RepositorioCarro repositorioCarros)
          {
               repositorio = repositorioCarros;
               titulo = "Carro";
          }

          protected override void MostrarRegistros()
          {
               ArrayList carro = repositorio.RetornarRegistro();
               Console.WriteLine("{0,-10} |{1,-10} |{2,-10} | {3,-10}", "ID", "Cor", "Marca", "Modelo");
               foreach (Carro c in carro)
               {
                    Console.WriteLine("{0,-10} |{1,-10} |{2,-10} | {3,-10}", c.id, c.cor.ToUpper(), c.marca.ToUpper(), c.modelo.ToUpper());
               }
               Console.ReadLine();
          }

          protected override EntidadeBase ObterRegistro()
          {
               string cor, placa, modelo, chassi, dataFabricacao, marca;
               cor = VerificarString("Escolha uma cor entre as opções (branco, preto, vermelho ou prata): ");
               placa = VerificarString("Digite a placa do carro: ");
               modelo = VerificarString("Digite a modelo do carro: ");
               chassi = VerificarString("Digite a chassi do carro: ");
               dataFabricacao = VerificarString("Digite o ano do carro: ");
               marca = VerificarString("Digite a marca do carro: ");              
               return new Carro(cor, placa, modelo, chassi, dataFabricacao, marca);               
          }
          
     }
}
