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
using System.Threading;

using DepthsOfWinPreFon.Views;
using DepthsOfWinPreFon.Controllers;

namespace DepthsOfWinPreFon
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainMenu menu;

        public Controller Ctrl { get; set; }

        /*
         *Temporary attributes
         *These are not to be used after game initialization 
         */
        private int tmpStrength = 5;
        private int tmpDefense = 5;
        private int tmpAgility = 5;

        public MainWindow()
        {
            InitializeComponent();

            //Initialize the controller
            Ctrl = new Controller();

            //Adds the main menu component to the main window
            DisplayMainMenu();
        }

        /// <summary>
        /// Displays main menu on the window
        /// </summary>
        private void DisplayMainMenu()
        {
            menu = new MainMenu();
            menu.Margin = new Thickness(10);
            menu.lblNewGame.MouseUp += lblNewGame_MouseUp;
            Grid.SetColumnSpan(menu, 2);
            Grid.SetRowSpan(menu, 2);
            this.WindowGrid.Children.Add(menu);
        }

        /// <summary>
        /// Click on the new game label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblNewGame_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Displays a label, textbox and go button to type hero name
            menu.lblInfoNewGame.Visibility = System.Windows.Visibility.Visible;
            menu.txtHeroName.Visibility = System.Windows.Visibility.Visible;

            //Show the labels, textboxes and buttons used to initalize the hero's characteristics
            menu.lblStr.Visibility = System.Windows.Visibility.Visible;
            menu.txtStr.Visibility = System.Windows.Visibility.Visible;
            menu.btnStrPlus.Visibility = System.Windows.Visibility.Visible;            
            menu.btnStrMinus.Visibility = System.Windows.Visibility.Visible;

            menu.lblDef.Visibility = System.Windows.Visibility.Visible;
            menu.txtDef.Visibility = System.Windows.Visibility.Visible;
            menu.btnDefPlus.Visibility = System.Windows.Visibility.Visible;
            menu.btnDefMinus.Visibility = System.Windows.Visibility.Visible;

            menu.lblAgi.Visibility = System.Windows.Visibility.Visible;
            menu.txtAgi.Visibility = System.Windows.Visibility.Visible;
            menu.btnAgiPlus.Visibility = System.Windows.Visibility.Visible;
            menu.btnAgiMinus.Visibility = System.Windows.Visibility.Visible;

            menu.lblCharacteristics.Visibility = System.Windows.Visibility.Visible;
            menu.lblPointsToDispatch.Visibility = System.Windows.Visibility.Visible;

            menu.btnGo.Visibility = System.Windows.Visibility.Visible;

            menu.btnGo.Click += btnGo_Click;

            menu.btnStrPlus.Click += btnStrPlus_Click;
            menu.btnStrMinus.Click += btnStrMinus_Click;

            menu.btnDefPlus.Click += btnDefPlus_Click;
            menu.btnDefMinus.Click += btnDefMinus_Click;

            menu.btnAgiPlus.Click += btnAgiPlus_Click;
            menu.btnAgiMinus.Click += btnAgiMinus_Click;

            //The player has to dispatch 5 stat points before starting the game
            Ctrl.StatPointsToDispatch = 5;
        }

        private void btnAgiMinus_Click(object sender, RoutedEventArgs e)
        {
            if (this.tmpAgility > 0)
            {
                this.tmpAgility--;
                Ctrl.StatPointsToDispatch++;
                this.menu.txtAgi.Text = tmpAgility.ToString();
            }

            this.menu.lblPointsToDispatch.Content = string.Format("({0} points to dispatch)", Ctrl.StatPointsToDispatch);
            this.menu.lblPointsToDispatch.Refresh();
        }

        private void btnAgiPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Ctrl.StatPointsToDispatch > 0)
            {
                Ctrl.StatPointsToDispatch--;
                this.tmpAgility++;
                this.menu.txtAgi.Text = this.tmpAgility.ToString();
            }

            this.menu.lblPointsToDispatch.Content = string.Format("({0} points to dispatch)", Ctrl.StatPointsToDispatch);
            this.menu.lblPointsToDispatch.Refresh();
        }

        private void btnDefMinus_Click(object sender, RoutedEventArgs e)
        {
            if (this.tmpDefense > 0)
            {
                this.tmpDefense--;
                Ctrl.StatPointsToDispatch++;
                this.menu.txtDef.Text = this.tmpDefense.ToString();
            }

            this.menu.lblPointsToDispatch.Content = string.Format("({0} points to dispatch)", Ctrl.StatPointsToDispatch);
            this.menu.lblPointsToDispatch.Refresh();
        }

        private void btnDefPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Ctrl.StatPointsToDispatch > 0)
            {
                Ctrl.StatPointsToDispatch--;
                this.tmpDefense++;
                this.menu.txtDef.Text = this.tmpDefense.ToString();
            }

            this.menu.lblPointsToDispatch.Content = string.Format("({0} points to dispatch)", Ctrl.StatPointsToDispatch);
            this.menu.lblPointsToDispatch.Refresh();
        }

        private void btnStrMinus_Click(object sender, RoutedEventArgs e)
        {
            if (this.tmpStrength > 0)
            {
                this.tmpStrength--;
                Ctrl.StatPointsToDispatch++;
                this.menu.txtStr.Text = this.tmpStrength.ToString();
            }

            this.menu.lblPointsToDispatch.Content = string.Format("({0} points to dispatch)", Ctrl.StatPointsToDispatch);
            this.menu.lblPointsToDispatch.Refresh();
        }

        private void btnStrPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Ctrl.StatPointsToDispatch > 0)
            {
                Ctrl.StatPointsToDispatch--;
                tmpStrength++;
                this.menu.txtStr.Text = tmpStrength.ToString();
            }

            this.menu.lblPointsToDispatch.Content = string.Format("({0} points to dispatch)", Ctrl.StatPointsToDispatch);
            this.menu.lblPointsToDispatch.Refresh();
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (menu.txtHeroName.Text.Length > 0 && Ctrl.StatPointsToDispatch == 0) 
            {
                Ctrl = new Controller();

                Ctrl.InitializeGame(menu.txtHeroName.Text, this.tmpStrength, this.tmpDefense, this.tmpAgility);

                //Close the menu
                this.WindowGrid.Children.Remove(menu);

                //Connects the keyboard
                this.KeyDown += Window_OnKeyDown;

                //Draw the Hero (center of screen)
                lblPlayerInfo.Content = Ctrl.getPlayerInfo();
                WriteStory("You awaken in a dark cavern...");

                //FadeIn
                Draw();
            }
                
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //Label label = getLabelAtCoordinates(0, 0);
            //label.Visibility = Visibility.Visible;
            //Thread.Sleep(10000);
            FadeIn();
        }

        private void FadeIn()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Label label = getLabelAtCoordinates(j, i);
                    label.Visibility = Visibility.Visible;
                    Thread.Sleep(1);
                    label.Refresh();
                }
            }
        }

        private void FadeOut()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Label label = getLabelAtCoordinates(j, i);
                    label.Visibility = Visibility.Hidden;
                    Thread.Sleep(1);
                    label.Refresh();
                }
            }
        }

        /// <summary>
        /// Draws the maps according to hero coordinates
        /// </summary>
        private void Draw()
        {
            //erase all on the mapGrid that's not a label
            UIElement[] gripMapChildrenCopy = new UIElement[gridMap.Children.Count];
            gridMap.Children.CopyTo(gripMapChildrenCopy, 0);
            foreach (UIElement child in gripMapChildrenCopy)
            {
                if (!(child is Label))
                    gridMap.Children.Remove(child);
            }

            lblPlayerInfo.Content = Ctrl.getPlayerInfo();

            Point upperLeft = new Point(Ctrl.myHero.position.X - 3, Ctrl.myHero.position.Y - 3);
            //Point bottomRight = new Point(heroPositionOnMap.X + 3, heroPositionOnMap.Y + 3);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Tile tile = Ctrl.CurrentMap.getTileAt((int)upperLeft.X + i, (int)upperLeft.Y + j);
                    Label label = getLabelAtCoordinates(i, j);
                    label.Background = tile.getColor();

                    if (tile.Type == Tile.TileType.TREES)
                    {
                        Sprites.TreesSprite treesSprite = new Sprites.TreesSprite();
                        treesSprite.MinHeight = 100;
                        treesSprite.MinWidth = 100;
                        gridMap.Children.Add(treesSprite);
                        Grid.SetRow(treesSprite, j);
                        Grid.SetColumn(treesSprite, i);
                        treesSprite.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                        treesSprite.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    }

                    if (tile.Type == Tile.TileType.GRASS)
                    {
                        Sprites.GrassSprite grassSprite = new Sprites.GrassSprite();
                        grassSprite.MinHeight = 100;
                        grassSprite.MinWidth = 100;
                        gridMap.Children.Add(grassSprite);
                        Grid.SetRow(grassSprite, j);
                        Grid.SetColumn(grassSprite, i);
                        grassSprite.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                        grassSprite.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    }

                    if (tile.Type == Tile.TileType.SAND)
                    {
                        Sprites.SandSprite sandSprite = new Sprites.SandSprite();
                        sandSprite.MinHeight = 100;
                        sandSprite.MinWidth = 100;
                        gridMap.Children.Add(sandSprite);
                        Grid.SetRow(sandSprite, j);
                        Grid.SetColumn(sandSprite, i);
                        sandSprite.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                        sandSprite.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    }

                    if (tile.Type == Tile.TileType.GROUND) 
                    {
                        Sprites.GroundType1 groundSprite = new Sprites.GroundType1();
                        groundSprite.MinHeight = 100;
                        groundSprite.MinWidth = 100;
                        gridMap.Children.Add(groundSprite);
                        Grid.SetRow(groundSprite, j);
                        Grid.SetColumn(groundSprite, i);
                        groundSprite.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                        groundSprite.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    }

                    if (tile.Type == Tile.TileType.WALL)
                    {
                        Sprites.GroundType2 groundSprite = new Sprites.GroundType2();
                        groundSprite.MinHeight = 100;
                        groundSprite.MinWidth = 100;
                        gridMap.Children.Add(groundSprite);
                        Grid.SetRow(groundSprite, j);
                        Grid.SetColumn(groundSprite, i);
                        groundSprite.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                        groundSprite.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    }

                    if (tile.Type == Tile.TileType.SEA)
                    {
                        Sprites.SeaSprite seaSprite = new Sprites.SeaSprite();
                        seaSprite.MinHeight = 100;
                        seaSprite.MinWidth = 100;
                        gridMap.Children.Add(seaSprite);
                        Grid.SetRow(seaSprite, j);
                        Grid.SetColumn(seaSprite, i);
                        seaSprite.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                        seaSprite.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    }

                    if (tile.Type == Tile.TileType.MOUTAINS)
                    {
                        Sprites.MountainsSprites mountainsSprite = new Sprites.MountainsSprites();
                        mountainsSprite.MinHeight = 100;
                        mountainsSprite.MinWidth = 100;
                        gridMap.Children.Add(mountainsSprite);
                        Grid.SetRow(mountainsSprite, j);
                        Grid.SetColumn(mountainsSprite, i);
                        mountainsSprite.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                        mountainsSprite.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    }

                    if (tile.Content != null)
                    {
                        //Draws contents
                        if (tile.Content is GridContent)
                        {
                            //GridSprite
                            Sprites.GridSprite Grid_sprite = new Sprites.GridSprite();
                            gridMap.Children.Add(Grid_sprite);
                            Grid.SetRow(Grid_sprite, j);
                            Grid.SetColumn(Grid_sprite, i);
                        }
                        else if (tile.Content is ChestContent)
                        {
                            //ChestSprite
                            Sprites.ChestSprite chest_sprite = new Sprites.ChestSprite();
                            gridMap.Children.Add(chest_sprite);
                            Grid.SetRow(chest_sprite, j);
                            Grid.SetColumn(chest_sprite, i);
                        }
                        else if (tile.Content is EnnemyContent)
                        {
                            //KoboldSprite
                            Sprites.KoboldSprite Kobold_sprite = new Sprites.KoboldSprite();
                            gridMap.Children.Add(Kobold_sprite);
                            Grid.SetRow(Kobold_sprite, j);
                            Grid.SetColumn(Kobold_sprite, i);
                        }
                        else if (tile.Content is StairsContent)
                        {
                            //StairsSprite
                            Sprites.StairsSprite Stairs_sprite = new Sprites.StairsSprite();
                            gridMap.Children.Add(Stairs_sprite);
                            Grid.SetRow(Stairs_sprite, j);
                            Grid.SetColumn(Stairs_sprite, i);
                        }
                    }
                }
            }

            //HeroSprite
            Sprites.HeroSprite hero_sprite = new Sprites.HeroSprite();
            gridMap.Children.Add(hero_sprite);
            Grid.SetRow(hero_sprite, 3);
            Grid.SetColumn(hero_sprite, 3);
        }

        /// <summary>
        /// Get the label corresponding to specified coordinates
        /// Can be used to check passability or the presence of ennemies, and so on
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Label getLabelAtCoordinates(int x, int y)
        {
            try
            {
                string name = string.Format("lblTile{0}_{1}", x, y);
                Label lbl = ControlsManager.FindChild<Label>(gridMap, name);
                return lbl;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new Label();
            }
        }

        /// <summary>
        /// Overload pereceding method, shortcut
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Label getLabelAtCoordinates(Point P) 
        {
            return getLabelAtCoordinates((int)P.X, (int)P.Y);
        }

        public void Examine() 
        {
            //check the four squares around hero and see if there's something worth of interest
            string str = "There is nothing here.";

            Tile tileLeft = Ctrl.getTileLeft();
            Tile tileUp = Ctrl.getTileUp();
            Tile tileRight = Ctrl.getTileRight();
            Tile tileDown = Ctrl.getTileDown();

            if (tileLeft.Content != null)
            {
                if (tileLeft.Content is GridContent)
                {
                    str = "The path to the west is blocked by a grid";
                    //displays the text
                    WriteStory(str);

                    //If hero has a key to open the grid
                    if (Ctrl.myHero.Keys > 0)
                    {
                        WriteStory("Opened the grid with a key"); //TODO Refactor the "opening grid with key code"
                        Ctrl.myHero.Keys--;
                        tileLeft.Content = null;
                        Draw();
                    }
                } 

                else if (tileLeft.Content is ChestContent)
                {
                    str = "There is a chest west of me";
                    //displays the text
                    WriteStory(str);
                    OpenChest(tileLeft.Content as ChestContent);
                    //Removes chest
                    tileLeft.Content = null;
                    Draw();
                }  

                else if (tileLeft.Content is EnnemyContent)
                {
                    str = "There is an ennemy west of me";
                    //displays the text
                    WriteStory(str);
                }

                else if (tileLeft.Content is StairsContent)
                {
                    str = "There are stairs west of me";
                    //displays the text
                    WriteStory(str);
                }      
            }

            if (tileUp.Content != null)
            {
                if (tileUp.Content is GridContent)
                {
                    str = "The path to the north is blocked by a grid";
                    //displays the text
                    WriteStory(str);

                    //If hero has a key to open the grid
                    if (Ctrl.myHero.Keys > 0)
                    {
                        WriteStory("Opened the grid with a key");
                        Ctrl.myHero.Keys--;
                        tileUp.Content = null;
                        Draw();
                    }
                }
                    
                else if (tileUp.Content is ChestContent)
                {
                    str = "There is a chest north of me";
                    //displays the text
                    WriteStory(str);
                    OpenChest(tileUp.Content as ChestContent);
                    //Removes chest
                    tileUp.Content = null;
                    Draw();
                }

                else if (tileUp.Content is EnnemyContent)
                {
                    str = "There is an ennemy north of me";
                    //displays the text
                    WriteStory(str);
                }  

                else if (tileUp.Content is StairsContent)
                {
                    str = "There are stairs north of me";
                    //displays the text
                    WriteStory(str);
                }
                    
            }

            if (tileRight.Content != null)
            {
                if (tileRight.Content is GridContent){
                    str = "The path to the east is blocked by a grid";
                    //displays the text
                    WriteStory(str);

                    //If hero has a key to open the grid
                    if (Ctrl.myHero.Keys > 0)
                    {
                        WriteStory("Opened the grid with a key");
                        Ctrl.myHero.Keys--;
                        tileRight.Content = null;
                        Draw();
                    }
                } 

                else if (tileRight.Content is ChestContent)
                {
                    str = "There is a chest east of me";
                    //displays the text
                    WriteStory(str);
                    OpenChest(tileRight.Content as ChestContent);
                    //Removes chest
                    tileRight.Content = null;
                    Draw();
                }

                else if (tileRight.Content is EnnemyContent){
                    str = "There is an ennemy east of me";
                    //displays the text
                    WriteStory(str);
                }   

                else if (tileRight.Content is StairsContent)
                {
                    str = "There are stairs east of me";
                    //displays the text
                    WriteStory(str);
                }
            }

            if (tileDown.Content != null)
            {
                if (tileDown.Content is GridContent)
                {
                    str = "The path to the south is blocked by a grid";
                    //displays the text
                    WriteStory(str);

                    //If hero has a key to open the grid
                    if (Ctrl.myHero.Keys > 0)
                    {
                        WriteStory("Opened the grid with a key");
                        Ctrl.myHero.Keys--;
                        tileDown.Content = null;
                        Draw();
                    }
                }

                else if (tileDown.Content is ChestContent)
                {
                    str = "There is a chest south of me";
                    WriteStory(str);
                    OpenChest(tileDown.Content as ChestContent);
                    //Removes chest
                    tileDown.Content = null;
                    Draw();
                }

                else if (tileDown.Content is EnnemyContent)
                {
                    str = "There is an ennemy south of me";
                    //displays the text
                    WriteStory(str);
                }  

                else if (tileDown.Content is StairsContent)
                {
                    str = "There are stairs south of me";
                    //displays the text
                    WriteStory(str);
                }
            }
        }

        public void Attack()
        {
            //check the four squares around hero and see if there's something to attack
            string str = "There is nothing here.";

            Tile tileLeft = Ctrl.getTileLeft();
            Tile tileUp = Ctrl.getTileUp();
            Tile tileRight = Ctrl.getTileRight();
            Tile tileDown = Ctrl.getTileDown();

            if (tileLeft.Content != null)
            {
                if (tileLeft.Content is EnnemyContent)
                {
                    str = "Attacked ennemy";
                    //displays the text
                    WriteStory(str);
                    tileLeft.Content = null;
                    Draw();
                }
            }

            if (tileUp.Content != null)
            {
                if (tileUp.Content is EnnemyContent)
                {
                    str = "Attacked ennemy";
                    //displays the text
                    WriteStory(str);
                    tileUp.Content = null;
                    Draw();
                }
            }

            if (tileRight.Content != null)
            {
                if (tileRight.Content is EnnemyContent)
                {
                    str = "Attacked ennemy";
                    //displays the text
                    WriteStory(str);
                    tileRight.Content = null;
                    Draw();
                }

                else if (tileRight.Content is StairsContent)
                {
                    str = "Attacked ennemy";
                    //displays the text
                    WriteStory(str);
                    tileRight.Content = null;
                    Draw();
                }
            }

            if (tileDown.Content != null)
            {
                if (tileDown.Content is EnnemyContent)
                {
                    str = "Attacked ennemy";
                    //displays the text
                    WriteStory(str);
                    tileDown.Content = null;
                    Draw();
                }
            }
        }

        public void OpenChest(ChestContent chest)
        {
            WriteStory("Opened chest");

            switch (chest.Item)
            {
                case ChestContent.ChestItem.KEY:
                    WriteStory("I found a key");
                    Ctrl.myHero.Keys += 1;
                    break;
                case ChestContent.ChestItem.GOLD:
                    Random R = new Random((int)DateTime.Now.Ticks);
                    int bonus = R.Next(Ctrl.myHero.Level * 100);
                    WriteStory(string.Format("I found {0} gold !!", bonus));
                    Ctrl.myHero.Gold += bonus;
                    break;
                case ChestContent.ChestItem.POTION:
                    WriteStory("I found a potion");
                    break;
                default:
                    break;
            }
        }

        private void WriteStory(string str)
        {
            string minutes = DateTime.Now.Minute > 9 ? DateTime.Now.Minute.ToString() : '0' + DateTime.Now.Minute.ToString();
            string seconds = DateTime.Now.Second > 9 ? DateTime.Now.Second.ToString() : '0' + DateTime.Now.Second.ToString();
            this.lblStory.Content = DateTime.Now.Hour.ToString() + ':' + minutes + ':' + seconds + " - " + str + Environment.NewLine + lblStory.Content;
        }

        private void Window_OnKeyDown(object sender, KeyEventArgs e)
        {
            //*** DIRECTIONS
            if (e.Key == Key.Left && Ctrl.getTileLeft().Passable())
            {
                Ctrl.MoveHeroLeft();
                Draw();
            }

            if (e.Key == Key.Up && Ctrl.getTileUp().Passable())
            {
                Ctrl.MoveHeroUp();
                Draw();
            }

            if (e.Key == Key.Right && Ctrl.getTileRight().Passable())
            {
                Ctrl.MoveHeroRight();
                Draw();
            }

            if (e.Key == Key.Down && Ctrl.getTileDown().Passable())
            {
                Ctrl.MoveHeroDown();
                Draw();
            }

            //***  EXAMINE
            if (e.Key == Key.E)
            {
                Examine();
            }

            //***  ATTACK
            if (e.Key == Key.A)
            {
                Attack();
            }
        }

        private void btnGoLeft_Click(object sender, RoutedEventArgs e)
        {
            if (Ctrl.getTileLeft().Passable()) 
            {
                Ctrl.MoveHeroLeft();
                Draw();
            }
        }

        private void btnGoUp_Click(object sender, RoutedEventArgs e)
        {
            if (Ctrl.getTileUp().Passable())
            {
                Ctrl.MoveHeroUp();
                Draw();
            }
        }

        private void btnGoRight_Click(object sender, RoutedEventArgs e)
        {
            if (Ctrl.getTileRight().Passable())
            {
                Ctrl.MoveHeroRight();
                Draw();
            }
        }

        private void btnGoDown_Click(object sender, RoutedEventArgs e)
        {
            if (Ctrl.getTileDown().Passable())
            {
                Ctrl.MoveHeroDown();
                Draw();
            }
        }

        private void btnExamine_Click(object sender, RoutedEventArgs e)
        {
            Examine();
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            Attack();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Closing the game when the mainWindow is closed
            Application.Current.Shutdown();
        }
    }
}
