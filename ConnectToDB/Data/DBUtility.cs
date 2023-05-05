using ConnectToDB.Models;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace ConnectToDB.Data
{
    public class DBUtility
    {
        private string con;
        private IConfiguration _config;

        public DBUtility(IConfiguration configuration)
        {
            this._config = configuration;
            this.con = _config.GetConnectionString("dbConnect");
        }

        public List<Student> GetAll()
        {
            List<Student> stList = new List<Student>();
            SqlConnection myCon = new SqlConnection(con);
            SqlDataAdapter cmdSelect = new SqlDataAdapter($"SELECT * FROM STUDENT", myCon);
            DataTable dt = new DataTable();
            DataRow dr;

            myCon.Open();
            cmdSelect.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    stList.Add(new Student((string)dr[0], (string)dr[1], (string)dr[2]));
                }
            }

            myCon.Close();

            return stList;
        }

        public Student GetStudent(string id)
        {
            string stID, name, surname;
            Student st = new Student();
            using (SqlConnection myCon = new SqlConnection(con))
            {

                SqlCommand cmd = new SqlCommand($"SELECT * FROM Student WHERE STUDENT_ID = '{id}'",myCon);
                myCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        stID = (string)reader[0];
                        name = (string)reader[1];
                        surname = (string)reader[2];

                        st = new Student(stID, name, surname);
                    }
                }
            }
            return st;
        }

        public void AddStudent(Student st)
        {
            using (SqlConnection myCon = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO Student VALUES('{st.StudentID}','{st.Name}','{st.Surname}')", myCon);
                myCon.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
