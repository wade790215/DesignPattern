namespace DesignPattern
{
    public class HumanResources : YunheEmpolyee
    {
        private HumanResourcesManagementSystem _hrms;

        public HumanResources(EmployeeInfo employeeInfo, HumanResourcesManagementSystem hrms) : base(employeeInfo)
        {
            _hrms = hrms;
        }

        public override void EmpolyeeAbility()
        {

        }

        public bool QueryEmployee(EmployeeInfo employeeInfo, out YunheEmpolyee yunheEmpolyee)
        {
            return _hrms.QueryEmployee(employeeInfo.name,employeeInfo.position,employeeInfo.seniority, out yunheEmpolyee);
        }
    }
}

