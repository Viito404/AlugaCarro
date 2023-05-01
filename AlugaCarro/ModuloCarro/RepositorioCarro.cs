using AlugaCarro.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugaCarro.ModuloCarro
{
    internal class RepositorioCarro : RepositorioBase
    {
        public RepositorioCarro(ArrayList arrayList)
        {
            registros = arrayList;
        }
        //protected Carro VerRegistros()
        //{
        //    return (Carro)base.();
        //}
    }
}
