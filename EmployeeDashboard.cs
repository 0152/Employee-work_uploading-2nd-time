using EmployeeWork.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace EmployeeWork.Controllers
{
    public class EmployeeDashboard : Controller
    {
        private static List<Employee> _employees;

        public EmployeeDashboard()
        {
            if (_employees == null)
            {
                ListEmployees();
            }

        }
        public ActionResult Index()
        {
            var employees = _employees;
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        private void ListEmployees()
        {
            var hourlyEmployee1 = new HourlyEmployee("h1", "US", 1, 260, 0);
            var hourlyEmployee2 = new HourlyEmployee("h2", "US", 2, 260, 0);
            var hourlyEmployee3 = new HourlyEmployee("h3", "US", 3, 260, 0);
            var hourlyEmployee4 = new HourlyEmployee("h4", "US", 4, 260, 0);
            var hourlyEmployee5 = new HourlyEmployee("h5", "US", 5, 260, 0);
            var hourlyEmployee6 = new HourlyEmployee("h6", "US", 6, 260, 0);
            var hourlyEmployee7 = new HourlyEmployee("h7", "US", 7, 260, 0);
            var hourlyEmployee8 = new HourlyEmployee("h8", "US", 8, 260, 0);
            var hourlyEmployee9 = new HourlyEmployee("h9", "US", 9, 260, 0);
            var hourlyEmployee10 = new HourlyEmployee("h10", "US", 10, 260, 0);

            var SalariedEmployee1 = new SalariedEmployee("s1", "US", 11, 260, 0);
            var SalariedEmployee2 = new SalariedEmployee("s2", "US", 12, 260, 0);
            var SalariedEmployee3 = new SalariedEmployee("s3", "US", 13, 260, 0);
            var SalariedEmployee4 = new SalariedEmployee("s4", "US", 14, 260, 0);
            var SalariedEmployee5 = new SalariedEmployee("s5", "US", 15, 260, 0);
            var SalariedEmployee6 = new SalariedEmployee("s6", "US", 16, 260, 0);
            var SalariedEmployee7 = new SalariedEmployee("s7", "US", 17, 260, 0);
            var SalariedEmployee8 = new SalariedEmployee("s8", "US", 18, 260, 0);
            var SalariedEmployee9 = new SalariedEmployee("s9", "US", 19, 260, 0);
            var SalariedEmployee10 = new SalariedEmployee("s10", "US", 20, 260, 0);

            var manager1 = new Managers("m1", "US", 21, 260, 0);
            var manager2 = new Managers("m2", "US", 22, 260, 0);
            var manager3 = new Managers("m3", "US", 23, 260, 0);
            var manager4 = new Managers("m4", "US", 24, 260, 0);
            var manager5 = new Managers("m5", "US", 25, 260, 0);
            var manager6 = new Managers("m6", "US", 26, 260, 0);
            var manager7 = new Managers("m7", "US", 27, 260, 0);
            var manager8 = new Managers("m8", "US", 28, 260, 0);
            var manager9 = new Managers("m9", "US", 29, 260, 0);
            var manager10 = new Managers("m10", "US", 30, 260, 0);

            _employees = new List<Employee>() {
            hourlyEmployee1,
            hourlyEmployee2,
            hourlyEmployee3,
            hourlyEmployee4,
            hourlyEmployee5,
            hourlyEmployee6,
            hourlyEmployee7,
            hourlyEmployee8,
            hourlyEmployee9,
            hourlyEmployee10,

            SalariedEmployee1,
            SalariedEmployee2,
            SalariedEmployee3,
            SalariedEmployee4,
            SalariedEmployee5,
            SalariedEmployee6,
            SalariedEmployee7,
            SalariedEmployee8,
            SalariedEmployee9,
            SalariedEmployee10,

             manager1,
             manager2,
             manager3,
             manager4,
             manager5,
             manager6,
             manager7,
             manager8,
             manager9,
             manager10
            };


        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Work(int id)
        {
            var employees = _employees;
            var emp = employees.FirstOrDefault(e => e.EmployeeId == id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Work(IFormCollection collection)
        {
            try
            {
                var employees = _employees;
                var emp = employees.FirstOrDefault(e => e.EmployeeId == Convert.ToInt32(collection["EmployeeId"].ToString()));
                var workDays = Convert.ToInt32(collection["Workdays"].ToString());
                if (workDays > 260 || workDays < 0)
                {
                    ViewBag.error = "work days should be between 0 and 260";
                    return View(emp);
                }
                emp!.Work(workDays);
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }

        public ActionResult Vacation(int id)
        {
            var employees = _employees;
            var emp = employees.FirstOrDefault(e => e.EmployeeId == id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Vacation(IFormCollection collection)
        {
            try
            {
                var employees = _employees;
                var emp = employees.FirstOrDefault(e => e.EmployeeId == Convert.ToInt32(collection["EmployeeId"].ToString()));
                var vacationDays = (float)Convert.ToDouble(collection["VacationDays"].ToString());
                var empType = collection["Type"].ToString();
                if (vacationDays < 0)
                {
                    ViewBag.error = "vacation days shouldn't be a negative number";
                    return View(emp);
                }
                switch (empType.ToLower())
                {
                    case "hourlyemployee":
                        if (vacationDays > 10)
                        {
                            ViewBag.error = "vacation days shouldn't be more than 10 for hourly employees";
                            return View(emp);
                        }
                        break;
                    case "salariedemployee":
                        if (vacationDays > 15)
                        {
                            ViewBag.error = "vacation days shouldn't be more than 15 for salaried employees";
                            return View(emp);
                        }
                        break;
                    case "manager":
                        if (vacationDays > 30)
                        {
                            ViewBag.error = "vacation days shouldn't be more than 30 for managers";
                            return View(emp);
                        }
                        break;
                    default:
                        break;
                }

                emp!.TakeVacation(vacationDays);
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }


    }

}
