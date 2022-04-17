namespace WebApplication1.Models.Repositories

{
    public class EmployeeRepository : IRepository<Employee>
    {
        List<Employee> lemployees;
        public EmployeeRepository()
        {
            lemployees = new List<Employee>()
{
new Employee {Id=1,Name="Hatem Ferjeni", Departement= "informatique",Salary=2000},
new Employee {Id=2,Name="Amin Ameri", Departement= "RH",Salary=2500},
new Employee {Id=3,Name="Yassine Hadhri", Departement= "informatique",Salary=2700},
new Employee {Id=4,Name="Nizar Jawedi", Departement= "Comptabilité",Salary=2100}
};
        }
        public void Add(Employee e)
        {
            //ajouter un employé dans la liste
            if (e != null)
                lemployees.Add(e);

        }
        public void Delete(int id)
        {
            //Supprime l’employé ayant l’Id passé en paramètre
            var emp = FindByID(id);
            if (emp != null)
            {
                lemployees.Remove(emp);
            }
        }
        public Employee FindByID(int id)
        {
            //retourne l’employé ayant cet id
            return lemployees.FirstOrDefault(x => x.Id == id);
        }
        public List<Employee> GetAll()
        {
            // Retourne la liste des employés ;
            return lemployees;
        }
        public List<Employee> Search(string term)
        {
            //Recherche des employés dont leur noms contiennent la chaîne term
            if (!string.IsNullOrEmpty(term))
                return lemployees.Where(x => x.Name.Contains(term)).ToList();
            else 
                return lemployees;
        }
        public void Update(int id, Employee newemployee)
        {
            //Modifier un employé
            var emp = FindByID(id);
            if (emp != null && newemployee.Id == id)
            {
                emp.Name = newemployee.Name;
                emp.Departement = newemployee.Departement;
                emp.Salary = newemployee.Salary;
            }

        }

        IList<Employee> IRepository<Employee>.GetAll()
        {
            return lemployees;
        }

        public double SalaryAverage()
        {
            return lemployees.Average(x => x.Salary);
        }
        public double MaxSalary()
        {
            return lemployees.Max(x => x.Salary);
        }
        public double MinSalary()
        {
            return lemployees.Min(x => x.Salary);
        }
        public int HrEmployeesCount()
        {
            return lemployees.Where(x => x.Departement == "RH").Count();
        }
        public int infEmployeesCount()
        {
            return lemployees.Where(x => x.Departement == "informatique").Count();
        }
        public int comptEmployeesCount()
        {
            return lemployees.Where(x => x.Departement == "Comptabilité").Count();
        }
    }
}