using project.Data;
using project.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Controller
{ 
    internal class CourseControllers
    {
        public void AddCourse(Course course)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string Query = "INSERT INTO Courses (Name) VALUES (@name)";

                using (var cmd = new SQLiteCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", course.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
