using AMSRSE.Editor.Animation;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace AMSRSE.Editor.Views.Dynamic
{
    [ContentProperty("Children")]
    public abstract class DynamicViewBase : AnimatedControl
    {
        #region Dependency Properties

        public static readonly DependencyProperty DynamicViewParentProperty =
            DependencyProperty.Register("DynamicViewParent", typeof(DynamicViewBase), typeof(DynamicViewBase));

        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(DynamicViewCollection<DynamicViewBase>), typeof(DynamicViewBase), new PropertyMetadata(OnChildrenPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public DynamicViewBase DynamicViewParent
        {
            get { return (DynamicViewBase)GetValue(DynamicViewParentProperty); }
            set { SetValue(DynamicViewParentProperty, value); }
        }

        public DynamicViewCollection<DynamicViewBase> Children
        {
            get { return (DynamicViewCollection<DynamicViewBase>)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        #endregion Properties

        #region Events

        public delegate void SetAsCurrentViewHandler(DynamicViewBase dynamicView);
        public event SetAsCurrentViewHandler OnSetAsCurrentView;

        public delegate void FadeOutCompleteHandler();
        public event FadeOutCompleteHandler OnFadeOutComplete;

        #endregion Events

        #region Ctor

        public DynamicViewBase()
        {
            Children = new DynamicViewCollection<DynamicViewBase>();
            Children.CollectionChanged += Children_CollectionChanged;
        }



        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnChildrenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DynamicViewBase dvb)
            {
                if (e.OldValue is DynamicViewCollection<DynamicViewBase> odvc)
                    odvc.CollectionChanged -= dvb.Children_CollectionChanged;

                if (e.NewValue is DynamicViewCollection<DynamicViewBase> ndvc)
                    ndvc.CollectionChanged += dvb.Children_CollectionChanged;

                for (int i = 0; i < dvb.Children.Count; i++)
                {
                    dvb.Children[i].OnSetAsCurrentView -= dvb.DynamicViewBase_OnSetAsCurrentView;
                    dvb.Children[i].OnSetAsCurrentView += dvb.DynamicViewBase_OnSetAsCurrentView;
                }
            }
        }

        #endregion Dependency Property Callbacks

        #region Methods

        private void Children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                for (int i = 0; i < e.NewItems.Count; i++)
                {
                    ((DynamicViewBase)e.NewItems[i]).DynamicViewParent = this;
                    ((DynamicViewBase)e.NewItems[i]).OnSetAsCurrentView += DynamicViewBase_OnSetAsCurrentView;
                    ((DynamicViewBase)e.NewItems[i]).Opacity = 0;
                }
        }

        private void DynamicViewBase_OnSetAsCurrentView(DynamicViewBase dynamicView)
        {
            OnSetAsCurrentView?.Invoke(dynamicView);
        }

        public void SetAsCurrentView()
        {
            OnSetAsCurrentView?.Invoke(this);
        }

        public abstract void FadeIn();
        public abstract void FadeOut();

        protected void RaiseOnFadeOutComplete()
        {
            OnFadeOutComplete?.Invoke();
        }

        #endregion Methods
    }
}
