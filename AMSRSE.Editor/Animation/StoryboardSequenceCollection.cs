using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.Editor.Animation
{
    public class StoryboardSequenceCollection<S> : ObservableCollection<S> where S : SequentialStoryboardItem
    {

    }
}
