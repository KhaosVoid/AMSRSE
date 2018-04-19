using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels.Validation
{
    public interface IValidator
    {
        string ErrorText { get; }
        string Validate(DependencyObject d, DependencyProperty p);
    }
}
