using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DepthsOfWinPreFon.Interfaces;

namespace DepthsOfWinPreFon
{
    public class TileContent
    {

    }

    public class GridContent : TileContent
    {

    }

    public class ChestContent : TileContent
    {
        public enum ChestItem
        {
            KEY,
            GOLD,
            POTION
        }

        public ChestItem Item { get; set; }
    }

    public class EnemyContent : TileContent
    {
        public IEnemySprite Sprite { get; set; }

        public string Name { get; set; }
        public int HP { get; set; }
        public int XPGiven { get; set; }
        public int Attack { get; set; }

        public EnemyContent(string name, int hp, int xp, int attack, IEnemySprite spr)
        {
            Name = name;
            HP = hp;
            XPGiven = xp;
            Attack = attack;
            Sprite = spr;
        }
    }

    public class StairsContent : TileContent
    {
        public Map nextMap { get; set; }
    }
}
