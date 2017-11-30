using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace AMSRSE.Editor.Animation
{
    [ContentProperty("Children")]
    public class SequentialStoryboard : SequentialStoryboardItem
    {
        #region Dependency Properties

        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(StoryboardSequenceCollection<SequentialStoryboardItem>), typeof(SequentialStoryboard), new PropertyMetadata(OnChildrenPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public StoryboardSequenceCollection<SequentialStoryboardItem> Children
        {
            get { return (StoryboardSequenceCollection<SequentialStoryboardItem>)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        #endregion Properties

        #region Members

        private bool _isStartOne;

        #endregion Members

        #region Ctor

        public SequentialStoryboard()
        {
            Children = new StoryboardSequenceCollection<SequentialStoryboardItem>();
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnChildrenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SequentialStoryboard ssb)
            {
                if (e.OldValue is SequentialStoryboardItem ossbi)
                    ossbi.Completed -= ssb.SequentialStoryboardItem_Completed;

                if (e.NewValue is SequentialStoryboardItem nssbi)
                    nssbi.Completed += ssb.SequentialStoryboardItem_Completed;
            }
        }

        private void SequentialStoryboardItem_Completed(SequentialStoryboardItem ssbi)
        {
            if (_isStartOne)
            {
                _isStartOne = false;
                return;
            }

            var nextAnimationIndex = Children.IndexOf(ssbi) + 1;

            if (nextAnimationIndex < Children.Count)
                Children[nextAnimationIndex].Start();
        }

        #endregion Dependency Property Callbacks

        #region Methods

        public override void Start()
        {
            if (this.AnimationState != AnimationStates.Animating)
            {
                base.Start();
                Children.First().Start();
            }
        }

        public void StartOne(uint index)
        {
            if (this.AnimationState != AnimationStates.Animating)
            {
                _isStartOne = true;
                Children.First(c => c.Index == index).Start();
            }
            //    base.StartOne(index);


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
