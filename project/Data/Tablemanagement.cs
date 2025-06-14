using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace project.Data
{
    internal class Tablemanagement
    {
        public static void CreateTables()
        {
            using (SQLiteConnection conn = DatabaseConnection.GetConnection())
            {

                using (var pragmaCmd = conn.CreateCommand())
                {
                    pragmaCmd.CommandText = "PRAGMA foreign_keys = ON;";
                    pragmaCmd.ExecuteNonQuery();
                }

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Courses(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name VARCHAR(25) NOT NULL UNIQUE
                        );

                        CREATE TABLE IF NOT EXISTS Subjects(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name VARCHAR(25) NOT NULL UNIQUE,
                            CourseId INTEGER NOT NULL,
                            FOREIGN KEY (CourseId) REFERENCES Courses(Id)
                        );

                        CREATE TABLE IF NOT EXISTS Students(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            NIC VARCHAR(12) NOT NULL UNIQUE,
                            CourseId INTEGER NOT NULL,
                            UNIQUE (Name,NIC),
                            FOREIGN KEY (CourseId) REFERENCES Courses(Id)
                        );

                        CREATE TABLE IF NOT EXISTS Lecturers(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            NIC VARCHAR(12) NOT NULL UNIQUE
                        );

                        CREATE TABLE IF NOT EXISTS LecturerSubject(
                            LecturerId INTEGER NOT NULL,
                            SubjectId INTEGER NOT NULL,
                            PRIMARY KEY (LecturerId,SubjectId),
                            FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
                            FOREIGN KEY (LecturerId) REFERENCES Lecturers(Id)
                        );

                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            UserName TEXT NOT NULL UNIQUE,
                            Password TEXT NOT NULL,
                            LinkedId INTEGER ,
                            Role TEXT NOT NULL,
                            UNIQUE(LinkedId,Role)
                        );

                        CREATE TABLE IF NOT EXISTS Exams(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            SubjectId INTEGER,
                            ExamDate DATE NOT NULL,
                            StartTime TIME NOT NULL,
                            EndTime TIME NOT NULL,
                            UNIQUE (Name,SubjectId),
                            UNIQUE (SubjectId,ExamDate, StartTime, EndTime),
                            FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
                        );

                        CREATE TABLE IF NOT EXISTS TimeTable(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            SubjectId INTEGER,
                            Room TEXT,
                            ClassDate DATE NOT NULL,
                            StartTime TIME NOT NULL,
                            EndTime TIME NOT NULL,
                            UNIQUE (Room, ClassDate, StartTime, EndTime),
                            FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
                        );

                        CREATE TABLE IF NOT EXISTS Marks(
                            StudentId INTEGER,
                            ExamId INTEGER,                                     
                            Marks INTEGER CHECK (Marks >= 0 AND Marks <= 100),
                            PRIMARY KEY (StudentId,ExamId),
                            FOREIGN KEY (ExamId) REFERENCES Exams(Id),
                            FOREIGN KEY (StudentId) REFERENCES Students(Id)                            
                        );
                                
                        CREATE TABLE IF NOT EXISTS Attendence(
                            StudentId INTEGER NOT NULL,
                            Date DATE NOT NULL,
                            Status TEXT NOT NULL,
                            UNIQUE (StudentId,Date),
                            FOREIGN KEY (StudentId) REFERENCES Students(Id)
                        );

                    ";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
