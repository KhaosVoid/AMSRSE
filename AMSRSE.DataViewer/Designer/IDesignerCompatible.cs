using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.DataViewer.Designer
{
    public interface IDesignerCompatible
    {
        void InitializeComponent(Uri xamlPath);
    }
}
