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

namespace DepthsOfWinPreFon.Views
{
    /// <summary>
    /// Logique d'interaction pour BattleView.xaml
    /// </summary>
    public partial class BattleView : UserControl
    {
        public EnemyContent Enemy { get; set; }

        public BattleView(EnemyContent enemy)
        {
            InitializeComponent();

            this.Enemy = enemy;
        }

        public void StartScrollingEnemyAppearanceAnimation()
        {
            var enemySprite = Enemy.Sprite.GetSprite().Cl;

            this.MainGrid.Children.Add(enemySprite);

            for (int i = 0; i < 400; i++)
            {
                enemySprite.Margin = new Thickness(i, 0, 0, 0);

                //Wait to slow down animation
                System.Threading.Thread.Sleep(75);
            }
        }
    }
}
