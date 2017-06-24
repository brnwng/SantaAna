﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Calories { get; set; }
        public int Fat { get; set; }
        public int Carbs { get; set; }
        public int Protein { get; set; }
    }
}