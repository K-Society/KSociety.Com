using KSociety.Base.Pre.Form.View.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.S7.List.GridView;
using System.ComponentModel;

namespace KSociety.Com.Pre.Form.View.Forms.S7.List.GridView;

public partial class S7Connection : DataGridView<Srv.Dto.S7.S7Connection, Srv.Dto.S7.List.GridView.S7Connection>, IS7Connection
{
    public S7Connection()
    {
        InitializeComponent();
    }

    public S7Connection(IContainer container)
    {
        container.Add(this);

        InitializeComponent();
    }
}