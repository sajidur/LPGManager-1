using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPGManager.Dtos
{
    public class CustomerLedgerView
    {
        public CustomerDto Customer { get; set; }
        public List<SellMasterDtos> SellList { get; set; }
        public LedgerSummary LedgerSummary { get; set; }
    }
}
