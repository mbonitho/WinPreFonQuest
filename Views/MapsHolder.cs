using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DepthsOfWinPreFon.BusinessObjects;

namespace DepthsOfWinPreFon
{
    public static class MapsHolder
    {
        public static List<Map> Maps;

        static MapsHolder()
        {
            Maps = new List<Map>();

            //****************************************************************************************************
            //World Map #1
            //****************************************************************************************************
            WorldMap W1 = new WorldMap(30, 30);
            W1.StartPosition = new Point(0, 3);
            W1.ElementZones.Add(new WorldMap.ElementZone(new Point(0, 0), new Point(10, 5), Tile.TileType.SAND));
            W1.ElementZones.Add(new WorldMap.ElementZone(new Point(1, 1), new Point(9, 4), Tile.TileType.GRASS));
            W1.ElementZones.Add(new WorldMap.ElementZone(new Point(3, 3), new Point(5, 4), Tile.TileType.TREES));
            W1.ElementZones.Add(new WorldMap.ElementZone(new Point(4, 3), new Point(4, 3), Tile.TileType.MOUTAINS));


            //****************************************************************************************************
            //Map #1 : Dungeon 1 Floor 0
            //****************************************************************************************************
            DungeonMap D1F0 = new DungeonMap(30, 30);
            //Rooms and corridors
            D1F0.Rooms.Add(new DungeonMap.Room(new Point(0, 0), new Point(10, 5)));
            D1F0.Rooms.Add(new DungeonMap.Room(new Point(6, 5), new Point(6, 18)));
            D1F0.Rooms.Add(new DungeonMap.Room(new Point(1, 19), new Point(6, 23)));
            D1F0.Rooms.Add(new DungeonMap.Room(new Point(7, 14), new Point(10, 14)));
            D1F0.Rooms.Add(new DungeonMap.Room(new Point(11, 11), new Point(13, 15)));
            D1F0.Rooms.Add(new DungeonMap.Room(new Point(10, 8), new Point(15, 8)));
            D1F0.Rooms.Add(new DungeonMap.Room(new Point(16, 8), new Point(16, 4)));
            D1F0.Rooms.Add(new DungeonMap.Room(new Point(14, 12), new Point(15, 12)));
            //Contents
            D1F0.getTileAt(6, 6).Content = new GridContent();
            D1F0.getTileAt(10, 0).Content = new ChestContent() { Item = ChestContent.ChestItem.KEY };
            D1F0.getTileAt(6, 7).Content = new EnnemyContent();
            D1F0.getTileAt(1, 19).Content = new ChestContent() { Item = ChestContent.ChestItem.GOLD };
            D1F0.getTileAt(10, 8).Content = new StairsContent() { nextMap = W1 };


            //****************************************************************************************************
            //Adding the maps to the list
            //****************************************************************************************************
            Maps.Add(D1F0);
            Maps.Add(W1);
        }
    }
}
