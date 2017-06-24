using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Models.Requests
{
    public class ParentAddRequest
    {
        public int FamilySize { get; set; }
        public int NumberOfChildren { get; set; }

    }
}