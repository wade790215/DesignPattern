namespace DesignPattern
{
    public class SeniorPlanner : Planner
    {
        public SeniorPlanner(EmployeeInfo employeeInfo) : base(employeeInfo)
        {
        }
        public override void EmpolyeeAbility()
        {
            base.EmpolyeeAbility();
            Skills.Add(new ProgramManagement());    
        }
    }
}
