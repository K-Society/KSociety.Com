using KSociety.Base.Pre.Form.View.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.Common.List.GridView;
using System.ComponentModel;

namespace KSociety.Com.Pre.Form.View.Forms.Common.List.GridView
{
    public partial class CommonConnection : DataGridView<Srv.Dto.Common.Connection, Srv.Dto.Common.List.GridView.Connection>, IConnection
    {
        public CommonConnection()
        {
            InitializeComponent();
        }

        public CommonConnection(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
