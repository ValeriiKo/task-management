using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIdentity.Models
{
    public class ProblemViewModel
    {
        public string SelectedManagerId { get; set; }
        public IEnumerable<SelectListItem> Managers { get; set; }
        public string Name { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string Status { get; set; }
    }
}
