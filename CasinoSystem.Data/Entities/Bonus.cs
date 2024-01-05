using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Data.Entities.Base;

namespace CasinoSystem.Data.Entities
{
    public class Bonus : BaseEntity, ITrackable
    {
        public string Name { get;set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public int Status { get;set; }
        public int BonusType { get; set; } 
        public decimal Amount { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime FinishTime { get; set; }
        public DateTime CreatedAt { get;set; }
        public DateTime LastUpdateAt { get; set; }
    }
}
