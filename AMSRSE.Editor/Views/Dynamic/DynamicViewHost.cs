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
    [ContentProperty("DynamicViews")]
    public class DynamicViewHost : Control
    {
        #region Dependency Properties

        public static readonly DependencyProperty DynamicViewsProperty =
            DependencyProperty.Register("DynamicViews", typeof(DynamicViewCollection<DynamicViewBase>), typeof(DynamicViewHost), new PropertyMetadata(OnDynamicViewsPropertyChanged));

        public static readonly DependencyProperty CurrentDynamicViewProperty =
            DependencyProperty.Register("CurrentDynamicView", typeof(DynamicViewBase), typeof(DynamicViewHost), new PropertyMetadata(OnCurrentDynamicViewPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public DynamicViewCollection<DynamicViewBase> DynamicViews
        {
            get { return (DynamicViewCollection<DynamicViewBase>)GetValue(DynamicViewsProperty); }
            set { SetValue(DynamicViewsProperty, value); }
        }

        public DynamicViewBase CurrentDynamicView
        {
            get { return (DynamicViewBase)GetValue(CurrentDynamicViewProperty); }
            set { SetValue(CurrentDynamicViewProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public DynamicViewHost()
        {
            DynamicViews = new DynamicViewCollection<DynamicViewBase>();
            DynamicViews.CollectionChanged += DynamicViews_CollectionChanged;
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnDynamicViewsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DynamicViewHost dvh)
            {
                if (e.OldValue is DynamicViewCollection<DynamicViewBase> odvc)
                    odvc.CollectionChanged -= dvh.DynamicViews_CollectionChanged;

                if (e.NewValue is DynamicViewCollection<DynamicViewBase> ndvc)
                    ndvc.CollectionChanged += dvh.DynamicViews_CollectionChanged;

                for (int i = 0; i < dvh.DynamicViews.Count; i++)
                {
                    dvh.DynamicViews[i].OnSetAsCurrentView -= dvh.DynamicViewHost_OnSetAsCurrentView;
                    dvh.DynamicViews[i].OnSetAsCurrentView += dvh.DynamicViewHost_OnSetAsCurrentView;
                }
            }
        }

        private static void OnCurrentDynamicViewPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DynamicViewHost dvh)
                dvh.CurrentDynamicView.FadeIn();
        }

        #endregion Dependency Property Callbacks

        #region Methods

        private void DynamicViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                for (int i = 0; i < e.NewItems.Count; i++)
                {
                    ((DynamicViewBase)e.NewItems[i]).OnSetAsCurrentView += DynamicViewHost_OnSetAsCurrentView;
                    ((DynamicViewBase)e.NewItems[i]).Opacity = 0;
                }
        }

        private void DynamicViewHost_OnSetAsCurrentView(DynamicViewBase dynamicView)
        {
            CurrentDynamicView.OnFadeOutComplete += () =>
            {
                CurrentDynamicView = dynamicView;
                //CurrentDynamicView.FadeIn();
            };
            CurrentDynamicView.FadeOut();
        }

        #endregion Methods
    }
}
