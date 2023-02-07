namespace EmployeeWork.Models
{
    public interface IEmployee
    {
        int Work(int workDays);
        float TakeVacation(float VacationDays);
    }
}
