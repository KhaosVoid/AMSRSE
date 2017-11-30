using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace AMSRSE.Editor.Animation
{
    [ContentProperty("Storyboard")]
    public class StoryboardSequence : SequentialStoryboardItem
    {
        #region Dependency Properties

        public static readonly DependencyProperty StoryboardProperty =
            DependencyProperty.Register("Storyboard", typeof(Storyboard), typeof(StoryboardSequence), new PropertyMetadata(OnStoryboardPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public Storyboard Storyboard
        {
            get { return (Storyboard)GetValue(StoryboardProperty); }
            set { SetValue(StoryboardProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public StoryboardSequence()
        {
            //Storyboard.Completed += Storyboard_Completed;
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnStoryboardPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is StoryboardSequence sbs && e.OldValue != e.NewValue)
            {
                if (e.OldValue is Storyboard osb)
                    osb.Completed -= sbs.Storyboard_Completed;

                if (e.NewValue is Storyboard nsb)
                    nsb.Completed += sbs.Storyboard_Completed;
            }
        }

        #endregion Dependency Property Callbacks

        #region Methods

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            RaiseCompletedEvent();
        }

        public override void Start()
        {
            base.Start();
            Storyboard.Begin();
        }

        public override void Pause()
        {
            throw new NotImplementedException();

            base.Pause();
        }

        public override void Stop()
        {
            throw new NotImplementedException();

            base.Stop();
        }

        #endregion Methods
    }
}