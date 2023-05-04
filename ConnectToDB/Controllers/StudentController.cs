using ConnectToDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConnectToDB.Controllers
{
    public class StudentController : Controller
    {
        private string con;
        private IConfiguration _config;

        public StudentController(IConfiguration configuration)
        {
            this._config = configuration;
            this.con = _config.GetConnectionString("dbConnect");
        }
        // GET: StudentController
        public ActionResult Index()
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

            return View(stList);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
