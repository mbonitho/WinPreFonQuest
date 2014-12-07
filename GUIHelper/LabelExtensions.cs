using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DepthsOfWinPreFon
{
    public static class LabelExtensions
    {
        private static Action EmptyDelegate = delegate() { };

        /// <summary>
        /// Allow to redraw a label
        /// </summary>
        /// <param name="elem"></param>
        public static void Refresh(this Label elem)
        {
            elem.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
