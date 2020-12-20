using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class Amortization
    {
        public ushort Period  { get; set; }
        public double StartingBalance { get; set; }
        public double RemainingBalance { get; set; }
        public double Interest { get; set; }
        public double Principal { get; set; }
    }
}
