using AMSRSE.Editor.Animation;
using AMSRSE.Editor.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class DynamicViewHost : AnimatedControl
    {
        #region Enums

        public enum NavigationDirections
        {
            Backward,
            Forward
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyProperty DynamicViewsProperty =
            DependencyProperty.Register("DynamicViews", typeof(XamlSafeObservableCollection<DynamicViewBase>), typeof(DynamicViewHost), new PropertyMetadata(OnDynamicViewsPropertyChanged));

        //public static readonly DependencyProperty DynamicViewsProperty =
        //    DependencyProperty.Register("DynamicViews", typeof(DynamicViewCollection<DynamicViewBase>), typeof(DynamicViewHost), new PropertyMetadata(OnDynamicViewsPropertyChanged));

        public static readonly DependencyProperty CurrentDynamicViewNameProperty =
            DependencyProperty.Register("CurrentDynamicViewName", typeof(string), typeof(DynamicViewHost), new PropertyMetadata(OnCurrentDynamicViewNamePropertyChanged));

        public static readonly DependencyPropertyKey CurrentDynamicViewPropertyKey =
            DependencyProperty.RegisterReadOnly("CurrentDynamicView", typeof(DynamicViewBase), typeof(DynamicViewHost), new PropertyMetadata(OnCurrentDynamicViewPropertyChanged));

        public static readonly DependencyProperty CurrentDynamicViewProperty =
            CurrentDynamicViewPropertyKey.DependencyProperty;

        public static readonly DependencyProperty NavigateToProperty =
            DependencyProperty.RegisterAttached("NavigateTo", typeof(string), typeof(DynamicViewHost));

        public static readonly DependencyProperty NavigationDirectionProperty =
            DependencyProperty.RegisterAttached("NavigationDirection", typeof(NavigationDirections), typeof(DynamicViewHost));

        #endregion Dependency Properties

        #region Properties

        public XamlSafeObservableCollection<DynamicViewBase> DynamicViews
        {
            get { return (XamlSafeObservableCollection<DynamicViewBase>)GetValue(DynamicViewsProperty); }
            set { SetValue(DynamicViewsProperty, value); }
        }

        //public DynamicViewCollection<DynamicViewBase> DynamicViews
        //{
        //    get { return (DynamicViewCollection<DynamicViewBase>)GetValue(DynamicViewsProperty); }
        //    set { SetValue(DynamicViewsProperty, value); }
        //}

        public string CurrentDynamicViewName
        {
            get { return (string)GetValue(CurrentDynamicViewNameProperty); }
            set { SetValue(CurrentDynamicViewNameProperty, value); }
        }

        public DynamicViewBase CurrentDynamicView
        {
            get { return (DynamicViewBase)GetValue(CurrentDynamicViewProperty); }
            private set { SetValue(CurrentDynamicViewPropertyKey, value); }
        }

        #endregion Properties

        #region Members

        private DynamicViewBase _newView;
        private NavigationDirections _newViewDirection;

        private DynamicViewBase.FadeOutCompleteHandler _currentDynamicView_OnFadeOutComplete;

        #endregion Members

        #region Ctor

        public DynamicViewHost()
        {
            //_dynamicViews = new ObservableCollection<DynamicViewBase>();
            //DynamicViews = _dynamicViews;
            DynamicViews = new XamlSafeObservableCollection<DynamicViewBase>();
            DynamicViews.CollectionChanged += DynamicViews_CollectionChanged;

            //DynamicViews = new DynamicViewCollection<DynamicViewBase>();
            //DynamicViews.CollectionChanged += DynamicViews_CollectionChanged;
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

                    //dvh.DynamicViews[i].OnSetAsCurrentView -= dvh.DynamicViewHost_OnSetAsCurrentView;
                    //dvh.DynamicViews[i].OnSetAsCurrentView += dvh.DynamicViewHost_OnSetAsCurrentView;
                }
            }
        }

        private static void OnCurrentDynamicViewNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DynamicViewHost dvh)
            {
                for (int i = 0; i < dvh.DynamicViews.Count; i++)
                {
                    var view = dvh.DynamicViews[i].GetView(dvh.CurrentDynamicViewName);

                    if (view != null)
                        dvh.CurrentDynamicView = view;
                }
            }
        }

        private static void OnCurrentDynamicViewPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DynamicViewHost dvh)
                dvh.CurrentDynamicView.OnApplyTemplate();
        }

        #endregion Dependency Property Callbacks

        #region Attached Property Methods

        public static string GetNavigateTo(DependencyObject obj)
        {
            return (string)obj.GetValue(NavigateToProperty);
        }

        public static void SetNavigateTo(DependencyObject obj, string value)
        {
            obj.SetValue(NavigateToProperty, value);
        }

        public static NavigationDirections GetNavigationDirection(DependencyObject obj)
        {
            return (NavigationDirections)obj.GetValue(NavigationDirectionProperty);
        }

        public static void SetNavigationDirection(DependencyObject obj, NavigationDirections value)
        {
            obj.SetValue(NavigationDirectionProperty, value);
        }

        #endregion Attached Property Methods

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            for (int i = 0; i < DynamicViews.Count; i++)
            {
                var view = DynamicViews[i].GetView(CurrentDynamicViewName);

                if (view != null)
                {
                    CurrentDynamicView = view;
                    CurrentDynamicView.Opacity = 1;
                }
            }
        }

        private void DynamicViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            for (int i = 0; i < e.OldItems?.Count; i++)
            {
                ((DynamicViewBase)e.OldItems[i]).OnSetAsCurrentView -= DynamicViewHost_OnSetAsCurrentView;
                ((DynamicViewBase)e.OldItems[i]).Opacity = 0;
            }

            for (int i = 0; i < e.NewItems?.Count; i++)
            {
                ((DynamicViewBase)e.NewItems[i]).OnSetAsCurrentView -= DynamicViewHost_OnSetAsCurrentView;
                ((DynamicViewBase)e.NewItems[i]).OnSetAsCurrentView += DynamicViewHost_OnSetAsCurrentView;
                ((DynamicViewBase)e.NewItems[i]).Opacity = 0;
            }

            //if (e.Action == NotifyCollectionChangedAction.Add)
            //    for (int i = 0; i < e.NewItems.Count; i++)
            //    {
            //        ((DynamicViewBase)e.NewItems[i]).OnSetAsCurrentView += DynamicViewHost_OnSetAsCurrentView;
            //        ((DynamicViewBase)e.NewItems[i]).Opacity = 0;
            //    }
        }

        private void DynamicViewHost_OnSetAsCurrentView(DynamicViewBase dynamicView, NavigationDirections navigationDirection)
        {
            _newView = dynamicView;
            _newViewDirection = navigationDirection;

            CurrentDynamicView.OnFadeOutComplete -= _currentDynamicView_OnFadeOutComplete;

            _currentDynamicView_OnFadeOutComplete = () =>
            {
                var oldDV = CurrentDynamicView.GetHashCode();
                var newDV = dynamicView.GetHashCode();

                dynamicView.SetDirection(navigationDirection);
                CurrentDynamicView = dynamicView;

                if (oldDV == newDV)
                    CurrentDynamicView.FadeIn();
            };


            CurrentDynamicView.OnFadeOutComplete += _currentDynamicView_OnFadeOutComplete;
            //CurrentDynamicView.OnFadeOutComplete += CurrentDynamicView_OnFadeOutComplete;

            CurrentDynamicView.SetDirection(navigationDirection);

            CurrentDynamicView.FadeOut();
        }

        private void CurrentDynamicView_OnFadeOutComplete()
        {
            var oldDV = CurrentDynamicView.GetHashCode();

            _newView.SetDirection(_newViewDirection);
            CurrentDynamicView.OnFadeOutComplete -= CurrentDynamicView_OnFadeOutComplete;
            CurrentDynamicView = _newView;

            if (oldDV == _newView.GetHashCode())
                CurrentDynamicView.FadeIn();

            _newView = null;
        }

        #endregion Methods

    }
}
