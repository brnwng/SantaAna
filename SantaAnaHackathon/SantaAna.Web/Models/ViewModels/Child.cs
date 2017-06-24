using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Models.ViewModels
{
    public class Child : BaseViewModel
    {
        public int Id { get; set; }
        public string ChildName { get; set; }
        public int ChildAgeYears { get; set; }
        public int ChildAgeMonths { get; set; }
    }
}