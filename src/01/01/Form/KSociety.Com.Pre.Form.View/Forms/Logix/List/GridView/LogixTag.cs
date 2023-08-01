using KSociety.Base.Pre.Form.View.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.Logix.List.GridView;
using System.ComponentModel;

namespace KSociety.Com.Pre.Form.View.Forms.Logix.List.GridView;

public partial class LogixTag : DataGridView<Srv.Dto.Logix.LogixTag, Srv.Dto.Logix.List.GridView.LogixTag>, ILogixTag
{
    public LogixTag()
    {
        InitializeComponent();
    }

    public LogixTag(IContainer container)
    {
        container.Add(this);

        InitializeComponent();
    }
}