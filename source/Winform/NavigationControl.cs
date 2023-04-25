using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Winform
{
    public class NavigationControl
    {
        List<UserControl> list = new List<UserControl>();
        Panel panel;

        public NavigationControl(List<UserControl> list, Panel panel)
        {
            this.list = list;
            this.panel = panel;
            addUserControls();
        }

        private void addUserControls()
        {
            for (int i = 0; i < list.Count(); i++)
            {
                list[i].Dock = DockStyle.Fill;
                panel.Controls.Add(list[i]);
            } 
        }

        public void display(int index)
        {
            if (index < list.Count())
            {
                list[index].BringToFront();
            }
        }

    }
}
