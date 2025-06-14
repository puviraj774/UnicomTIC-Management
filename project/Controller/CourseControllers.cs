﻿using project.Data;
using project.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Controller
{ 
    internal class CourseController
    {
        // This method adds a new course to the database.
        public void AddCourse(Course course)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string Query = "INSERT INTO Courses (Name) VALUES (@name)";

                using (var cmd = new SQLiteCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", course.Name);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        if (ex.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            throw new Exception("Course name already exists.");
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
        }

        // This method Delete an existing course in the database.
        public void DeleteCourse(int CourseId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM Courses WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", CourseId);
                command.ExecuteNonQuery();
            }
        }

        
        public Course GetCourseById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Courses WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Course
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }
            }

            return null;

        }

        // This method retrieves a list of all courses from the database.
        public List<Course> GetCourseList()
        {
            var courses = new List<Course>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                string coursequery = "SELECT Id , Name FROM Courses";

                using (var cmd = new SQLiteCommand(coursequery, conn))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new Course()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString()
                            };
                            courses.Add(course);
                        }
                    }
                }

            }
            return courses;
        }
    }
}
