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
        //Method To Add Lecturer
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

                // Get the last inserted lecturer ID
                string lastLecturerIdQuery = "SELECT last_insert_rowid()";
                int lastLecturerId;
                using (var lastIdCommand = new SQLiteCommand(lastLecturerIdQuery, connection))
                {
                    lastLecturerId = Convert.ToInt32(lastIdCommand.ExecuteScalar());
                }

                // Insert into Users table with the last inserted lecturer ID
                string userquery = "INSERT INTO Users (Username, Password, Role,LinkedId) VALUES (@Username, @Password, @Role,@linkedid)";
                using (var cmd = new SQLiteCommand(userquery, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", lecturer.Username);
                    cmd.Parameters.AddWithValue("@Password", lecturer.Password);
                    cmd.Parameters.AddWithValue("@Role", "Lecturer");
                    cmd.Parameters.AddWithValue("@linkedid", lastLecturerId);
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

        //Method To Delete Lecturer
        public void DeleteLecturer(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string deleteQuery = "DELETE FROM Lecturers WHERE Id = @Id";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                // Also delete the user associated with the lecturer
                string deleteUserQuery = "DELETE FROM Users WHERE LinkedId = @Id AND Role = 'Lecturer'";
                using (var userCommand = new SQLiteCommand(deleteUserQuery, connection))
                {
                    userCommand.Parameters.AddWithValue("@Id", id);
                    userCommand.ExecuteNonQuery();
                }
            }
        }

        //Method To Update Lecturer
        public void UpdateLecturer(int id,string newusername ,string newpassword)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string updateQuery = "UPDATE Users SET Username = @Username, Password = @Password WHERE LinkedId = @Id AND Role = 'Lecturer'";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", newusername);
                    command.Parameters.AddWithValue("@Password", newpassword);
                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        command.ExecuteNonQuery();
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

        public List<Lecturer> GetLecturerList()
        {
            var Lecturers = new List<Lecturer>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                string lecturerquery = "SELECT Id , Name,NIC FROM Lecturers";

                using (var cmd = new SQLiteCommand(lecturerquery, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var lecturer = new Lecturer()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                NIC = reader["NIC"].ToString()
                            };
                            Lecturers.Add(lecturer);
                        }
                    }
                }
            }
            return Lecturers;
        }

        public Lecturer GetLecturerById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Lecturers WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lecturer
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            NIC = reader["NIC"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public Lecturer FindUsernamePassword(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT Username, Password FROM Users WHERE LinkedId = @Id AND Role = @role", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@role", "Lecturer");

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lecturer
                        {
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
}
