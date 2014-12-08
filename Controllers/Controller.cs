using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace DepthsOfWinPreFon.Controllers
{
    public class Controller
    {
        public Map CurrentMap {get; set;}
        public Hero myHero { get; set; }

        public Question CurrentQuestion { get; set; }

        public int StatPointsToDispatch { get; set; }

        /// <summary>
        /// Initialize a game
        /// </summary>
        /// <param name="heroName">Name of the hero</param>
        /// <param name="str">Hero's stregth</param>
        /// <param name="def">Hero's defense</param>
        /// <param name="agi">Hero's agility</param>
        public void InitializeGame(string heroName, int str, int def, int agi)
        {
            myHero = new Hero(heroName, str, def, agi);

            CurrentMap = MapsHolder.Maps[0]; //todo map logic

            //Creates the map
            CurrentMap.Generate();

            //Initializes hero position
            myHero.position = new Hero.Position { X = (int)CurrentMap.StartPosition.X, Y = (int)CurrentMap.StartPosition.Y };
        }

        /// <summary>
        /// Get player information as a string
        /// </summary>
        /// <returns></returns>
        public string getPlayerInfo()
        {
            return myHero.getInfo();
        }

        /// <summary>
        /// Return the left tile adjacent to the hero
        /// </summary>
        /// <returns></returns>
        public Tile getTileLeft()
        {
            return CurrentMap.getTileAt(myHero.position.X - 1, myHero.position.Y);
        }

        /// <summary>
        /// Return the top tile adjacent to the hero
        /// </summary>
        /// <returns></returns>
        public Tile getTileUp()
        {
            return CurrentMap.getTileAt(myHero.position.X, myHero.position.Y - 1);
        }

        /// <summary>
        /// Return the right tile adjacent to the hero
        /// </summary>
        /// <returns></returns>
        public Tile getTileRight()
        {
            return CurrentMap.getTileAt(myHero.position.X + 1, myHero.position.Y);
        }

        /// <summary>
        /// Return the bottom tile adjacent to the hero
        /// </summary>
        /// <returns></returns>
        public Tile getTileDown()
        {
            return CurrentMap.getTileAt(myHero.position.X, myHero.position.Y + 1);
        }

        /// <summary>
        /// Return the tile under the hero
        /// </summary>
        /// <returns></returns>
        public Tile getTileUnderHero()
        {
            return CurrentMap.getTileAt((Point)myHero.position);
        }

        /// <summary>
        /// Moves the hero to the left
        /// </summary>
        public void MoveHeroLeft() 
        {
            myHero.position.X -= 1;

            CheckForStairs();
        }

        /// <summary>
        /// Moves the hero to the top
        /// </summary>
        public void MoveHeroUp()
        {
            myHero.position.Y -= 1;

            CheckForStairs();
        }

        /// <summary>
        /// Moves the hero to the right
        /// </summary>
        public void MoveHeroRight()
        {
            myHero.position.X += 1;

            CheckForStairs();
        }

        /// <summary>
        /// Moves the hero to the bottom
        /// </summary>
        public void MoveHeroDown()
        {
            myHero.position.Y += 1;

            CheckForStairs();
        }

        /// <summary>
        /// Check if there are stairs under the hero (use after a move);
        /// </summary>
        private void CheckForStairs()
        {
            //Are there stairs under the hero ?
            if (this.getTileUnderHero().Content is StairsContent)
            {
                StairsContent content = CurrentMap.getTileAt((Point)myHero.position).Content as StairsContent;
                CurrentMap = content.nextMap;

                //ReInitializes hero position
                myHero.position = new Hero.Position { X = (int)CurrentMap.StartPosition.X, Y = (int)CurrentMap.StartPosition.Y };

                //TODO add a fade out effect since current map has changed
            }
        }
    }
}
