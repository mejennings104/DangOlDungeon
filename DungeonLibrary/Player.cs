using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //the class is 'sealed' because it is the end of the "inheritance chain". No other classes can inherit from player
    public sealed class Player : Character
    {
        private Race _characterRace;
        //PROP
        private Race CharacterRace
        {
            get { return _characterRace; }
            set { _characterRace = value; }
        }

        private Weapon _equippedWeapon;
        private Race userRace;
        private WeaponType userWeapon;

        //Properties control access (using the getter and setter) to our private fields.
        public Weapon EquippedWeapon
        {
            //accessors
            get { return _equippedWeapon; }
            set { _equippedWeapon = value; }
        }

        public Player(string name, int hitChance, int block, int maxLife, int life, Race characterRace, Weapon equippedWeapon)
            : base(name, hitChance, block, maxLife, life)
        {
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            //Potential expansions go here
            //Modify prop values based on the chosen race
            switch (CharacterRace)
            {
                case Race.ZenithWarrior:
                    MaxLife += 10;
                    Life += 10;
                    break;
                case Race.PlinianAssassin:
                    HitChance += (HitChance / 20);
                    break;
                case Race.OyvindClone:
                    Block += 3;
                    HitChance += 5;
                    break;
                case Race.CyborgOctopus:
                    MaxLife += 5;
                    Life += 5;
                    Block += 5;
                    break;
            }

            //Possibly add more switches
        }

        public Player(string name, int hitChance, int block, int maxLife, int life, Race userRace, WeaponType userWeapon) : base(name, hitChance, block, maxLife, life)
        {
            this.userRace = userRace;
            this.userWeapon = userWeapon;
        }

        public override string ToString()
        {
            string description = "";
            switch (CharacterRace)
            {
                case Race.ZenithWarrior:
                    description = "Orc";
                    break;
                case Race.PlinianAssassin:
                    description = "Human";
                    break;
                case Race.OyvindClone:
                    description = "Elf";
                    break;
                case Race.CyborgOctopus:
                    description = "Dwarf";
                    break;
            }
            return base.ToString() + $"\nWeapon: {EquippedWeapon.Name}\n" + description;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 10);

            return damage;
        }
    }
}
