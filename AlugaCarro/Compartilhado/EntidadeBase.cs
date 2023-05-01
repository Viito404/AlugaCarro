using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugaCarro.Compartilhado
{
    abstract class EntidadeBase
    {
        //formula
        public int id;

        public abstract void Atualizar(EntidadeBase registro);

        public abstract ArrayList ValidarErros();
    }
}
