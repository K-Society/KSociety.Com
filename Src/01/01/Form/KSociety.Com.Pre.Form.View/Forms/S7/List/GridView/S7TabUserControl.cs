using KSociety.Com.Pre.Form.View.Abstractions.S7.List.GridView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSociety.Com.Pre.Form.View.Forms.S7.List.GridView
{
    public partial class S7TabUserControl : UserControl, ITabUserControl
    {
        public S7TabUserControl()
        {
            InitializeComponent();
        }

        public IS7Connection GetS7Connection()
        {
            return comS7Connection;
        }

        public IS7Tag GetS7Tag()
        {
            return comS7Tag;
        }

        private void TabControlS7_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "s7Tag":
                    comS7Tag.LoadDataGrid();
                    break;

                case "s7Connection":
                    comS7Connection.LoadDataGrid();
                    break;

                default:
                    break;
            }
        }
    }
}
