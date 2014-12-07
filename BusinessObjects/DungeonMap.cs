using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace DepthsOfWinPreFon.BusinessObjects
{
    class DungeonMap : Map
    {
        public class Room
        {
            public Point UpperLeft { get; set; }
            public Point BottomRight { get; set; }

            public Room(Point upperleft, Point bottomright)
            {
                UpperLeft = upperleft;
                BottomRight = bottomright;
            }
        }

        public List<Room> Rooms { get; set; }

        public DungeonMap(int width, int height) : base (width, height)
        {
            Rooms = new List<Room>();

            for (int i = 0; i < WidthMap; i++)
            {
                for (int j = 0; j < HeightMap; j++)
                {
                    Tiles.Add(new Tile(i, j));
                }
            }
        }

        /// <summary>
        /// Carves all the rooms of this map
        /// </summary>
        public override void Generate()
        {
            foreach (Room r in Rooms)
            {
                generateRoom(r);
            }
        }

        /// <summary>
        /// Creates a room at specified coordinates (just modifies the tile object)
        /// </summary>
        /// <param name="topLeftCorner"></param>
        /// <param name="bottomRightCorner"></param>
        public void generateRoom(Point topLeftCorner, Point bottomRightCorner)
        {
            int widthRoom = Math.Abs((int)topLeftCorner.X - (int)bottomRightCorner.X) + 1;
            int heightRoom = Math.Abs((int)topLeftCorner.Y - (int)bottomRightCorner.Y) + 1;

            for (int i = (int)topLeftCorner.X; i < widthRoom + (int)topLeftCorner.X; i++)
            {
                for (int j = (int)topLeftCorner.Y; j < heightRoom + (int)topLeftCorner.Y; j++)
                {
                    getTileAt(i, j).Type = Tile.TileType.GROUND;
                }
            }
        }

        public void generateRoom(Room room)
        {
            generateRoom(room.UpperLeft, room.BottomRight);
        }

        /// <summary>
        /// Generates a random room
        /// </summary>
        public void generateRandomRoom()
        {
            bool created = false;
            while (!created)
            {
                Random R = new Random((int)DateTime.Now.Ticks);
                int xOrig = R.Next(WidthMap);
                int yOrig = R.Next(HeightMap);

                int widthRoom = R.Next(4) + 1;
                int heightRoom = R.Next(4) + 1;

                if (!spaceTaken(new Point(xOrig, yOrig), widthRoom, heightRoom))
                {
                    generateRoom(new Point(xOrig, yOrig), new Point(xOrig + widthRoom, yOrig + heightRoom));
                    created = true;
                }
            }
        }
    }
}
