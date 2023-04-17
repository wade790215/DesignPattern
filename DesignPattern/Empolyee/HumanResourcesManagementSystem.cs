using System.Collections.Generic;
using System.Linq;

namespace DesignPattern
{
    public class HumanResourcesManagementSystem
    {

        private List<YunheEmpolyee> employees = new List<YunheEmpolyee>();

        /// <summary>
        /// 入職
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <param name="yunheEmpolyee"></param>
        public void OnBoard(YunheEmpolyee yunheEmpolyee)
        {
            if (!employees.Exists(e => e.EmployeeInfo == yunheEmpolyee.EmployeeInfo))
            {
                employees.Add(yunheEmpolyee);
            }
        }

        /// <summary>
        /// 離職
        /// </summary>
        /// <param name="employeeInfo"></param>
        public void Resign(YunheEmpolyee yunheEmpolyee)
        {
            employees.RemoveAll(e => e.EmployeeInfo == yunheEmpolyee.EmployeeInfo);
        }

        /// <summary>
        /// 查詢員工
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <param name="yunheEmpolyee"></param>
        /// <returns></returns>
        public bool QueryEmployee(string name, Position position, Seniority seniority, out YunheEmpolyee yunheEmpolyee)
        {
            var foundEmployee = employees.FirstOrDefault(e => e.EmployeeInfo.name == name && e.EmployeeInfo.position == position);

            if (foundEmployee != null)
            {
                yunheEmpolyee = foundEmployee;
                return true;
            }

            yunheEmpolyee = null;
            return false;
        }
        
        /// <summary>
        /// 找出職位跟資歷符合的所有員工
        /// </summary>
        /// <param name="position"></param>
        /// <param name="seniority"></param>
        /// <returns></returns>
        public List<YunheEmpolyee> QueryEmployees(Position position, Seniority seniority)
        {
            List<YunheEmpolyee> foundEmployees = new List<YunheEmpolyee>();

            foreach (var employee in employees)
            {
                if(QueryEmployee(employee.EmployeeInfo.name, position, seniority, 
                    out YunheEmpolyee yunheEmpolyee))
                {
                    foundEmployees.Add(employee);
                }
            }

            return foundEmployees;
        }

        public List<EmployeeInfo> GetAllEmployeeInfos()
        {
            return employees.Select(e => e.EmployeeInfo).ToList();
        }
    }
}

