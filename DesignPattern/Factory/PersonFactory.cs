namespace DesignPattern
{
    public enum PersonType
    {
        MainCharacter,
        Partner,
        NPC
    }

    public class PersonFactory
    {
        public Person CreatePerson(PersonType personType)
        {
            Person person = null;
            switch (personType)
            {
                case PersonType.NPC:
                    person = new NPC();
                    break;
                case PersonType.MainCharacter:
                    person = new MainCharacter();
                    break;
                case PersonType.Partner:
                    person = new Partner();
                    break;
            }
            return person;
        }
    }
}
