using System;

namespace DesignPattern
{
    public class ArtEngineer : YunheEmpolyee
    {
        public ArtEngineer(EmployeeInfo employeeInfo) : base(employeeInfo)
        {
        }

        public override void EmpolyeeAbility()
        {
            Skills.Add(new Modeling());
        }
    }
}
