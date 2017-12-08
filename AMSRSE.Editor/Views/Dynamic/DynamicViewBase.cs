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

        #region Members

        protected DynamicViewHost.NavigationDirections _navigationDirection =
            DynamicViewHost.NavigationDirections.Forward;

        #endregion Members

        #region Events

        public delegate void SetAsCurrentViewHandler(DynamicViewBase dynamicView, DynamicViewHost.NavigationDirections navigationDirection);
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
            for (int i = 0; i < e.OldItems?.Count; i++)
            {
                ((DynamicViewBase)e.OldItems[i]).DynamicViewParent = null;
                ((DynamicViewBase)e.OldItems[i]).OnSetAsCurrentView -= DynamicViewBase_OnSetAsCurrentView;
                ((DynamicViewBase)e.OldItems[i]).Opacity = 0;
            }

            for (int i = 0; i < e.NewItems?.Count; i++)
            {
                ((DynamicViewBase)e.NewItems[i]).DynamicViewParent = this;
                ((DynamicViewBase)e.NewItems[i]).OnSetAsCurrentView -= DynamicViewBase_OnSetAsCurrentView;
                ((DynamicViewBase)e.NewItems[i]).OnSetAsCurrentView += DynamicViewBase_OnSetAsCurrentView;
                ((DynamicViewBase)e.NewItems[i]).Opacity = 0;
            }

            //if (e.Action == NotifyCollectionChangedAction.Add)
            //    for (int i = 0; i < e.NewItems.Count; i++)
            //    {
            //        ((DynamicViewBase)e.NewItems[i]).DynamicViewParent = this;
            //        ((DynamicViewBase)e.NewItems[i]).OnSetAsCurrentView += DynamicViewBase_OnSetAsCurrentView;
            //        ((DynamicViewBase)e.NewItems[i]).Opacity = 0;
            //    }
        }

        private void DynamicViewBase_OnSetAsCurrentView(DynamicViewBase dynamicView, DynamicViewHost.NavigationDirections navigationDirection)
        {
            OnSetAsCurrentView?.Invoke(dynamicView, navigationDirection);
        }

        public DynamicViewBase GetView(string name)
        {
            var rootView = GetRootView(this);

            return FindView(rootView, name);
        }

        private DynamicViewBase GetRootView(DynamicViewBase view)
        {
            if (view.DynamicViewParent is DynamicViewBase dvb)
                return GetRootView(dvb);

            return view;
        }

        private DynamicViewBase FindView(DynamicViewBase view, string name)
        {
            if (view.Name == name)
                return view;

            for (int i = 0; i < view.Children?.Count; i++)
            {
                var cView = FindView(view.Children[i], name);

                if (cView != null)
                    return cView;
            }

            return null;
        }

        public void SetAsCurrentView(DynamicViewHost.NavigationDirections navigationDirection)
        {
            OnSetAsCurrentView?.Invoke(this, navigationDirection);
        }

        public abstract void FadeIn();
        public abstract void FadeOut();

        protected void RaiseOnFadeOutComplete()
        {
            OnFadeOutComplete?.Invoke();
        }

        public void SetDirection(DynamicViewHost.NavigationDirections navigationDirection)
        {
            _navigationDirection = navigationDirection;
        }

        #endregion Methods
    }
}
