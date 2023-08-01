using KSociety.Base.Pre.Form.View.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.Common.List.GridView;
using System.ComponentModel;

namespace KSociety.Com.Pre.Form.View.Forms.Common.List.GridView;

public partial class CommonTagGroup : DataGridView<Srv.Dto.Common.TagGroup, Srv.Dto.Common.List.GridView.TagGroup>, ITagGroup
{
    public CommonTagGroup()
    {
        InitializeComponent();
    }

    public CommonTagGroup(IContainer container)
    {
        container.Add(this);

        InitializeComponent();
    }
}