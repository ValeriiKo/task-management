using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIdentity.Models
{
    public class Problem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string Status { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
