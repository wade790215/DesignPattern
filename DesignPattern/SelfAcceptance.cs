using System;
using System.Collections.Generic;
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
            CharacterPropUI propUI = new CharacterPropUI();

            Character player = characterDirector.CreateCharacter(playerBuilder, playerParameter);
            Character enemy = characterDirector.CreateCharacter(enemyBuilder, enemyParameter);
            
            player.updateProp += propUI.ShowProp;

            ICharacterSkill fireBall = new FireBall();
            ICharacterSkill clash = new Clash();

            playerBuilder.InitSkill(clash);

            player.UseSkill(fireBall);
            player.UseSkill(clash);

            player.LearnSkill(fireBall);
            //player.ForgetSkill(fireBall);
            player.UseSkill(fireBall);

            player.Equip<Helmet>();
            player.Equip<Shoes>();
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

    public class Character : IUpdateCharacterProp
    {
        public Character()
        {
            characterSkills = new List<ICharacterSkill>();
            equipments = new List<IEquipable>();
        }

        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }

        public Action<Character> updateProp;

        private List<ICharacterSkill> characterSkills;

        private List<IEquipable> equipments;

        //泛型可以直接使用類別進行裝備
        public void Equip<T>() where T : IEquipable, new()
        {
            var item = new T();
            if (!equipments.Contains(item))
            {
                item.Equip(this);
                equipments.Add(item);
                UpdateProp(this);
            }
        }

        public void Unequip<T>() where T : IEquipable
        {
            var item = equipments.Find(e => e.GetType() == typeof(T));
            if (item != null)
            {
                item.UnEquip(this);
                equipments.Remove(item);
                UpdateProp(this);
            }
        }

        //使用時還需要實例化相對的技能物件
        public void LearnSkill(ICharacterSkill characterSkill)
        {
            if (!characterSkills.Contains(characterSkill))
                characterSkills.Add(characterSkill);
        }

        public void ForgetSkill(ICharacterSkill characterSkill)
        {
            var skill = characterSkills.Find(e => e == characterSkill);
            if (skill != null)
            {
                characterSkills.Remove(skill);
            }
        }

        public void UseSkill(ICharacterSkill characterSkill)
        {
            var skill = characterSkills.Find(e => e == characterSkill);
            if (skill != null)
            {
                skill.UseSkill();
            }
            else
            {
                Console.WriteLine($"還沒學會這個技能\n");
            }
        }

        public void IncreaseDefense(int value)
        {
            Defense += value;
        }

        public void DecreaseDefense(int value)
        {
            Defense -= value;
        }

        public void IncreaseSpeed(int value)
        {
            Speed += value;
        }

        public void DecreaseSpeed(int value)
        {
            Speed -= value;
        }

        public void UpdateProp(Character character)
        {
            updateProp?.Invoke(character);
        }
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

        public void InitSkill(ICharacterSkill skill)
        {
            GetCharacter().LearnSkill(skill);
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

    public interface IEquipable
    {
        void Equip(Character character);
        void UnEquip(Character character);
    }

    public class Helmet : IEquipable
    {
        public void Equip(Character character)
        {
            character.IncreaseDefense(10);
        }

        public void UnEquip(Character character)
        {
            character.DecreaseDefense(10);
        }
    }

    public class Shoes : IEquipable
    {
        public void Equip(Character character)
        {
            character.IncreaseSpeed(3);
        }

        public void UnEquip(Character character)
        {
            character.DecreaseSpeed(3);
        }
    }

    public interface IUpdateCharacterProp
    {
        void UpdateProp(Character character);
    }

    public class CharacterPropUI
    {
        public void ShowProp(Character character)   
        {
            Console.WriteLine($"數值發生改變\n血量:{character.Health}\n攻擊力:{character.Attack}\n防禦力:{character.Defense}" +
                $"\n速度:{character.Speed}\n");
        }
    }
}