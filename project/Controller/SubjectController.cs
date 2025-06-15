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
    internal class SubjectController
    {
        public void AddSubject(Subject subject)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string subquery = "INSERT INTO Subjects(Name ,CourseId) VALUES (@Name, @courseid)";

                using (var command = new SQLiteCommand(subquery,connection))
                {
                    command.Parameters.AddWithValue("@Name",subject.Name);
                    command.Parameters.AddWithValue("@courseid",subject.CourseId);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        if (ex.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            throw new Exception("Subject name already exists.");
                        }
                        else
                        {
                            throw;
                        }
                    }
                }


                string lastSubjectIdQuery = "SELECT last_insert_rowid()";
                string lecsubquery = "INSERT INTO LecturerSubject(LecturerId,SubjectId) VALUES (@lecturerid,@subjectid)";

                using (var command = new SQLiteCommand(lecsubquery,connection))
                {
                    command.Parameters.AddWithValue("@lecturerid", subject.LecturerId);
                    command.Parameters.AddWithValue("@subjectid", lastSubjectIdQuery);
                }
            }
        }
    }
}
