using System.Collections.Generic;
using Course.Entities.Enums;

namespace Course.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contract { get; set; } = new List<HourContract>();

        public Worker(){
        }

        public Worker(string name, WorkerLevel level, double basesalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = basesalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contract.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contract.Remove(contract);
        }

        public double Income(int year, int mouth)
        {
            double sum = BaseSalary;
            foreach(HourContract contract in Contract)
            {
                if(contract.Date.Year == year && contract.Date.Month == mouth)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }

    }
}