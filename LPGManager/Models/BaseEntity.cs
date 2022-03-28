using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPGManager.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
            IsActive = 1;
        }
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public int IsActive { get; set; }

    }
}
