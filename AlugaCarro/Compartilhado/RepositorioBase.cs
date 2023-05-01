using System.Collections;

namespace AlugaCarro.Compartilhado
{
    abstract class RepositorioBase
    {
        //backend - lugar de manipular os dados
        protected ArrayList registros;
        int contagemId = 0;


        public void Inserir(EntidadeBase registro)
        {
            registro.id = contagemId;
            registros.Add(registro);
            contagemId++;
        }
        public void Excluir(int id)
        {
            if (VerificarRegistro())
                return;
            EntidadeBase registroExcluir = BuscarPorId(id);
            registros.Remove(registroExcluir);
        }
        public void Editar(int id, EntidadeBase registroEditar)
        {
            EntidadeBase registroAtualizar = BuscarPorId(id);
            if (registroAtualizar == null)
            {
                Console.WriteLine("ID não encontrado.");
                return;
            }
            registroAtualizar.Atualizar(registroEditar);
        }

        public ArrayList RetornarRegistro()
        {
            return registros;
            //bagulho do Sort.
        }

        public EntidadeBase BuscarPorId(int id)
        {
            EntidadeBase registro = null;
            foreach (EntidadeBase s in registros)
            {
                if (s.id == id)
                    registro = s;
            }
            return registro;
        }

          public virtual bool VerificarId(int id)
          {
               bool temRegistro = false;
               foreach (EntidadeBase s in registros)
               {
                    if (s.id == id)
                         temRegistro = true;
               }
               return temRegistro;
          }

          public bool VerificarRegistro()
        {
            if (registros.Count == 0)
            {
                Console.WriteLine("Nenhum registro encontrado.");
                return true;
            }
            return false;
        }

    }
}
