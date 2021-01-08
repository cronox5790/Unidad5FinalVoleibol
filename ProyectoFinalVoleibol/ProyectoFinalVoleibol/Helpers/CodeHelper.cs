using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalVoleibol
{
    public static class CodeHelper
    {
        public static int GetCodigo()
        {
            Random r = new Random();
            int cod1 = r.Next(100, 1000);
            int cod2 = r.Next(100, 1000);

            return (cod1 + cod2);
        }
    }
}
