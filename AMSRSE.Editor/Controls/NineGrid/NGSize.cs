using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.Editor.Controls.NineGrid
{
    public class NGSize
    {
        #region Properties

        public double Left { get; private set; }
        public double Top { get; private set; }
        public double Right { get; private set; }
        public double Bottom { get; private set; }
        public double MidWidth { get; private set; }
        public double MidHeight { get; private set; }

        #endregion Properties

        #region Ctor

        public NGSize(double left, double top, double right, double bottom)
        {
            int test;
            Left = left > 1 ? 1 : left;
            Top = top > 1 ? 1 : top;
            Right = right > 1 ? 1 : right;
            Bottom = bottom > 1 ? 1 : bottom;

            double midWidth = 1 - left - right;
            MidWidth = midWidth < 0 ? 0 : midWidth;

            double midHeight = 1 - bottom - top;
            MidHeight = midHeight < 0 ? 0 : midHeight;
        }

        #endregion Ctor
    }
}
