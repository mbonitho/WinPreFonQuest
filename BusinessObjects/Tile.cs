using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DepthsOfWinPreFon
{
    public class Tile
    {
        public enum TileType
        {
            TREES = -3, //worldMap trees
            SAND = -2, //worldMap sand
            GRASS = -1, //worldMap grass
            GROUND = 0, //dungeon soil
            WALL = 1, //dungeon wall
            SEA = 2, //worldMap sea
            MOUTAINS = 3 //worldMap mountains
        }

        public int X { get; set; }
        public int Y { get; set; }
        public TileContent Content { get; set; }

        public TileType Type { get; set; }

        public Tile(int x, int y, TileType tile_type = TileType.WALL)
        {
            this.X = x;
            this.Y = y;

            this.Type = tile_type;
            this.Content = null;
        }

        public bool Passable()
        {
            if (this.Type > 0) //0 is ground, greater is wall or sea
                return false;

            bool R = true;

            if (this.Content != null)
            {
                if (this.Content is StairsContent)
                    R = true;
                else
                    R = false;
            }

            return R;
        }

        /// <summary>
        /// Changes the color of a specific label according to its nature
        /// </summary>
        public SolidColorBrush getColor()
        {
            SolidColorBrush bgColor = new SolidColorBrush();

            switch (Type)
            {
                case TileType.GROUND:
                    bgColor.Color = Color.FromArgb(255, 160, 160, 160); //ground color
                    break;

                case TileType.WALL:
                    bgColor.Color = Color.FromArgb(255, 20, 160, 20); //wall color
                    break;

                default:
                    bgColor.Color = Color.FromArgb(255, 255, 255, 255); //black
                    break;
            }

            return bgColor;
        }
    }
}
