namespace DesignPattern
{
    public abstract class YunheEmpolyee
    {
        public YunheEmpolyee(Salary salary)
        {
            this.salary = salary;
        }

        /// <summary>
        /// 組裝能力
        /// </summary>
        public abstract YunheEmpolyee AssemblyAbility();

        private Salary salary;
    }
}
