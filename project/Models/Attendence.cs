﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Models
{
    internal class Attendence
    {
        public String StudentId { get; set; }
        public String StudentName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
