using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPGManager.Dtos
{
    public class LedgerSummary
    {
        public decimal TotalQty { get; set; }
        public decimal TotalSupport { get; set; }
        public decimal TotalCommission { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
