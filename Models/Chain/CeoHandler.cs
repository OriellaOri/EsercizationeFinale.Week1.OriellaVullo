using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizationeFinale.Week1.OriellaVullo.Models.Chain
{
    public class CeoHandler : AbstractHandler
    {
        public override string Handle(decimal request)
        {
            if (request >= 1000 && request < 2500)
                return $"Approvato dal CEO";
            else
                return base.Handle(request);
        }
    }
}
