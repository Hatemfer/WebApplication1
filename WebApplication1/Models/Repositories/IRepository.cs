namespace WebApplication1.Models.Repositories
{
    public interface IRepository<T>
    {
        double SalaryAverage();
        double MaxSalary();
        double MinSalary();
        int HrEmployeesCount();
        int infEmployeesCount();
        int comptEmployeesCount();
        IList<T> GetAll();
        T FindByID(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        List<T> Search(string term);

    }
}
