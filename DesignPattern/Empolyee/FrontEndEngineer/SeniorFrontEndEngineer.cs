namespace DesignPattern
{
    public class SeniorFrontEndEngineer : FrontEndEngineer
    {
        public SeniorFrontEndEngineer(EmployeeInfo employeeInfo) : base(employeeInfo)
        {
        }

        public override void EmpolyeeAbility()
        {
            base.EmpolyeeAbility();
            Skills.Add(new Debug());
        }
    }
}
