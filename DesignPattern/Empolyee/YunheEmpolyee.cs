using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DesignPattern
{
    public abstract class YunheEmpolyee
    {
        /// <summary>
        /// 必須設定員工資料
        /// </summary>
        /// <param name="employeeInfo"></param>
        public YunheEmpolyee(EmployeeInfo employeeInfo)
        {
            EmployeeInfo = employeeInfo;    
        }
        public List<ISkill> Skills { get; private set; } = new List<ISkill>();

        public EmployeeInfo EmployeeInfo { get; }

        /// <summary>
        /// 員工能力
        /// </summary>
        public abstract void EmpolyeeAbility();

        public void Work()
        {
            Console.WriteLine($"{EmployeeInfo.name} is working...");

            foreach (var skill in Skills)
            {
                skill.Perform();
            }
        }

        public void AssignTask(IProjectTask task)
        {
            Console.WriteLine($"{EmployeeInfo.name} is starting the task...");
            task.PerformTask();
            Work();
            Console.WriteLine($"{EmployeeInfo.name} has finished the task.");
        }

    }
}
