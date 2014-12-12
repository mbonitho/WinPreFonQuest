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

using DepthsOfWinPreFon.Interfaces;

namespace DepthsOfWinPreFon.Sprites
{
    /// <summary>
    /// Logique d'interaction pour EctoplasmeSprite.xaml
    /// </summary>
    public partial class EctoplasmeSprite : UserControl, IEnemySprite
    {
        public EctoplasmeSprite()
        {
            InitializeComponent();
        }

        public UserControl GetSprite()
        {
            return this;
        }
    }
}
