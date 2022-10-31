using DungeonLibrary;

namespace MonsterLibrary
{
    public class Monster : Character
    {
        public int MaxDamage { get; set; }
        public string Description { get; set; }

        private int _minDamage;

        public int MinDamage
        {
            get { return _minDamage; }
            //can't be more than MaxDamage, also can't be less than 1
            set
            {
                if(value > MaxDamage || value < 1)
                {
                    if (value > MaxDamage || value < 1)
                    {
                        _minDamage = 1;
                    }
                    else
                    {
                        _minDamage = value;
                    }

                }
            }
        }

        public Monster(string name,
                       int life,
                       int maxLife,
                       int hitChance,
                       int block,
                       int minDamage,
                       int maxDamage,
                       string description) : base(name, hitChance, block, maxLife, life)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
            
        }

        public override string ToString()
        {
            return $@"Monster Info:
{ Name }
Life: {Life} of {MaxLife}
Damage: {MinDamage} to {MaxDamage}
Block: {Block}
Description:
{Description}
";
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }

        public static Monster GetMonster(int score)
        {
            if (score < 3 && score == 0)
            {
                Monster spaceGoop = new Monster("Space Goop", 30, 30, 70, 8, 8, 12, "Not very scary but watch out, they bite!");
                Monster giantSpaceAnts = new Monster("Giant Space Ants", 25, 25, 85, 6, 10, 14, "They're everywhere!");
                Monster floatingOrb = new Monster("Floating Orb", 28, 28, 60, 3, 14, 18, "The light before the light at the end of the tunnel!");

                List<Monster> monsters = new List<Monster>()
                {
                     spaceGoop, spaceGoop,
                floatingOrb, floatingOrb,
                giantSpaceAnts, giantSpaceAnts
                };

                return monsters[new Random().Next(monsters.Count)];
            }
            else if (score >= 3 && score < 5)
            {
                Monster spacePirate = new Monster("Space Pirate", 45, 45, 80, 9, 15, 18, "Arrrggghh!");
                Monster spaceDino = new Monster("Space Dino", 50, 50, 70, 5, 20, 24, "You thought they were extinct...");

                List<Monster> monsters2 = new List<Monster>()
            {
                spacePirate, spacePirate,
                spaceDino
            };
                return monsters2[new Random().Next(monsters2.Count)];

            }
            else if (score > 5)
            {
                Monster unknown = new Monster("**_+_*t&&%$+9-*", 55, 62, 99, 11, 21, 25, "Looks like a biblically accurate angel.");
                Monster Unknown2 = new Monster("---././.uwu././.---", 57, 63, 93, 8, 20, 31, "Looks like a biblically accurate unicorn but with more legs and less sh*ts to give!");

                List<Monster> monsters3 = new List<Monster>()
            {
                    unknown, Unknown2
            };
                return monsters3[new Random().Next(monsters3.Count)];

            }
            else
            {
                Monster spaceGoop = new Monster("Space Goop", 30, 30, 70, 8, 8, 12, "Not very scary but watch out, they bite!");
                Monster giantSpaceAnts = new Monster("Giant Space Ants", 25, 25, 85, 6, 10, 14, "They're everywhere!");
                Monster floatingOrb = new Monster("Floating Orb", 28, 28, 60, 3, 14, 18, "The light before the light at the end of the tunnel!");

                List<Monster> monsters = new List<Monster>()
                {
                     spaceGoop, spaceGoop,
                floatingOrb, floatingOrb,
                giantSpaceAnts, giantSpaceAnts
                };

                return monsters[new Random().Next(monsters.Count)];
            }
        }
    }
}