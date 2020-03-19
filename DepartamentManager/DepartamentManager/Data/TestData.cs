using DepartamentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentManager.Data
{
    class TestData
    {
        public static List<Departamen> Departamens { get; } = Enumerable.Range(1, 10)
            .Select(i => new Departamen
            {
                Id = i,
                Name = $"Name {i}",
                Employees = Enumerable.Range(1, 10)
                    .Select(j => new Employee
                    {
                        Id = j,
                        Name = $"Имя {j}",
                        SurName = $"Фамилия {j}",
                        Patronymic = $"Отчество {j}",
                        DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 / 6 * (j + 18)))
                    }).ToList<Employee>()
            }).ToList();
    }
}
