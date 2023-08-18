using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult? Run(params IResult[] logics)
        {
            // her bir iş kuralı için
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; // hatalı olan logic döner.
                }
            }

            return null;
        }

    }
}
