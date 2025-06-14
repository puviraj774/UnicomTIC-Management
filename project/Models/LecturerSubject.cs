using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Models
{
    internal class LecturerSubject
    {
        public int LecturerId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } 
        public string LecturerName { get; set; } 
    }
}
