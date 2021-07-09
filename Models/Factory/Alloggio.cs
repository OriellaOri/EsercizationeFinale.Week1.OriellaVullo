using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizationeFinale.Week1.OriellaVullo.Models.Factory
{
    public class Alloggio : ICategoria
    {
        private const string _cartella = @"C:\watch";
        public string Descrizione { get; set ; }

        public decimal importoRimborsato(decimal spesa)
        {
            return spesa;
        }  
    }
}
