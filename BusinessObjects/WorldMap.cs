using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DepthsOfWinPreFon.BusinessObjects
{
    class WorldMap : Map
    {
        public class ElementZone
        {
            public Point UpperLeft { get; set; }
            public Point BottomRight { get; set; }
            public Tile.TileType TileType { get; set; }

            public ElementZone(Point upperleft, Point bottomright, Tile.TileType tileType)
            {
                UpperLeft = upperleft;
                BottomRight = bottomright;
                TileType = tileType;
            }
        }

        public List<ElementZone> ElementZones { get; set; }

        public WorldMap(int width, int height) : base (width, height)
        {
            ElementZones = new List<ElementZone>();

            for (int i = 0; i < WidthMap; i++)
            {
                for (int j = 0; j < HeightMap; j++)
                {
                    Tiles.Add(new Tile(i, j, Tile.TileType.SEA));
                }
            }
        }

        /// <summary>
        /// Generates this world map
        /// </summary>
        public override void Generate()
        {
            foreach (ElementZone zone in ElementZones)
            {
                ApplyElementZone(zone);
            }
        }

        /// <summary>
        /// Adds this element zone to this WorldMap
        /// </summary>
        /// <param name="zone"></param>
        public void ApplyElementZone(ElementZone zone)
        {
            ApplyElementZone(zone.UpperLeft, zone.BottomRight, zone.TileType);
        }

        /// <summary>
        /// Adds this element zone to this WorldMap
        /// </summary>
        /// <param name="zone"></param>
        public void ApplyElementZone(Point topLeftCorner, Point bottomRightCorner, Tile.TileType tileType)
        {
            int widthZone = Math.Abs((int)topLeftCorner.X - (int)bottomRightCorner.X) + 1;
            int heightZone = Math.Abs((int)topLeftCorner.Y - (int)bottomRightCorner.Y) + 1;

            for (int i = (int)topLeftCorner.X; i < widthZone + (int)topLeftCorner.X; i++)
            {
                for (int j = (int)topLeftCorner.Y; j < heightZone + (int)topLeftCorner.Y; j++)
                {
                    getTileAt(i, j).Type = tileType;
                }
            }
        }
    }
}
