namespace EmployeeWork.Models
{
    public class SalariedEmployee : Employee
    {
        public SalariedEmployee(string name, string location, int employeeId, int workDays, float vacationDays) : base(name, location, employeeId, workDays, vacationDays)
        {
            //base.VacationDays = 15;
            base.WorkDays = 260;
            base.Type = Employee_enum.SalariedEmployee;
        }
        public new float TakeVacation(float vacationDays)
        {
            if(vacationDays > 15) { throw new ArgumentException("vacation days shouldn't be more than 15 for salaried employees"); }
            return VacationDays = vacationDays;
        }

        public new int Work(int workDays)
        {
            return WorkDays = workDays;
        }

    }
}
