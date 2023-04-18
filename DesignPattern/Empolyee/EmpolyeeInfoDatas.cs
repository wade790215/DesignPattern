using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class EmpolyeeInfoDatas
    {
        public static List<EmployeeInfo> ApplyFrontEndEngineer()
        {
            List<EmployeeInfo> yunheEmpolyees = new List<EmployeeInfo>();

            EmployeeInfo EChenInfo = new EmployeeInfo()
            {
                name = "EChen",
                seniority = Seniority.Senior,
                position = Position.FrontEndEngineer,
                age = 31,
                salary = 9527
            };


            EmployeeInfo WadeInfo = new EmployeeInfo()
            {
                name = "Wade",
                seniority = Seniority.Junior,
                position = Position.FrontEndEngineer,
                age = 32,
                salary = 666
            };

            EmployeeInfo JackChangInfo = new EmployeeInfo()
            {
                name = "JackChang",
                seniority = Seniority.Junior,
                position = Position.FrontEndEngineer,
                age = 23,
                salary = 520
            };

            EmployeeInfo BoQianInfo = new EmployeeInfo()
            {
                name = "BoQian",
                seniority = Seniority.Junior,
                position = Position.FrontEndEngineer,
                age = 28,
                salary = 168
            };

            yunheEmpolyees.Add(EChenInfo);
            yunheEmpolyees.Add(WadeInfo);
            yunheEmpolyees.Add(JackChangInfo);
            yunheEmpolyees.Add(BoQianInfo);

            for (int i = 0; i < yunheEmpolyees.Count; i++)
            {
                yunheEmpolyees[i].employeeId = i + 1;
            }

            return yunheEmpolyees;
        }
    }
}
