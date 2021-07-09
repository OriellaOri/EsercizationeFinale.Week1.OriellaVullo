using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizationeFinale.Week1.OriellaVullo.Models.Chain
{
    public class OperationalManagerHandler : AbstractHandler
    {
        public override string Handle(decimal request)
        {
            if (request >= 401 && request < 1000)
                return $"Approvato da Operational Manager";
            else
                return base.Handle(request);
        }
    }
}
