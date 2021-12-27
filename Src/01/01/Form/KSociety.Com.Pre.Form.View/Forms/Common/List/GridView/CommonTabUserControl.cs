using KSociety.Com.Pre.Form.View.Abstractions.Common.List.GridView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSociety.Com.Pre.Form.View.Forms.Common.List.GridView;

public partial class CommonTabUserControl : UserControl, ITabUserControl
{
    public CommonTabUserControl()
    {
        InitializeComponent();
    }

    public ITagGroup GetCommonTagGroup()
    {
        return comCommonTagGroup;
    }

    private void TabControlCommon_Selected(object sender, TabControlEventArgs e)
    {
        switch (e.TabPage.Name)
        {
            case "commonTagGroup":
                comCommonTagGroup.LoadDataGrid();
                break;

            //case "commonConnection" :
            //    comCommonConnection.LoadDataGrid();
            //    break;

            //case "commonTag" :
            //    comCommonTag.LoadDataGrid();
            //    break;

            default:
                break;
        }
    }
}