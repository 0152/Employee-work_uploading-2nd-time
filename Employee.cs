namespace EmployeeWork.Models
{
    public class Employee : IEmployee
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int EmployeeId { get; set; }
        public int WorkDays { get; set; }
        public float VacationDays { get; set; }
        public Employee_enum Type { get; set; }
        public Employee(string name, string location, int employeeId, int workDays, float vacationDays)
        {
            Name = name;
            Location = location;
            EmployeeId = employeeId;
            WorkDays = workDays;
            VacationDays = vacationDays;
        }
        public float TakeVacation(float vacationDays)
        {
            return VacationDays = vacationDays;
        }

        public int Work(int workDays)
        {
            return WorkDays=workDays;
        }
    }
}
