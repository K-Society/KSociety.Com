using KSociety.Base.Pre.Form.View.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.Logix.List.GridView;
using System.ComponentModel;

namespace KSociety.Com.Pre.Form.View.Forms.Logix.List.GridView;

public partial class LogixConnection :
    DataGridView<Srv.Dto.Logix.LogixConnection, Srv.Dto.Logix.List.GridView.LogixConnection>,
    ILogixConnection
{
    public LogixConnection()
    {
        InitializeComponent();
    }

    public LogixConnection(IContainer container)
    {
        container.Add(this);

        InitializeComponent();
    }
}