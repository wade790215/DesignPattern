using System;

namespace DesignPattern
{
    public class HighClass : YunheEmpolyee
    {
        public HighClass(EmployeeInfo employeeInfo) : base(employeeInfo)
        {
        }

        public override void EmpolyeeAbility()
        {
            throw new NotImplementedException();
        }
    }
}
