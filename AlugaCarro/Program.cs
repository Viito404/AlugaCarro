using AlugaCarro.Compartilhado;
using AlugaCarro.ModuloCarro;
using System.Collections;

namespace AlugaCarro
{
    internal class Program
    {

        static void Main(string[] args)
        {
            RepositorioCarro repositorioCarros = new RepositorioCarro(new ArrayList());
            TelaCarro telaCarro = new TelaCarro(repositorioCarros);

            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("[1] Menu carro [2] ... [3] ... [4] ... [5]");
                Console.WriteLine("Escolha uma opção");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1: telaCarro.Menu(); break;
                    //case 2: Visualizar(); break;
                    //case 3: EditarRegistro(); break;
                    //case 4: Excluir(); break;
                    case 5: Console.WriteLine($"Saindo do programa..."); break;
                    default:
                        Console.WriteLine("Digite uma opção válida.");
                        Console.ReadLine();
                        break;
                }
            } while (opcao != 5);
        }
    }
}