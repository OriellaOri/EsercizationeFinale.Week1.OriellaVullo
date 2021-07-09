using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizationeFinale.Week1.OriellaVullo.Models.Chain
{
    public class ManagerHandler : AbstractHandler
    {
        public override string Handle(decimal request)
        {
            if (request <= 400 )
                return $"Approvato da Manager";
            else
                return base.Handle(request);
        }
    }
}
