using System;
using System.Security.Policy;

namespace DesignPattern
{
    internal class SelfAcceptance
    {

        internal void Main()
        {
            CharacterDirector characterDirector = new CharacterDirector();
            CharacterBuilder playerBuilder = new CharacterBuilder();
            CharacterBuilder enemyBuilder = new CharacterBuilder();
            CharacterParameter playerParameter = new CharacterParameter() { Health = 100, Attack = 15, Defense = 5, Speed = 3 };
            CharacterParameter enemyParameter = new CharacterParameter() { Health = 10, Attack = 2, Defense = 1, Speed = 1 };
            

            Character player = characterDirector.CreateCharacter(playerBuilder, playerParameter);
            Character enemy = characterDirector.CreateCharacter(enemyBuilder, enemyParameter);

            ICharacterSkill fireBall = new FireBall();
            ICharacterSkill clash = new Clash();

            playerBuilder.SetSkill(clash);
            enemyBuilder.SetSkill(fireBall);

            player.Skill.UseSkill();
            enemy.Skill.UseSkill();

            var helmet = new Helmet(player);
            var shoes = new Shoes(player);
            helmet.Equip();
            shoes.Equip();
            Console.WriteLine(player.Defense);
            Console.WriteLine(player.Speed);

            helmet.UnEquip();
            Console.WriteLine(player.Defense);
        }

       
    }

    public class CharacterDirector
    {
        public Character CreateCharacter(CharacterBuilder characterBuilder, CharacterParameter characterParameter)
        {
            characterBuilder.CreateCharacter();
            characterBuilder.SetHealth(characterParameter.Health);
            characterBuilder.SetAttack(characterParameter.Attack);
            characterBuilder.SetDefense(characterParameter.Defense);
            characterBuilder.SetSpeed(characterParameter.Speed);
            return characterBuilder.GetCharacter();
        }
    }

    public class CharacterParameter
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
    }

    public class Character
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public ICharacterSkill Skill { get; set; }
    }

    public class CharacterBuilder
    {
        private Character character;

        public void CreateCharacter()
        {
            character = new Character();
        }

        public Character GetCharacter()
        {
            return character;
        }

        public void SetSkill(ICharacterSkill skill)
        {
            GetCharacter().Skill = skill;
        }

        public void SetHealth(int health)
        {
            this.GetCharacter().Health = health;
        }

        public void SetAttack(int attack)
        {
            this.GetCharacter().Attack = attack;
        }

        public void SetDefense(int defense)
        {
            this.GetCharacter().Defense = defense;
        }

        public void SetSpeed(int speed)
        {
            this.GetCharacter().Speed = speed;
        }
    }

    public interface ICharacterSkill
    {
        void UseSkill();
    }

    public class Clash : ICharacterSkill
    {
        public void UseSkill()
        {
            Console.WriteLine($"Use {GetType().Name}");
        }
    }

    public class FireBall : ICharacterSkill
    {
        public void UseSkill()
        {
            Console.WriteLine($"Use {GetType().Name}");
        }
    }

    public class CharacterDecorator
    {
        protected Character character;

        public CharacterDecorator(Character character)
        {
            this.character = character;
        }
    }

    public interface IEquipable
    {
        void Equip();
        void UnEquip();
    }

    public class Helmet : CharacterDecorator, IEquipable
    {
        public Helmet(Character character) : base(character)
        {
        }

        public void Equip()
        {
            character.Defense += 10;
        }

        public void UnEquip()
        {
            character.Defense -= 10;
        }
    }

    public class Shoes : CharacterDecorator, IEquipable
    {
        public Shoes(Character character) : base(character)
        {
        }

        public void Equip()
        {
            character.Speed += 5;
        }

        public void UnEquip()
        {
            character.Speed -= 5;
        }
    }
}