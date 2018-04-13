using AMSRSE.DataViewer.Designer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AMSRSE.DataViewer.Controls
{
    public class ContentControlBase : ContentControl, IDesignerCompatible
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
