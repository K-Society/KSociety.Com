using KSociety.Base.Pre.Form.View.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.S7.List.GridView;
using System.ComponentModel;

namespace KSociety.Com.Pre.Form.View.Forms.S7.List.GridView
{
    public partial class S7Tag : DataGridView<Srv.Dto.S7.S7Tag, Srv.Dto.S7.List.GridView.S7Tag>, IS7Tag
    {
        public S7Tag()
        {
            InitializeComponent();
        }

        public S7Tag(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
