namespace DesignPattern
{
    public class Wade : FrontEndEngineer
    {
        public override YunheEmpolyee AssemblyAbility()
        {
            return new  Wade(); 
        }

        public override void Coding()
        {
            throw new System.NotImplementedException();
        }
    }
}
