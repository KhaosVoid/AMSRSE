using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.Designer
{
    public class DesignerCompatible : IDesignerCompatible
    {
        protected void InitializeComponent(Uri xamlPath)
        {
            IDesignerCompatible dc = this;
            dc.InitializeComponent(xamlPath);
        }

        void IDesignerCompatible.InitializeComponent(Uri xamlPath)
        {
            Application.LoadComponent(this, xamlPath);
        }
    }
}
