using ConnectToDB.Data;
using ConnectToDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ConnectToDB.Controllers
{
    public class StudentController : Controller
    {
        DBUtility dbu;
        public StudentController(IConfiguration configuration)
        {
            dbu = new DBUtility(configuration);
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View(dbu.GetAll());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(string id)
        {
            Student st = dbu.GetStudent(id);
            return View(st);
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
                string stID = collection["txtStID"];  
                string name = collection["txtName"];  
                string surname = collection["txtSurname"];

                Student st = new Student(stID, name, surname);
                dbu.AddStudent(st);

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
