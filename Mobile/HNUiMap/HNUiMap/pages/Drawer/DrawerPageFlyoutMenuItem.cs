using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNUiMap.pages.Drawer
{

    public class DrawerPageFlyoutMenuItem
    {
        public DrawerPageFlyoutMenuItem()
        {
            TargetType = typeof(DrawerPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public int TabIndex { get; set; } // new property
        public string IconSource { get; set; }
    }
}