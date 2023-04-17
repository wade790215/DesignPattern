namespace DesignPattern
{
    public class SeniorArtEngineer : ArtEngineer
    {
        public SeniorArtEngineer(EmployeeInfo employeeInfo) : base(employeeInfo)
        {
        }
        public override void EmpolyeeAbility()
        {
            base.EmpolyeeAbility();
            Skills.Add(new Animation());
        }
    }
}
