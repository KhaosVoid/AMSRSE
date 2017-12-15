using AMSRSE.Editor.Animation;
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
    [ContentProperty("Children")]
    public abstract class DynamicViewBase : AnimatedControl
    {
        #region Dependency Properties

        public static readonly DependencyProperty DynamicViewParentProperty =
            DependencyProperty.Register("DynamicViewParent", typeof(DynamicViewBase), typeof(DynamicViewBase));

        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(IList), typeof(DynamicViewBase), new PropertyMetadata(null, OnChildrenPropertyChanged));

        //public static readonly DependencyProperty ChildrenProperty =
        //    DependencyProperty.Register("Children", typeof(DynamicViewCollection<DynamicViewBase>), typeof(DynamicViewBase), new PropertyMetadata(OnChildrenPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public DynamicViewBase DynamicViewParent
        {
            get { return (DynamicViewBase)GetValue(DynamicViewParentProperty); }
            set { SetValue(DynamicViewParentProperty, value); }
        }

        public IList Children
        {
            get { return (IList)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        //public DynamicViewCollection<DynamicViewBase> Children
        //{
        //    get { return (DynamicViewCollection<DynamicViewBase>)GetValue(ChildrenProperty); }
        //    set { SetValue(ChildrenProperty, value); }
        //}

        #endregion Properties

        #region Members

        private ObservableCollection<DynamicViewBase> _children;

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
            _children = new ObservableCollection<DynamicViewBase>();
            Children = _children;
            _children.CollectionChanged += Children_CollectionChanged;

            //Children = new DynamicViewCollection<DynamicViewBase>();
            //Children.CollectionChanged += Children_CollectionChanged;
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
                    dvb._children[i].OnSetAsCurrentView -= dvb.DynamicViewBase_OnSetAsCurrentView;
                    dvb._children[i].OnSetAsCurrentView += dvb.DynamicViewBase_OnSetAsCurrentView;

                    //dvb.Children[i].OnSetAsCurrentView -= dvb.DynamicViewBase_OnSetAsCurrentView;
                    //dvb.Children[i].OnSetAsCurrentView += dvb.DynamicViewBase_OnSetAsCurrentView;
                }
            }
        }

        #endregion Dependency Property Callbacks

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.Animations != null)
            {
                this.Animations["FadeOutLeft"].Completed -= FadeOut_Completed;
                this.Animations["FadeOutLeft"].Completed += FadeOut_Completed;

                this.Animations["FadeOutRight"].Completed -= FadeOut_Completed;
                this.Animations["FadeOutRight"].Completed += FadeOut_Completed;
            }
        }

        protected void Children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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
                var cView = FindView(view._children[i], name);
                //var cView = FindView(view.Children[i], name);

                if (cView != null)
                    return cView;
            }

            return null;
        }

        public void SetAsCurrentView(DynamicViewHost.NavigationDirections navigationDirection)
        {
            OnSetAsCurrentView?.Invoke(this, navigationDirection);
        }

        public virtual void FadeIn()
        {
            switch (this._navigationDirection)
            {
                case DynamicViewHost.NavigationDirections.Backward:
                    this.Animations["FadeInLeft"].Start();
                    break;

                case DynamicViewHost.NavigationDirections.Forward:
                    this.Animations["FadeInRight"].Start();
                    break;
            }
        }

        public virtual void FadeOut()
        {
            switch (this._navigationDirection)
            {
                case DynamicViewHost.NavigationDirections.Backward:
                    this.Animations["FadeOutRight"].Start();
                    break;

                case DynamicViewHost.NavigationDirections.Forward:
                    this.Animations["FadeOutLeft"].Start();
                    break;
            }
        }

        private void FadeOut_Completed(SequentialStoryboardItem ssbi)
        {
            OnFadeOutCompleted(ssbi);
        }

        protected virtual void OnFadeOutCompleted(SequentialStoryboardItem ssbi)
        {
            RaiseOnFadeOutComplete();
        }

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
