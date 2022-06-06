using System;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string depname = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double basesalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(depname);
            Worker worker = new Worker(name, level, basesalary, dept);

            Console.Write("\nHow many contract to this worker? ");
            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " Contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);                
            }
            Console.Write("Enter mouth and year to calculate income (MM/YYYY): ");
            string[] mouthAndYear = Console.ReadLine().Split('/');
            int mouth = int.Parse(mouthAndYear[0]);
            int year = int.Parse(mouthAndYear[1]);
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine($"Income for {mouth}/{year}: {worker.Income(year, mouth).ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}