using KSociety.Com.Pre.Form.View.Abstractions.Logix.List.GridView;
using System.Windows.Forms;

namespace KSociety.Com.Pre.Form.View.Forms.Logix.List.GridView;

public partial class LogixTabUserControl : UserControl, ITabUserControl
{
    public LogixTabUserControl()
    {
        InitializeComponent();
    }

    public ILogixConnection GetLogixConnection()
    {
        return comLogixConnection;
    }

    public ILogixTag GetLogixTag()
    {
        return comLogixTag;
    }

    private void TabControlLogix_Selected(object sender, TabControlEventArgs e)
    {
        switch (e.TabPage.Name)
        {
            case "logixTag":
                comLogixTag.LoadDataGrid();
                break;

            case "logixConnection":
                comLogixConnection.LoadDataGrid();
                break;

            default:
                break;
        }
    }
}