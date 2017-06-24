using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Models.Requests
{
    public class ChildAddRequest
    {
        public string ChildName { get; set; }
        public int ChildAgeYears { get; set; }
        public int ChildAgeMonths { get; set; }

    }
}