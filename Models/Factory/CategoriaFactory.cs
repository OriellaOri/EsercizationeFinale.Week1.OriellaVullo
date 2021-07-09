using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizationeFinale.Week1.OriellaVullo.Models.Factory
{
    public class CategoriaFactory
    {
        internal static ICategoria GetCategoria(int nbrCategoria)
        {
            ICategoria categoria;
            switch (nbrCategoria)
            {
                case 1:
                    categoria = new Viaggio();
                    break;

                case 2:
                    categoria = new Alloggio();
                    break;

                case 3:
                    categoria = new Vitto();
                    break;

                case 4:
                    categoria = new Altro();
                    break;

                default:
                    Console.WriteLine("Categoria non prevista");
                    categoria = null;
                    break;
            }
            return categoria;
        }
    }
}
