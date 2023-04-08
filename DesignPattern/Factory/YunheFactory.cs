namespace DesignPattern
{
   

    public class YunheFactory
    {
        public enum Position
        {
            FrontEndEngineer,
            Planner,
            ArtEngineer,
            HighClass
        }

        public static YunheEmpolyee HireStaff(Position personType)
        {
            YunheEmpolyee empolyee = null;
            switch (personType)
            {
                case Position.ArtEngineer:
                    empolyee = new ArtEngineer();
                    empolyee.AssemblyAbility();
                    break;
                case Position.FrontEndEngineer:
                    empolyee = new FrontEndEngineer();
                    empolyee.AssemblyAbility();
                    break;
                case Position.Planner:
                    empolyee = new Planner();
                    empolyee.AssemblyAbility();
                    break;
                case Position.HighClass:
                    empolyee = new HighClass();
                    empolyee.AssemblyAbility();
                    break;
            }
            return empolyee;
        }
    }
}
