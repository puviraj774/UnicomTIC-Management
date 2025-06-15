using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Models
{
    internal class Lecturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }

        [Browsable(false)]
        public string Username { get; set; }
        [Browsable(false)]
        public string Password { get; set; }
        public int SubjectId { get; set; }
        public string Subject { get; set; }
    }
}
