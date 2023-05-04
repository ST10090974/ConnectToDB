using System.Data;
using System.Data.SqlClient;

namespace ConnectToDB.Models
{
    public class Student
    {
        public string StudentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Student()
        {
            this.StudentID = "";
            this.Name = "No name";
            this.Surname = "No surname";
        }
        public Student(string studentID, string name, string surname)
        {
            StudentID = studentID;
            Name = name;
            Surname = surname;
        }


    }
}
