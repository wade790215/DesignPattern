using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern
{
    public class ProjectManagement
    {
        public void AssignWork(List<YunheEmpolyee> employees, Type skillType, IProjectTask projectTask)
        {
            var skilledEmployees = employees.Where(emp => emp.Skills.Any(skill => skill.GetType() == skillType)).ToList();

            if (skilledEmployees.Count > 0)
            {
                Console.WriteLine($"Assigning work to employees with the {skillType.Name} skill...");

                foreach (var employee in skilledEmployees)
                {
                    Console.WriteLine($"Assigning work to {employee.EmployeeInfo.name}...");
                    projectTask.PerformTask();
                }
            }
            else
            {
                Console.WriteLine($"No employees with the {skillType.Name} skill are available.");
            }
        }
    }
}
