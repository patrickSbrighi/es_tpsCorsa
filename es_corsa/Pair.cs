using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es_corsa
{
    public class Pair
    {
        public TimeSpan Tempo
        {
            get;
            set;
        }

        public int Numero
        {
            get;
            set;
        }

        public Pair(TimeSpan tempo, int numero)
        {
            Tempo = tempo;
            Numero = numero;
        }
    }
}
