using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizationeFinale.Week1.OriellaVullo.Models.Chain
{
    public interface IHandler
    {
        IHandler SetNext(IHandler next);
        string Handle(decimal request);
    }
}
