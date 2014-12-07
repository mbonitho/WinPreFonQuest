using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DepthsOfWinPreFon
{
    public class Hero
    {
        public class Position
	    {
            public int X { get; set; }
            public int Y { get; set; }

            public static explicit operator Point(Position p)
            {
                return new Point(p.X, p.Y);
            } 
	    }

        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int ToNextLevel { get; set; }

        public int Strength { get; set; } //has an impact on damage dealt
        public int Defense { get; set; }  //has an impact on HP
        public int Agility { get; set; }  //has an impact on hit rate

        public int Gold { get; set; }
        public int Keys { get; set; }

        public Position position { get; set; }

        public Hero(string name, int str, int def, int agi)
        {
            Name = name;
            Level = 1;

            Strength = str;
            Defense = def;
            Agility = agi;

            ToNextLevel = 100;
            HP = 128;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>String containing player info</returns>
        public string getInfo()
        {
            return string.Format(@"Hero {1}{0}Level {2} Next {9}{0}HP {3}{0}Strength {4}{0}Defense {5}{0}Agility {6}{0}Money {7}{0}Keys {8}{0}Position {10};{11}",
                Environment.NewLine,
                this.Name, 
                this.Level,
                this.HP,
                this.Strength,
                this.Defense,
                this.Agility,
                this.Gold,
                this.Keys,
                this.ToNextLevel,
                this.position.X,
                this.position.Y);
        }
    }
}
