using KSociety.Com.Pre.Form.View.Abstractions.Common.List.GridView;
using KSociety.Com.Pre.Form.View.Abstractions.Logix.List.GridView;
using KSociety.Com.Pre.Form.View.Abstractions.S7.List.GridView;
using System.Windows.Forms;

namespace KSociety.Com.Pre.Form.View.Forms
{
    public partial class GeneralTabUserControl : UserControl, Abstractions.ITabUserControl
    {
        public GeneralTabUserControl()
        {
            InitializeComponent();
        }

        public ITagGroup GetCommonTagGroup()
        {
            return commonTabUserControl1.GetCommonTagGroup();
        }

        public ILogixConnection GetLogixConnection()
        {
            return logixTabUserControl1.GetLogixConnection();
        }

        public ILogixTag GetLogixTag()
        {
            return logixTabUserControl1.GetLogixTag();
        }

        public IS7Connection GetS7Connection()
        {
            return s7TabUserControl1.GetS7Connection();
        }

        public IS7Tag GetS7Tag()
        {
            return s7TabUserControl1.GetS7Tag();
        }
    }
}
