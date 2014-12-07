using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthsOfWinPreFon
{
    public class Map
    {
        public int WidthMap { get; set; }
        public int HeightMap { get; set; }

        //StartPosition of the hero on the map when it appears
        public Point StartPosition { get; set; }

        //List of 
        protected List<Tile> Tiles;

        public Map(int width, int height)
        {
            HeightMap = height;
            WidthMap = width;

            //DefaultPosition is 0,0
            StartPosition = new Point(0, 0);

            Tiles = new List<Tile>();
        }

        public bool spaceTaken(Point orig, int width, int height)
        {
            for (int i = (int)orig.X; i < (int)orig.X + width; i++)
            {
                for (int j = (int)orig.Y; j < (int)orig.Y + height; j++)
                {
                    //If it's ground, then this spot is taken by a room or corridor
                    if (getTileAt(i, j).Type == Tile.TileType.GROUND)
                        return true;
                }
            }
            return false;
        }

        public Tile getTileAt(int x, int y)
        {
            foreach (var tile in Tiles)
            {
                if (tile.X == x && tile.Y == y)
                    return tile;
            }
            //if not found, return new wall
            return new Tile(-1, -1) { Type = Tile.TileType.WALL };
        }

        public Tile getTileAt(Point p)
        {
            return getTileAt((int)p.X, (int)p.Y);
        }

        public virtual void Generate() 
        {
            throw new Exception("This method must be overriden!");
        }
    }
}
