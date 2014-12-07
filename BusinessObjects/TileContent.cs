using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class EnnemyContent : TileContent
    {
        public int HP { get; set; }
        public int XPGiven { get; set; }
        public int Attack { get; set; }
    }

    public class StairsContent : TileContent
    {
        public Map nextMap { get; set; }
    }
}
