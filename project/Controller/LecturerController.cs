using project.Data;
using project.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.View;

namespace project.Controller
{
    internal class LecturerController
    {
        
        public void AddLecturer(Lecturer lecturer)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string lecturerquery = "INSERT INTO Lecturers(Name , NIC) VALUES (@name,@nic)";

                using (var command = new SQLiteCommand(lecturerquery, connection))
                {
                    command.Parameters.AddWithValue("@name", lecturer.Name);
                    command.Parameters.AddWithValue("@nic", lecturer.NIC);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        if (ex.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            throw new Exception("NIC already exists.");
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                string userquery = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                using (var cmd = new SQLiteCommand(userquery, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", lecturer.Username);
                    cmd.Parameters.AddWithValue("@Password", lecturer.Password);
                    cmd.Parameters.AddWithValue("@Role", "Lecturer");
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        if (ex.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            throw new Exception("Username already exists.");                           
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
        }        
    }
}
