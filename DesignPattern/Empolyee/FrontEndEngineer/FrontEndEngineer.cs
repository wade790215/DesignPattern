using System;

namespace DesignPattern
{
    public class FrontEndEngineer : YunheEmpolyee
    {
        public FrontEndEngineer(EmployeeInfo employeeInfo) : base(employeeInfo)
        {
            
        }

        public override void EmpolyeeAbility()
        {
            Skills.Add(new WriteCode());
        }
    }
}
