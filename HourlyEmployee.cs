namespace EmployeeWork.Models
{
    public class HourlyEmployee : Employee
    {
        public HourlyEmployee(string name, string location, int employeeId, int workDays, float vacationDays) : base(name, location, employeeId, workDays, vacationDays)
        {
          // base.VacationDays = 10;
            base.WorkDays = 260;
            base.Type = Employee_enum.HourlyEmployee;
        }

        
    }
}
