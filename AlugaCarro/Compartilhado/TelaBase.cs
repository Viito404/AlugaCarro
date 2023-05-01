using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AlugaCarro.Compartilhado
{
     abstract class TelaBase
     {
          //interaçao usuario
          protected RepositorioBase repositorio = null;
          public string titulo = "";
          protected abstract void MostrarRegistros();
          protected abstract EntidadeBase ObterRegistro();
          protected int InserirId()
          {
               int id = 0;
               try
               {
                    Console.WriteLine("Digite o ID");
                    id = Convert.ToInt32(Console.ReadLine());

               }
               catch (FormatException)
               {
                    ImprimirMensagem("Digite uma ID válida!", ConsoleColor.Red);
                    Console.ReadLine();
                    InserirId();
                    return 0;
               }
               return id;
          }
          protected void EditarRegistro()
          {
               Console.Clear();
               repositorio.VerificarRegistro();
               MostrarRegistros();
               int id = InserirId();

               if (!repositorio.VerificarId(id))
               {
                    ImprimirMensagem("Entre com uma Id existente!", ConsoleColor.Red);
                    EditarRegistro();
                    return;
               }

               if (repositorio.VerificarRegistro())
                    return;
               EntidadeBase novoRegistro = ObterRegistro();
               ImprimirMensagem($"{titulo} editado com sucesso!", ConsoleColor.Green);
               repositorio.Editar(id, novoRegistro);
          }
          protected void Cadastrar()
          {
               Console.Clear();
               EntidadeBase entidadeBase = ObterRegistro();
               ArrayList listaErros = entidadeBase.ValidarErros();

               if (listaErros.Count > 0)
               {
                    foreach (String entidade in listaErros)
                         ImprimirMensagem(entidade, ConsoleColor.Red);

                    Cadastrar();
                    return;
               }

               ImprimirMensagem($"{titulo} cadastrado com sucesso!", ConsoleColor.Green);
               repositorio.Inserir(entidadeBase);
          }
          public virtual void Menu()
          {
               int opcao = 0;
               do
               {
                    Console.Clear();
                    Cabecalho();
                    Console.WriteLine("[1] Cadastrar [2] Visualizar [3] Editar [4] Excluir [5]");
                    Console.WriteLine("Escolha uma opção");
                    opcao = Convert.ToInt32(Console.ReadLine());

                    switch (opcao)
                    {
                         case 1: Cadastrar(); break;
                         case 2: Visualizar(); break;
                         case 3: EditarRegistro(); break;
                         case 4: Excluir(); break;
                         case 5: Console.WriteLine($"Saindo do {titulo}"); break;
                         default:
                              Console.WriteLine("Digite uma opção válida.");
                              Console.ReadLine();
                              break;
                    }
               } while (opcao != 5);
          }
          protected virtual void Cabecalho()
          {
               Console.WriteLine($"{titulo}");
               Console.WriteLine("------- > < ------");
               Console.WriteLine();
               Console.WriteLine("      .       _____");
               Console.WriteLine(" ---[__]_n_[_]__\\/_\\__");
               Console.WriteLine("|_______|_[_]__|_[_]_|_|");
               Console.WriteLine(" O    O     O--O O--O");
               Console.WriteLine();
          }
          protected virtual void Visualizar()
          {
               Console.Clear();
               repositorio.VerificarRegistro();
               MostrarRegistros();
               //adicionar a visualização de tela depois.
          }
          protected virtual void Excluir()
          {
               Console.Clear();
               repositorio.VerificarRegistro();
               MostrarRegistros();
               int id = InserirId();
               if (!repositorio.VerificarId(id))
               {
                    ImprimirMensagem("Entre com uma Id existente!", ConsoleColor.Red);
                    Excluir();
                    return;
               }
               ImprimirMensagem($"{titulo} deletado com sucesso!", ConsoleColor.Red);
               repositorio.Excluir(id);

          }
          protected virtual string VerificarString(string mensagem)
          {
               string valor = "";
               bool invalido = false;

               do
               {
                    invalido = false;
                    Console.WriteLine(mensagem);
                    valor = Console.ReadLine();

                    if (String.IsNullOrEmpty(valor) || String.IsNullOrWhiteSpace(valor))
                    {
                         ImprimirMensagem("Digite um valor válido!", ConsoleColor.Red);
                         invalido = true;
                    }

               } while (invalido);
               return valor;
          }
          protected virtual void ImprimirMensagem(string mensagem, ConsoleColor cor = ConsoleColor.White)
          {

               Console.ForegroundColor = cor;
               Console.Write(mensagem);
               Console.ReadLine();
               Console.ResetColor();

          }
     }
}
