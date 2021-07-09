using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizationeFinale.Week1.OriellaVullo.Models.Factory
{
    public interface ICategoria
    {
        public string Descrizione { get; set; }
        decimal importoRimborsato(decimal spesa);
    }
}
