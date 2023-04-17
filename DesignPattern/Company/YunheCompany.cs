using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DesignPattern
{
    public enum Position
    {
        FrontEndEngineer,
        Planner,
        ArtEngineer,
        HighClass,
        HumanResources
    }

    public enum Seniority
    {
        Junior,
        Senior
    }

    public class YunheCompany
    {
        private HumanResourcesManagementSystem HRMS;

        public YunheCompany()
        {
            HRMS = new HumanResourcesManagementSystem();
        }

        public YunheEmpolyee HireStaff(EmployeeInfo employeeInfo)
        {
            YunheEmpolyee empolyee = null;
            switch (employeeInfo.position)
            {
                case Position.ArtEngineer:
                    empolyee = new ArtEngineer(employeeInfo);
                    empolyee.EmpolyeeAbility();
                    HRMS.OnBoard(empolyee);
                    break;

                case Position.FrontEndEngineer:

                    switch (employeeInfo.seniority)
                    {
                        case Seniority.Junior:
                            empolyee = new JuniorFrontEndEngineer(employeeInfo);
                            empolyee.EmpolyeeAbility();
                            HRMS.OnBoard(empolyee);
                            break;
                        case Seniority.Senior:
                            empolyee = new SeniorFrontEndEngineer(employeeInfo);
                            empolyee.EmpolyeeAbility();
                            HRMS.OnBoard(empolyee);
                            break;
                    }
                    break;

                case Position.Planner:
                    empolyee = new Planner(employeeInfo);
                    empolyee.EmpolyeeAbility();
                    HRMS.OnBoard(empolyee);
                    break;

                case Position.HighClass:
                    empolyee = new HighClass(employeeInfo);
                    empolyee.EmpolyeeAbility();
                    HRMS.OnBoard(empolyee);
                    break;

                case Position.HumanResources:
                    empolyee = new HumanResources(employeeInfo, HRMS);
                    empolyee.EmpolyeeAbility();
                    HRMS.OnBoard(empolyee);
                    break;
            }
            return empolyee;
        }

        public bool QueryEmployee(string name, Position position, Seniority seniority
            , out YunheEmpolyee yunheEmpolyee)
        {
            if (HRMS.QueryEmployee(name, position, seniority,out YunheEmpolyee empolyee))
            {
                yunheEmpolyee = empolyee;
                return true;
            }

            yunheEmpolyee = null;
            return false;
        }

        public List<YunheEmpolyee> QueryEmployees(Position position, Seniority seniority)
        {
            return HRMS.QueryEmployees(position , seniority);
        }

        public List<EmployeeInfo> GetAllEmployeeInfos()
        {
            return HRMS.GetAllEmployeeInfos();
        }
    }
}
