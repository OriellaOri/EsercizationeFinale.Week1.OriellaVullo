using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizationeFinale.Week1.OriellaVullo.Models.Factory
{
    public class Viaggio : ICategoria
    {
        public string Descrizione { get ; set ; }

        public decimal importoRimborsato(decimal spesa)
        {
            return spesa + 50;
        }
    }
}
