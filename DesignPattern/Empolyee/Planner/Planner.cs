using System;

namespace DesignPattern
{
    public class Planner : YunheEmpolyee
    {
        public Planner(EmployeeInfo employeeInfo) : base(employeeInfo)
        {
        }

        public override void EmpolyeeAbility()
        {
            Skills.Add(new CoursePlanning());   
        }
    }
}
