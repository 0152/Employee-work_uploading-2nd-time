namespace EmployeeWork.Models
{
    public class Managers : Employee
    {
        public Managers(string name, string location, int employeeId, int workDays, float vacationDays) : base(name, location, employeeId, workDays, vacationDays)
        {
            //base.VacationDays = 30;
            base.WorkDays = 260;
            base.Type = Employee_enum.Manager;
        }

    }
}
